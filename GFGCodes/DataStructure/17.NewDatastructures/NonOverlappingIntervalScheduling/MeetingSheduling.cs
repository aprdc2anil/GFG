using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace GFGCodes
{
    /// <summary>
    /// 
    /// </summary>
    public class Interval
    {
        public int Low { get; private set; }
        public int High { get; private set; }

        public Interval(int low, int high)
        {
            if (high <= low)
            {
                throw new InvalidOperationException("'high' should be higher than 'low'.");
            }

            this.Low = low;
            this.High = high;
        }
    }

    public class Meeting
    {
        public string DayOfTheMetting { get; private set; }

        public Interval MeetingInterval { get; private set; }

        public int MeetingSizeRequested { get; private set; }

        public string MeetingRequestorId { get; private set; }

        public Meeting(int meetingSizeRequested, string day, Interval meetingInterval, string meetingRequestorId = null)
        {
            this.MeetingInterval = meetingInterval;
            this.MeetingSizeRequested = MeetingSizeRequested;

            // tertiary information for validation purpose
            this.DayOfTheMetting = day;

            // this is not needed if no need to track the meeting overalaps by requestor
            this.MeetingRequestorId = meetingRequestorId??string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MeetingTreeNode
    {
        public MeetingTreeNode LeftMeeting { get; set; }
        public MeetingTreeNode RightMeeting { get; set; }
        public Meeting Meeting { get; private set; }      
       
        public MeetingTreeNode(Meeting interval)
        {
            this.Meeting = interval;
            LeftMeeting = RightMeeting = null;
        }
    }

    /// <summary>
    /// to do: this is currently bst, need to make it balancing bst later
    /// to do: currently locking at write can block the cpu threads, this should be optimized for more efficiency 
    /// NOTE: This is an individual timeline of a specifcific meeting room and for specific day     
    /// </summary>
    public class MeetingRoomTimeLine
    {
        private MeetingTreeNode root;
        private readonly object lockObject = new object();       

        // to do
        public bool Add(Meeting interval)
        {
            if (root == null)
            {
                /// to do: currently locking at write can block the cpu threads, 
                /// this should be optimized for more efficiency
                lock (lockObject)
                {
                    if (root == null)
                    {
                        root = new MeetingTreeNode(interval);
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
               return PrivateAdd(root, interval);
            }
        }

        private bool PrivateAdd(MeetingTreeNode root, Meeting interval)
        {
            // can use a Comparer later
            if (interval.MeetingInterval.High <= root.Meeting.MeetingInterval.Low)
            {
                if (root.LeftMeeting == null)
                {
                    var boolFlag = false;
                    
                    lock (lockObject)
                    {
                        if (root.LeftMeeting == null)
                        {
                            root.LeftMeeting = new MeetingTreeNode(interval);
                            boolFlag = true;
                        }
                    }

                    return boolFlag;

                }
                else
                {
                    return PrivateAdd(root.LeftMeeting, interval);
                }
            }
            else if (interval.MeetingInterval.Low >= root.Meeting.MeetingInterval.High)
            {
                if (root.RightMeeting == null)
                {
                    var boolFlag = false;

                    lock (lockObject)
                    {
                        if (root.RightMeeting == null)
                        {
                            root.RightMeeting = new MeetingTreeNode(interval);
                            boolFlag = true;
                        }
                    }

                    return boolFlag;
                }
                else
                {
                    return PrivateAdd(root.RightMeeting, interval);
                }
            }
            else
            {
                return false;
                /*     root 10 , 20
                //     interval low less than 20 
                //          or
                //     interval high is greater than 10
                // 7 9|10 goes to left
                // 11, 25 overlap with root
                // 11, 19 overlap with root
                // 8,15 overlap with root
                // 20|21, 25 goes to right
                */
            }
        }

        public bool CheckAvailability(Meeting interval)
        {
            if (root == null)
            {                
                return true;
            }

            return PrivateCheckAvailability(root, interval);
        }

        private bool PrivateCheckAvailability(MeetingTreeNode root, Meeting interval)
        {
            if (interval.MeetingInterval.High <= root.Meeting.MeetingInterval.Low)
            {
                if (root.LeftMeeting == null)
                {
                    return true;
                }
                else
                {
                    return PrivateCheckAvailability(root.LeftMeeting, interval);
                }
            }
            else if (interval.MeetingInterval.Low >= root.Meeting.MeetingInterval.High)
            {
                if (root.RightMeeting == null)
                {
                    return true;
                }
                else
                {
                    return PrivateCheckAvailability(root.RightMeeting, interval);
                }
            }
            else
            {
                return false;
                /*     root 10 , 20
                //     interval low less than 20 
                //          or
                //     interval high is greater than 10
                // 7 9|10 goes to left
                // 11, 25 overlap with root
                // 11, 19 overlap with root
                // 8,15 overlap with root
                // 20|21, 25 goes to right
                */
            }
        }

       // to do , similar to bst deletion
        public bool Delete()
        {
            return false;
        }
    }

    public class MeetingRoom
    {
        private Dictionary<string, MeetingRoomTimeLine> dailyScheduledMeetings;

        public int Size { get; private set; }

        public string MeetingRoomId { get; private set; }

        public MeetingRoom(string roomId, int size)
        {
            this.Size = size;
            this.MeetingRoomId = roomId;
            this.dailyScheduledMeetings = new Dictionary<string, MeetingRoomTimeLine>();
        }

        /// <summary>
        /// to do: this can be called daily to clear data in the past to keep the memory foot print less 
        /// </summary>
        /// <returns></returns>
        public bool Janitor()
        {
            return true;
        }

        /// <summary>
        /// handling concurrency may not be needed for reads
        /// this may not be 100% accurate, since there is always a time gap between suggession and booking
        /// this still needs to be validated during booking, so we can ignore any locking during the check
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        public Task<bool> CheckAvailability(Meeting meeting)
        {
            var flag = false;

            ////var day = GetDay(roundedFrom);

            ////if (!dailyScheduledMeetings.ContainsKey(day))
            ////{
            ////    return true;
            ////}           

            return Task.FromResult<bool>(flag);
        }
        
        /// <summary>
        /// to do: need to handle concurrency here
        /// should lock only the specific meetings days time line
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        public bool BookMeeting(Meeting meeting)
        {
            return false;
        }

    }

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
        private readonly object lockObject =new object();
       
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

        private async Task<string> PrivateCheckMeetingRoomAvailability(Meeting newMeetingRequest, string meetingRoom)
        {
            var result = await meetingRooms[meetingRoom].CheckAvailability(newMeetingRequest);

            if (result)
            {
                return meetingRoom;
            }

            return null;
        }

        private Meeting ValidateAndGetMeeting(DateTime from, DateTime to, int requestedSize, string requestorId=null)
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

           var meetingRequest =  ValidateAndGetMeeting(from, to, requestedSize, requestorId);

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

            return flag;
        }

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
