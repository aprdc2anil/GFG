using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTPrintAllPaths
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

            int[] path = new int[17];
            PrintAllPathsNonRecursive(root, 17);
            
            Console.ReadLine();
        }
        
        public static void PrintAllPaths(BinaryTreeNode<int> head, int[] path, int index)
        {
            if (head == null)
                return;

            path[index++] = head.Data;

            if(head.Left==null&&head.Right==null)
            {
                Console.WriteLine(string.Join(", ", path.Take(index)));
            }

            PrintAllPaths(head.Left, path, index);
            PrintAllPaths(head.Right, path, index);           
        }
        
        public static bool PrintAllPathsNonRecursive(BinaryTreeNode<int> head, int n)
        {
            if (head == null)
                return false;
            var preOrderStack = new Stack<BinaryTreeNode<int>>();

            int index = 0;
            BinaryTreeNode<int>[] path = new BinaryTreeNode<int>[n];

            while (true)
            {
                if (head != null)
                {
                    path[index] = head;

                    if (head.Left == null && head.Right == null)
                    {
                        Console.WriteLine(string.Join(", ", path.Take(index + 1).Select(p => p.Data)));
                        head = null;
                    }
                    else
                    {
                        preOrderStack.Push(head);

                        head = head.Left;

                        if (head != null) ++index;
                    }
                }
                else
                {
                    if (preOrderStack.Count > 0)
                    {
                        head = preOrderStack.Pop();

                        // IMPORTANT BACKTRACKING LOGIC
                        while (index> 0 && path[index-1] != null && (path[index-1].Left!=head && path[index-1].Right!=head))
                        {
                            path[index] = null;
                            --index;
                        }

                        head = head.Right;
                        if (head != null) ++index;

                    }
                    else
                    {
                        break;
                    }
                }
            }

            return false;
        }

    }
}
