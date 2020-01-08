namespace MeetingRoomScheduling.Internal
{
    /// <summary>
    /// to do: this is currently bst, need to make it balancing bst later
    /// to do: currently locking at write can block the cpu threads, this should be optimized for more efficiency 
    /// NOTE: This is an individual timeline of a specifcific meeting room and for specific day     
    /// </summary>
    class MeetingRoomTimeLine
    {
        private MeetingTreeNode root;
        private readonly object lockObject = new object();

        // to do
        public bool BookMeetingSlot(Meeting interval)
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
}
