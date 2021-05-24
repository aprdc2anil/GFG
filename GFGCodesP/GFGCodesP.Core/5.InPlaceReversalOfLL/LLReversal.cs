using System;

namespace GFGCodesP.Core
{
    public class LLReversal
    {
        public static void EntryPoint()
        {
            LLHelper.PrintLL(ReverseLLKNodesAlternativelyNonRecursive(GetLLWithoutCycle(), 2));
            Console.ReadLine();
        }

        private static LinkedListNode GetLLWithoutCycle()
        {
            LinkedListNode root = new LinkedListNode(1, new LinkedListNode(2, new LinkedListNode(3, new LinkedListNode(4,
                                   new LinkedListNode(5, new LinkedListNode(6, null))))));

            return root;
        }

        public static LinkedListNode ReverseLLKNodesNonRecursive(LinkedListNode root, int k)
        {
            LinkedListNode prevRoot = root;

            LinkedListNode newRoot = root;

            while (root != null)
            {

                LinkedListNode prev = null;

                LinkedListNode next = null;

                LinkedListNode rootCopy = root;

                int i = 0;

                while (root != null && i < k)
                {
                    next = root.Next;
                    root.Next = prev;
                    prev = root;
                    root = next;
                    ++i;
                }

                if (rootCopy != prevRoot)
                {
                    prevRoot.Next = prev;
                    prevRoot = rootCopy;
                }
                else
                {
                    newRoot = prev;
                }
            }

            return newRoot;
        }

        // 1 , 2, 3, 4, 5, 6, 7, 8

        // 2, 1 -> null | 3, 4 -> null | 6, 5 -> null | 7, 8

        public static LinkedListNode ReverseLLKNodesAlternativelyNonRecursive(LinkedListNode root, int k)
        {

            bool isOdd = true;

            int j = 0;

            LinkedListNode prevRoot = root;

            LinkedListNode newRoot = null;

            while (root != null)
            {
                LinkedListNode prev = null;

                LinkedListNode next = null;

                LinkedListNode rootCopy = root;

                int i = 0;

                while (root != null && i < k)
                {
                    next = root.Next;

                    if (isOdd)
                    {
                        root.Next = prev;
                    }

                    prev = root;
                    root = next;
                    ++i;
                }

                ++j;

                if (j > 1)
                {
                    if (!isOdd)
                    {
                        prevRoot.Next = rootCopy;
                        prevRoot = prev;
                    }
                    else
                    {
                        prevRoot.Next = prev;
                        prevRoot = rootCopy;

                    }
                }
                else
                {
                    newRoot = prev;
                }

                isOdd = !isOdd;

            }

            return newRoot;
        }
    }
}