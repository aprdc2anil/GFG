using System;

namespace GFGCodesP.Core
{
    public class FindCycleInLL
    {
        public static void EntryPoint()
        {

            PrintFindCycleInLL(GetLLWithCycle());
            Console.ReadLine();
        }

        private static LinkedListNode GetLLWithCycle()
        {

            LinkedListNode cycleNode = new LinkedListNode(5, null);

            LinkedListNode insideCycleNode = new LinkedListNode(6, new LinkedListNode(7, new LinkedListNode(8, new LinkedListNode(9, cycleNode))));

            cycleNode.Next = insideCycleNode;

            LinkedListNode root = new LinkedListNode(1, new LinkedListNode(2, new LinkedListNode(3, new LinkedListNode(4, cycleNode))));

            return root;

        }

        private static LinkedListNode GetLLWithoutCycle()
        {

            LinkedListNode root = new LinkedListNode(1, new LinkedListNode(2, new LinkedListNode(3,
                                  new LinkedListNode(4, new LinkedListNode(5, new LinkedListNode(6,
                                  new LinkedListNode(7, new LinkedListNode(8, new LinkedListNode(9, null)))))))));

            return root;

        }

        private static void PrintFindCycleInLL(LinkedListNode root)
        {
            if (root == null || root.Next == null)
            {
                Console.WriteLine("no cycle");
                return;
            }

            if (root.Next == root)
            {
                Console.WriteLine("cycle");
                return;
            }

            LinkedListNode slow = root;
            LinkedListNode fast = root.Next;

            if (slow == fast.Next)
            {
                Console.WriteLine("cycle");
                return;
            }

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

            Console.WriteLine("no cycle");
        }
    }
}