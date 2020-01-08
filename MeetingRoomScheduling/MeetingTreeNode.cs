namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// 
    /// </summary>
    class MeetingTreeNode
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
}
