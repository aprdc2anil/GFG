using System;
using System.Threading;

namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// to do: this is currently bst, need to make it balancing bst later
    /// to do: currently locking at write can block the cpu threads, this should be optimized for more efficiency 
    /// NOTE: This is an individual timeline of a specifcific meeting room and for specific day     
    /// </summary>
    interface IMeetingRoomTimeLine: IDisposable
    {
        bool BookMeetingSlot(Meeting interval);

        bool CheckAvailability(Meeting interval);        
    }
}
