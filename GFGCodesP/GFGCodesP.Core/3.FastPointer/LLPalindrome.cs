using System;

namespace GFGCodesP.Core
{
    public class LLPalindrome
    {
        public static void EntryPoint()
        {

            PrintLLPalindrome(GetLLWithoutCycle());
            Console.ReadLine();
        }

        private static LinkedListNode GetLLWithoutCycle()
        {

            LinkedListNode root = new LinkedListNode(1, new LinkedListNode(2, new LinkedListNode(2, new LinkedListNode(3,
                                  new LinkedListNode(3, new LinkedListNode(2, new LinkedListNode(1,
                                  null)))))));

            return root;

        }

        private static void PrintLLPalindrome(LinkedListNode root)
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

            LLHelper.PrintLL(root);

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

            LinkedListNode secondHalfStart = slow.Next;

            LLHelper.PrintLL(secondHalfStart);

            secondHalfStart = LLHelper.ReverseLLNonRecursive(secondHalfStart);

            LLHelper.PrintLL(secondHalfStart);

            if (LLHelper.LLCompare(root, secondHalfStart))
            {
                Console.WriteLine("LL is palindrome");
            }
            else{
                 Console.WriteLine("LL is not palindrome");
            }

            LLHelper.ReverseLLNonRecursive(secondHalfStart);

            Console.WriteLine("original root");

            LLHelper.PrintLL(root);
        }
    }
}