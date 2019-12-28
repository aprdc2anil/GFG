using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTTreeHeights
    {
        public static void EntryPoint()
        {
   
            BinaryTreeNode<int> root = new BinaryTreeNode<int>()
            {
                Data = 10,
                Left = new BinaryTreeNode<int>()
                {
                    Data = 15,
                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 12,
                        Left = new BinaryTreeNode<int>() { Data = 1231 },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 1252,
                            Right = new BinaryTreeNode<int>()
                            {
                                Data = 1293,
                            }
                        }
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 5,
                        Left = new BinaryTreeNode<int>() { Data = 123 },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 125,
                            Right = new BinaryTreeNode<int>()
                            {
                                Data = 129,
                            }
                        }

                    }
                },
                Right = new BinaryTreeNode<int>()
                {
                    Data = 9,
                    Left = new BinaryTreeNode<int>() { Data = 8 },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 13,
                        Left = new BinaryTreeNode<int>() { Data = 89 },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 456,
                            Left = new BinaryTreeNode<int>() { Data = 657 },
                            Right = new BinaryTreeNode<int>() { Data = 976 }
                        }
                    }
                }
            };

            BinaryTreeHelpers<int>.Print(root);
            Console.WriteLine("Height is : {0}", HeightNonRecursive(root, 9));
            
            Console.ReadLine();
        }
        
        public static int HeightRecursive(BinaryTreeNode<int> head)
        {
            if (head == null)
                return 0;

            if (head.Left == null && head.Right==null)
                return 0;

            return 1 + Math.Max(HeightRecursive(head.Left), HeightRecursive(head.Right));      
        }

        public static int HeightNonRecursive(BinaryTreeNode<int> head)
        {
            if (head == null)
                return 0;

            if (head.Left == null && head.Right == null)
                return 0;

            Queue<BinaryTreeNode<int>> q = new Queue<BinaryTreeNode<int>>();
            q.Enqueue(head);
            q.Enqueue(null);
            int height = 0;

            while (q.Count>0)
            {
                head = q.Dequeue();
                if (head != null)
                {
                    if (head.Left != null)
                    {
                        q.Enqueue(head.Left);
                    }
                    if (head.Right != null)
                    {
                        q.Enqueue(head.Right);
                    }
                }
                else
                {
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                        ++height;
                    }
                }
            }

            return height;
        }

        public static int HeightNonRecursive(BinaryTreeNode<int> head, int element)
        {
            var node = GetNode(head, element);
            return HeightNonRecursive(node);
        }

        public static BinaryTreeNode<int> GetNode(BinaryTreeNode<int> head, int element)
        {
            Stack<BinaryTreeNode<int>> s = new Stack<BinaryTreeNode<int>>();

            while (true)
            {
                if (head != null)
                {
                    if (head.Data == element)
                        return head;
                    if (head.Right != null)
                        s.Push(head.Right);
                    head = head.Left;
                }
                else
                {
                    if (s.Count > 0)
                    {
                        head = s.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return null;
        }
    }
}
