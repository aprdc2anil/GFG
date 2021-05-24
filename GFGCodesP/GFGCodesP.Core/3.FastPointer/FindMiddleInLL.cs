using System;

namespace GFGCodesP.Core
{
    public class FindMiddleInLL
    {
        public static void EntryPoint()
        {

            PrintFindMiddleInLL(GetLLWithoutCycle());
            Console.ReadLine();
        }

        private static LinkedListNode GetLLWithoutCycle()
        {

            LinkedListNode root = new LinkedListNode(1, new LinkedListNode(2, new LinkedListNode(3,
                                  new LinkedListNode(4, new LinkedListNode(5, new LinkedListNode(6,
                                  null))))));

            return root;

        }

        private static void PrintFindMiddleInLL(LinkedListNode root)
        {
            if (root == null || root.Next == null)
            {
                Console.WriteLine("no middle");
                return;
            }

            if (root.Next.Next == null)
            {
                Console.WriteLine("middle {0}", root.Next.Data);
                return;
            }

            LinkedListNode slow = root;
            LinkedListNode fast = slow.Next;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    Console.WriteLine("cycle at {0}", slow.Data);
                    return;
                }
            }

            if(fast!=null)
            {
                // even number
                slow = slow.Next;
            }

             Console.WriteLine("middle {0}", slow.Data);
        }
    }
}