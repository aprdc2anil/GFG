using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTPathToAncestors
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

           
            bool result = PrintPathAncestorsNonRecursiveRef(root, 657, 17);
            Console.WriteLine(result);
            
            Console.ReadLine();
        }
        
        public static bool PrintPathAncestors(BinaryTreeNode<int> head, int element, int[] path, int index)
        {
            if (head == null)
                return false;

            path[index++] = head.Data;
            if (element == head.Data)
            {
                return true;
            }

            return PrintPathAncestors(head.Left, element, path, index) || PrintPathAncestors(head.Right, element, path, index);           
        }

        public static bool PrintPathAncestorsNonRecursive(BinaryTreeNode<int> head, int element, int n)
        {
            if (head == null)
                return false;
            var preOrderStack = new Stack<BinaryTreeNode<int>>();

            int index = 0;
            int[] path = new int[n];

            while (true)
            {
                if (head != null)
                {
                    path[index] = head.Data;
                   
                    if (element == head.Data)
                    {
                        Console.WriteLine(string.Join(", ", path));
                        return true;
                    }                   

                    preOrderStack.Push(head);                    

                    head = head.Left;

                    if (head != null) ++index;
                }
                else
                {
                    if (preOrderStack.Count > 0)
                    {
                        head = preOrderStack.Pop();

                        while (path[index] != head.Data)
                        {
                            path[index] = 0;
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

        public static bool PrintPathAncestorsNonRecursiveRef(BinaryTreeNode<int> head, int element, int n)
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
                    Console.WriteLine(string.Join(", ", path.Take(index+1).Select(p => p.Data)));
                    if (element == head.Data)
                    {
                       
                        return true;
                    }

                    preOrderStack.Push(head);

                    head = head.Left;

                    if (head != null) ++index;
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
