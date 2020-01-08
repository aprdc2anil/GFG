using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        public Interval MeetingInterval { get; private set; }

        public int MeetingSizeRequested { get; private set; }

        public string MeetingRequestorId { get; private set; }

        public Meeting(string meetingRequestorId, Interval meetingInterval, int meetingSizeRequested, int meetingRoomId)
        {
            this.MeetingRequestorId = meetingRequestorId;
            this.MeetingInterval = meetingInterval;
            this.MeetingSizeRequested = MeetingSizeRequested;
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
        /// handling concurrency may not be needed for reads
        /// this may not be 100% accurate, since there is always a time gap between suggession and booking
        /// this still needs to be validated during booking, so we can ignore during the check
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool CheckAvailability(DateTime from, DateTime to)
        {

            return false;
        }

        /// <summary>
        /// to do: need to handle concurrency here
        /// should lock only the specific meetings days time line
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool BookMeeting(DateTime from, DateTime to)
        {
            return false;
        }
    }

    public class MeetingShedulingManager
    {
        private SortedSet<int> availableSizes;
        private SortedDictionary<int, List<MeetingRoom>> meetingRoomsBySize;

        public MeetingShedulingManager()
        {
            this.availableSizes = new SortedSet<int>();
            this.meetingRoomsBySize = new SortedDictionary<int, List<MeetingRoom>>();
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="all"> if true provide for till booked, else for the current date</param>
       /// <returns></returns>
        public double GetResourceEfficiency(bool all = false)
        {
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="requestedSize"></param>
        /// <returns></returns>
        public List<string> CheckAvailability(DateTime from, DateTime to, int requestedSize)
        {
            return new List<string>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="requestedSize"></param>
        /// <param name="meetingId"></param>
        /// <param name="requestorId"></param>
        /// <returns></returns>
        public bool BookMeeting(DateTime from, DateTime to, int requestedSize, string meetingId, string requestorId)
        {
            return false;
        }

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

            // to do: since this is an admin operation, no need to check for concurrency for now
            MeetingRoom newRoom = new MeetingRoom(id, roomSize);

            if (meetingRoomsBySize.ContainsKey(roomSize))
            {
                meetingRoomsBySize[roomSize].Add(newRoom);
                return true;
            }
            else
            {
                if (availableSizes.Add(roomSize))
                {
                    return meetingRoomsBySize.TryAdd(roomSize, new List<MeetingRoom>() { newRoom });
                }
                else
                {
                    return false;
                }
            }           
        }

        /// <summary>
        /// add any specific validations here
        /// </summary>
        /// <param name="meetingSize"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidateMeetingRoom(int meetingSize, string id)
        {
            return true;
        }

    }
}
