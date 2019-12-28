using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTTreeDepthOfANode
    {
        public static void EntryPoint()
        {
            var depthNode = new BinaryTreeNode<int>()
            {
                Data = 976,
                Right = new BinaryTreeNode<int>() { Data = 776 }
            };

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
                            Right = depthNode
                        }
                    }
                }
            };

            BinaryTreeHelpers<int>.Print(root);

            //bool isFound = false;

            int depth = DepthOfANodeNonRecursive(root, 123);
            Console.WriteLine("Depth is : {0}", depth);
            
            Console.ReadLine();
        }
        
        public static int DepthOfANode(BinaryTreeNode<int> head, BinaryTreeNode<int> depthNode, ref bool isFound)
        {
            if (head == null || depthNode == null)
            {
                isFound = false;
                return -1;
            }

            if (head.Left == null && head.Right == null)
            {
                isFound = false;
                return -1;
            }

            if (head == depthNode)
            {
                isFound = true;
                return 0;
            }
         
            int depth = DepthOfANode(head.Left, depthNode, ref isFound);
            if (isFound)
            {
                return 1 + depth;
            }

            depth = DepthOfANode(head.Right, depthNode, ref isFound);
            if (isFound)
            {
                return 1 + depth;
            }

            return -1;

        }

        public static int DepthOfAnElement(BinaryTreeNode<int> head, int element, ref bool isFound)
        {
            if (head == null)
            {
                isFound = false;
                return -1;
            }

            if (head.Left == null && head.Right == null)
            {
                isFound = false;
                return -1;
            }

            if (head.Data == element)
            {
                isFound = true;
                return 0;
            }

            int depth = DepthOfAnElement(head.Left, element, ref isFound);
            if (isFound)
            {
                return 1 + depth;
            }

            depth = DepthOfAnElement(head.Right, element, ref isFound);
            if (isFound)
            {
                return 1 + depth;
            }

            return -1;

        }
               
        public static int DepthOfANodeNonRecursive(BinaryTreeNode<int> head, BinaryTreeNode<int> depthNode)
        {
            if (head == null)
                return -1;

            Queue<BinaryTreeNode<int>> q = new Queue<BinaryTreeNode<int>>();
            q.Enqueue(head);
            q.Enqueue(null);
            int depth = 0;

            while (q.Count>0)
            {
                head = q.Dequeue();
                if (head != null)
                {
                    if (head == depthNode)
                    {
                        return depth;
                    }

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
                        ++depth;
                    }
                }
            }

            return depth;
        }
        
        public static int DepthOfANodeNonRecursive(BinaryTreeNode<int> head, int element)
        {
            if (head == null)
                return -1;

            Queue<BinaryTreeNode<int>> q = new Queue<BinaryTreeNode<int>>();
            q.Enqueue(head);
            q.Enqueue(null);
            int depth = 0;

            while (q.Count > 0)
            {
                head = q.Dequeue();
                if (head != null)
                {
                    if (head.Data == element)
                    {
                        return depth;
                    }

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
                        ++depth;
                    }
                }
            }

            return depth;
        }
    }
}
