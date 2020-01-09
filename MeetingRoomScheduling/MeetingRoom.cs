using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// 
    /// </summary>
    class MeetingRoom:IDisposable
    {
        private volatile bool isDisposed = false;      
        private readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private Dictionary<string, MeetingRoomTimeLine> dailyScheduledMeetings;

        public int Size { get; private set; }

        public string MeetingRoomId { get; private set; }

        public MeetingRoom(string roomId, int size)
        {
            this.Size = size;
            this.MeetingRoomId = roomId;
            this.dailyScheduledMeetings = new Dictionary<string, MeetingRoomTimeLine>();
        }

        ~MeetingRoom()
        {
            this.Dispose(false);
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
            MeetingRoomTimeLine timeline = null;
          
            if (dailyScheduledMeetings.ContainsKey(meeting.DayOfTheMetting))
            {
                timeline = dailyScheduledMeetings[meeting.DayOfTheMetting];                    
            }           

            if (timeline != null)
            {
                timeline.CheckAvailability(meeting);
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
            try
            {
                rwLock.EnterUpgradeableReadLock();
                if (!dailyScheduledMeetings.ContainsKey(meeting.DayOfTheMetting))
                {
                    try
                    {
                        rwLock.EnterWriteLock();
                        dailyScheduledMeetings.Add(meeting.DayOfTheMetting, new MeetingRoomTimeLine());
                    }
                    finally
                    {
                        rwLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                rwLock.ExitUpgradeableReadLock();
            }

            var timeline = dailyScheduledMeetings[meeting.DayOfTheMetting];
            return timeline.BookMeetingSlot(meeting);
        }

        private void Dispose(bool disposing = true)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    dailyScheduledMeetings = null;
                }

                rwLock?.Dispose();
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
