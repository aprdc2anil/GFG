namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// 
    /// </summary>
    class Meeting
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
            this.MeetingRequestorId = meetingRequestorId ?? string.Empty;
        }
    }
}
