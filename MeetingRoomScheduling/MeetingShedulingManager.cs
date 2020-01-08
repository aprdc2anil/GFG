using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using MeetingRoomScheduling.Internal;

namespace MeetingRoomScheduling
{
    /// <summary>
    /// to do: this needs to be a singleton
    /// or its data needs to be at class level
    /// and all meeting requests should pass through it
    /// </summary>
    public class MeetingShedulingManager
    {
        private double providedCapacity;
        private double bookedCapacity;

        // to do , need to dispose this 
        private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        private readonly object lockObject = new object();

        private Dictionary<string, MeetingRoom> meetingRooms;
        private Dictionary<string, int> meetingRoomCapacity;
        private SortedSet<int> availableSizes;
        private SortedDictionary<int, SortedSet<string>> meetingRoomsBySize;

        public MeetingShedulingManager()
        {
            this.meetingRooms = new Dictionary<string, MeetingRoom>();
            this.meetingRoomCapacity = new Dictionary<string, int>();
            this.availableSizes = new SortedSet<int>();
            this.meetingRoomsBySize = new SortedDictionary<int, SortedSet<string>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetResourceEfficiency()
        {
            double resourceEfficiency = 1.0;

            rwLock.EnterReadLock();
            try
            {
                if (bookedCapacity <= 0.0 || providedCapacity <= 0.0)
                {
                    resourceEfficiency = -1.0;
                }

                resourceEfficiency = providedCapacity / bookedCapacity;
            }
            catch (Exception ex)
            {
                Console.WriteLine("some error occured", ex);
                resourceEfficiency = -1.0;
            }
            finally
            {
                rwLock.ExitReadLock();
            }

            return resourceEfficiency;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="requestedSize"></param>
        /// <returns></returns>
        public async Task<List<string>> GetAvailableMeetingRooms(DateTime from, DateTime to, int requestedSize)
        {
            var newMeetingRequest = ValidateAndGetMeeting(from, to, requestedSize);

            if (newMeetingRequest != null)
            {
                // to do: this is generally in small number this should be ok, and is already in sorted order
                var availableSizesList = availableSizes.ToList();
                int count = 0;

                while (availableSizesList[count] < newMeetingRequest.MeetingSizeRequested)
                {
                    ++count;
                }

                List<string> availableMeetingRooms = new List<string>();

                foreach (var size in availableSizesList.Skip(count))
                {
                    var meetingRoomIds = meetingRoomsBySize[size];

                    // run in parllel for the same size meeting rooms
                    var tasks = meetingRoomIds.Select(p => PrivateCheckMeetingRoomAvailability(newMeetingRequest, p));

                    await Task.WhenAll(tasks).ConfigureAwait(false);


                    availableMeetingRooms = tasks.Select(p => p.Result).Where(p => p != null).ToList<string>();

                    if (availableMeetingRooms.Any())
                    {
                        break;
                    }
                }

                return availableMeetingRooms;
            }


            return new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="requestedSize"></param>
        /// <param name="meetingRoomId"></param>
        /// <param name="requestorId"></param>
        /// <returns></returns>
        public bool BookMeeting(DateTime from, DateTime to, int requestedSize, string meetingRoomId, string requestorId)
        {
            if (!meetingRooms.ContainsKey(meetingRoomId))
            {
                return false;
            }

            var meetingRequest = ValidateAndGetMeeting(from, to, requestedSize, requestorId);

            if (meetingRequest == null)
            {
                return false;
            }

            // not considering if requestorId is already part of another overlapping meeting, it can be easily done 
            // Try to book the meeting room

            var meetingRoom = meetingRooms[meetingRoomId];
            var flag = meetingRoom.BookMeeting(meetingRequest);

            // this is assuming Int64 is sufficient for providedCapacity, providedCapacity
            // to do: this should be changed later ..

            if (flag)
            {
                UpdateResourceEfficiencyTrackers(requestedSize, requestorId);
            }

            return flag;
        }

        #region private methods

        private void UpdateResourceEfficiencyTrackers(int requestedSize, string requestorId)
        {
            try
            {
                rwLock.EnterWriteLock();
                this.providedCapacity += requestedSize;
                this.bookedCapacity += meetingRoomCapacity[requestorId];
            }
            catch (Exception ex)
            {
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        private async Task<string> PrivateCheckMeetingRoomAvailability(Meeting newMeetingRequest, string meetingRoom)
        {
            var result = await meetingRooms[meetingRoom].CheckAvailability(newMeetingRequest);

            if (result)
            {
                return meetingRoom;
            }

            return null;
        }

        private Meeting ValidateAndGetMeeting(DateTime from, DateTime to, int requestedSize, string requestorId = null)
        {
            var roundedFrom = RoundUpDateTime(from);
            var roundedTo = RoundUpDateTime(to);

            if (roundedFrom >= roundedTo)
            {
                return null;
            }

            if (!DateTime.Equals(roundedFrom.Date, roundedTo.Date))
            {
                return null;
            }

            if (availableSizes.Count == 0)
            {
                return null;
            }

            if (availableSizes.First() > requestedSize)
            {
                return null;
            }

            if (availableSizes.Last() < requestedSize)
            {
                return null;
            }

            // reject if future date is greater than two weeks , 
            if (roundedFrom.Date > DateTime.Now.Date.AddDays(14))
            {
                return null;
            }

            return new Meeting(requestedSize, GetDay(roundedFrom), GetInterval(roundedFrom, roundedTo), requestorId);
        }

        /// <summary>
        /// round the time to 5 minutes block
        /// </summary>
        /// <param name="dateToRound"></param>
        /// <returns></returns>
        private static DateTime RoundUpDateTime(DateTime dateToRound)
        {
            // rounding to its 5 minutes, this can be done to minute as well 
            TimeSpan roundPeriod = new TimeSpan(0, 0, 5, 0);

            var delta = dateToRound.Ticks % roundPeriod.Ticks;

            // keeping it to UTC standard
            return new DateTime(dateToRound.Ticks - delta, DateTimeKind.Utc);
        }

        private static Interval GetInterval(DateTime roundedFrom, DateTime roundedTo)
        {
            int low = (roundedFrom.Hour * 60 + roundedFrom.Minute) / 5;
            int high = (roundedTo.Hour * 60 + roundedTo.Minute) / 5;

            return new Interval(low, high);
        }

        private static string GetDay(DateTime roundedFrom)
        {
            return roundedFrom.ToShortDateString();
        }
        #endregion

        #region admin methods
        /// <summary>
        /// to do: assuming the id is unique while adding, this needs to be validated seperately
        /// </summary>
        /// <param name="roomSize"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AddMeetingRoom(int roomSize, string id)
        {
            if (!ValidateMeetingRoom(roomSize, id))
            {
                return false;
            }

            MeetingRoom newRoom = new MeetingRoom(id, roomSize);

            // to do , this lock is inefficient can be changed later
            lock (lockObject)
            {
                if (meetingRooms.TryAdd(newRoom.MeetingRoomId, newRoom))
                {
                    if (meetingRoomCapacity.TryAdd(newRoom.MeetingRoomId, newRoom.Size))
                    {
                        if (!availableSizes.Contains(roomSize))
                        {
                            availableSizes.Add(roomSize);
                        }

                        if (meetingRoomsBySize.ContainsKey(roomSize))
                        {
                            meetingRoomsBySize[roomSize].Add(newRoom.MeetingRoomId);
                        }
                        else
                        {
                            meetingRoomsBySize.TryAdd(roomSize, new SortedSet<string>() { newRoom.MeetingRoomId });
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// add any specific validations here
        /// </summary>
        /// <param name="meetingSize"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidateMeetingRoom(int meetingSize, string id)
        {
            if (meetingRooms.ContainsKey(id))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
