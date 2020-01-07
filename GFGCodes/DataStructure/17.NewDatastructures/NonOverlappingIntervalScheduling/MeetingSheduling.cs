using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    /// <summary>
    /// 
    /// </summary>
    public class Interval
    {
        public int Low { get; set; }
        public int High { get; set; }

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

    /// <summary>
    /// 
    /// </summary>
    public class BinarySearchIntervalTreeNode
    {
        public BinarySearchIntervalTreeNode LeftNode { get; set; }
        public BinarySearchIntervalTreeNode RightNode { get; set; }
        public Interval NodeInterval { get; set; }      
       
        public BinarySearchIntervalTreeNode(Interval interval)
        {
            this.NodeInterval = interval;
            LeftNode = RightNode = null;
        }
    }

    public class BinarySearchIntervalTree
    {
        private BinarySearchIntervalTreeNode root;

        // to do
        public bool Add(Interval interval)
        {
            if (root == null)
            {
                root = new BinarySearchIntervalTreeNode(interval);
                return true;
            }
            else
            {
               return PrivateAdd(root, interval);
            }
        }

        private bool PrivateAdd(BinarySearchIntervalTreeNode root, Interval interval)
        {
            if (interval.High <= root.NodeInterval.Low)
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = new BinarySearchIntervalTreeNode(interval);
                    return true;
                }
                else
                {
                   return PrivateAdd(root.LeftNode, interval);
                }
            }
            else if (interval.Low >= root.NodeInterval.High)
            {
                if (root.RightNode == null)
                {
                    root.RightNode = new BinarySearchIntervalTreeNode(interval);
                    return true;
                }
                else
                {
                    return PrivateAdd(root.RightNode, interval);
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

        public bool CheckAvailability(Interval interval)
        {
            if (root == null)
            {
                
                return true;
            }
            return PrivateCheckAvailability(root, interval);
        }

        private bool PrivateCheckAvailability(BinarySearchIntervalTreeNode root, Interval interval)
        {
            if (interval.High <= root.NodeInterval.Low)
            {
                if (root.LeftNode == null)
                {
                    return true;
                }
                else
                {
                    return PrivateCheckAvailability(root.LeftNode, interval);
                }
            }
            else if (interval.Low >= root.NodeInterval.High)
            {
                if (root.RightNode == null)
                {
                    return true;
                }
                else
                {
                    return PrivateCheckAvailability(root.RightNode, interval);
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

    class MeetingSheduling
    {
        

    }
}
