using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// 
    /// </summary>
    class MeetingRoom
    {
        private readonly object lockObject = new object();
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

            if (dailyScheduledMeetings.ContainsKey(meeting.DayOfTheMetting))
            {
                var timeline = dailyScheduledMeetings[meeting.DayOfTheMetting];

                flag = timeline.CheckAvailability(meeting);
            }
            else
            {
                flag = true;
            }

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
            if (!dailyScheduledMeetings.ContainsKey(meeting.DayOfTheMetting))
            {
                // to do, this can be optimized
                lock (lockObject)
                {
                    if (!dailyScheduledMeetings.ContainsKey(meeting.DayOfTheMetting))
                    {
                        dailyScheduledMeetings.Add(meeting.DayOfTheMetting, new MeetingRoomTimeLine());
                    }
                }
            }

            var timeline = dailyScheduledMeetings[meeting.DayOfTheMetting];
            return timeline.BookMeetingSlot(meeting);
        }
    }
}
