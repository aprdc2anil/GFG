using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public static class LLHelper
    {

        public static bool LLCompare(LinkedListNode firstHalfStart, LinkedListNode secondHalfStart)
        {
            while (secondHalfStart != null)
            {
                if (secondHalfStart.Data != firstHalfStart.Data)
                    return false;

                secondHalfStart = secondHalfStart.Next;
                firstHalfStart = firstHalfStart.Next;

            }

            return true;
        }

        public static LinkedListNode ReverseLL(LinkedListNode root)
        {
            if (root == null || root.Next == null)
                return root;

            LinkedListNode prev = ReverseLL(root.Next);

            root.Next.Next = root;
            root.Next = null;

            return prev;
        }

        // 1 -> 2-> 3 -> 4 -> 5 -> 6

        // first = 1, prev = 2 , root = 3 | next 4
        // 1<-2 , 3 -> 4 -> 5 -> 6
        // first = 1, prev = 3 , root = 4 
        // 1<-2<-3, 4 -> 5 -> 6

        public static LinkedListNode ReverseLLNonRecursive(LinkedListNode root)
        {
            LinkedListNode prev = null;
            
            LinkedListNode next = null;
            
            while(root!=null)
            {
                next = root.Next;
                root.Next = prev;
                prev = root;
                root = next;

            }
            
            return prev;
        }

        public static void PrintLL(LinkedListNode root)
        {
            while (root != null)
            {
                Console.Write("{0} ", root.Data);
                root = root.Next;
            }

            Console.WriteLine();
        }
    }
}
