using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTHasPathSum
    {
        public static void EntryPoint()
        {
            ////int[] myInts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            ////Console.WriteLine(string.Join(", ", myInts));

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

           
            bool result = PrintSumPathNonRecursiveRef(root, 153, 17);
            Console.WriteLine(result);
            
            Console.ReadLine();
        }

        public static bool HasPathSum(BinaryTreeNode<int> head, int sum)
        {
            if (head == null)
                return false;
            if (sum < 0)
                return false;

            while (head != null)
            {
                if (sum == head.Data)
                {
                    return true;
                }
                else return HasPathSum(head.Left, sum - head.Data) || HasPathSum(head.Right, sum - head.Data);
            }

            return false;
        }

        public static bool PrintPathWithSum(BinaryTreeNode<int> head, int sum)
        {
            if (head == null || sum < 0)
                return false;           
           
            if (sum == head.Data)
            {
                Console.WriteLine(head.Data);
                return true;
            }

            if (PrintPathWithSum(head.Left, sum - head.Data) || PrintPathWithSum(head.Right, sum - head.Data))
            {
                Console.WriteLine(head.Data);
                return true;
            }            

            return false;
        }

        public static bool PrintPathWithSum(BinaryTreeNode<int> head, int sum, int[] path, int index)
        {
            if (head == null || sum < 0)
                return false;

            path[index++] = head.Data;
            if (sum == head.Data && head.Left==null && head.Right==null)
            { 
                return true;
            }

            if (PrintPathWithSum(head.Left, sum - head.Data, path, index) || PrintPathWithSum(head.Right, sum - head.Data, path, index))
            {
                return true;
            }

            return false;
        }
        
        public static bool PrintSumPathNonRecursiveRef(BinaryTreeNode<int> head, int sum, int n)
        {
            if (head == null)
                return false;
            var preOrderStack = new Stack<BinaryTreeNode<int>>();
            int currSum = sum;
            int index = 0;
            BinaryTreeNode<int>[] path = new BinaryTreeNode<int>[n];

            while (true)
            {
                if (head != null)
                {
                    path[index] = head;
                    Console.WriteLine(string.Join(", ", path.Take(index + 1).Select(p => p.Data)));

                    if (currSum == head.Data && head.Left == null && head.Right == null)
                    {
                        return true;
                    }
                    else
                    {
                        currSum -= head.Data;
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

                        //// IMPORTANT LOGIC
                        while (index > 0 && path[index - 1] != null && (path[index - 1].Left != head && path[index - 1].Right != head))
                        {
                            currSum += path[index].Data;
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
