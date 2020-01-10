using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingRoomScheduling.Internal
{
    class MeetingRoomTimeLineFactory
    {
        public IMeetingRoomTimeLine GetMeetingRoomTimeLine()
        {
            return new MeetingRoomTimeLine();
        }
    }
}
