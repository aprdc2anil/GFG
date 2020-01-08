using System;

namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// 
    /// </summary>
    class Interval
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
}
