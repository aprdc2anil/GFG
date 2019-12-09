using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTCommonAncestor
    {
        public static void EntryPoint()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>()
            {
                Data = 11,
                Left = new BinaryTreeNode<int>()
                {
                    Data = 5,

                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 2,
                        Left = new BinaryTreeNode<int>()
                        {
                            Data = 1
                        }
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 4,
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 3
                        }
                    }
                },

                Right = new BinaryTreeNode<int>()
                {
                    Data = 10,
                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 7,
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 6
                        }
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 9,
                        Left = new BinaryTreeNode<int>()
                        {
                            Data = 8
                        }
                    }
                }
            };

            BinaryTreeHelpers<int>.Print(root);
            var ancestor = AncestorNonRecursive(root, 8, 6, 11);

            if (ancestor != null)
                Console.WriteLine(ancestor.Data);

            Console.ReadLine();
        }
       
        public static BinaryTreeNode<int> AncestorRecursive(BinaryTreeNode<int> head, int a, int b)
        {
            // assumes a and b present in the tree
            if (head == null)
                return null;

            if (head.Data == a || head.Data == b)
                return head;

            var left = AncestorRecursive(head.Left, a, b);
            var right = AncestorRecursive(head.Right, a, b);

            if (left != null && right != null)
            {
                return head;
            }

            if (left != null)
                return left;
            else
                return right;
        }


        public static BinaryTreeNode<int> AncestorNonRecursive(BinaryTreeNode<int> head, int a, int b, int n)
        {
            // assumes a and b present in the tree
            if (head == null)
                return null;

            int aIndex = 0, bIndex = 0;
            BinaryTreeNode<int>[] aPath = new BinaryTreeNode<int>[n];
            BinaryTreeNode<int>[] bPath = new BinaryTreeNode<int>[n];

            aIndex = GetAncestorsPath(head, a, aPath);
            bIndex = GetAncestorsPath(head, b, bPath);

            if (aIndex != -1 && bIndex != -1)
            {
                int tempIndex = 0;
                BinaryTreeNode<int> lca = null;

                while (aPath[tempIndex]==bPath[tempIndex])
                {
                    ++tempIndex;
                }

                return aPath[tempIndex-1];
            }

            return null;

        }

        private static int GetAncestorsPath(BinaryTreeNode<int> head, int a, BinaryTreeNode<int>[] aPath)
        {
            int index = 0;
            Stack<BinaryTreeNode<int>> s = new Stack<BinaryTreeNode<int>>();

            while (true)
            {
                if (head != null)
                {
                    aPath[index] = head;
                    if (head.Data == a)
                    {
                        break;
                    }
                    s.Push(head);
                    head = head.Left;
                    if (head != null)
                        index++;
                }
                else
                {
                    if (s.Count > 0)
                    {
                        head = s.Pop();
                        while (index > 0 && aPath[index] != head)
                        {
                            aPath[index] = null;
                            --index;
                        }

                        head = head.Right;
                        if (head != null)
                            ++index;
                    }
                    else
                    {
                        index = -1;
                        break;
                    }
                }
            }

            return index;
        }
    }
}
