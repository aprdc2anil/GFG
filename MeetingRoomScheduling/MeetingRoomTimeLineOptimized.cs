using System;
using System.Threading;

namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// to do: this is currently bst, need to make it balancing bst later
    /// to do: currently locking at write can block the cpu threads, this should be optimized for more efficiency 
    /// NOTE: This is an individual timeline of a specifcific meeting room and for specific day     
    /// </summary>
    class MeetingRoomTimeLineOptimized : IMeetingRoomTimeLine
    {
        private volatile bool isDisposed;

        // to do
        public bool BookMeetingSlot(Meeting interval)
        {
            return false;
        }

        public bool CheckAvailability(Meeting interval)
        {
            return false;
        }
        
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MeetingRoomTimeLineOptimized()
        {
            this.Dispose(false);
        }

        private void Dispose(bool disposing = true)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                   
                }
            }

            isDisposed = true;
        }
    }
}
