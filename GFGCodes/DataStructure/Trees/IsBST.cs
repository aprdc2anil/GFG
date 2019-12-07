using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class IsBST
    {
        public static void EntryPoint()
        {

            BinaryTreeNode<int> root = new BinaryTreeNode<int>()
            {
                Data = 10,
                Left = new BinaryTreeNode<int>()
                {
                    Data = 5,
                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 3,
                        Left = new BinaryTreeNode<int>()
                        {
                            Data = 1,
                            Right = new BinaryTreeNode<int>()
                            {
                                Data = 2
                            }
                        },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 4
                        }
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 8,
                        Left = new BinaryTreeNode<int>()
                        {
                            Data = 6,
                            Right = new BinaryTreeNode<int>()
                            {
                                Data = 7
                            }
                        },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 9
                        }

                    }
                },
                Right = new BinaryTreeNode<int>()
                {
                    Data = 20,
                    Left = new BinaryTreeNode<int>()
                    {
                        Data = 15,
                        Left = new BinaryTreeNode<int>() { Data = 13 },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 18
                        }
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Data = 28,
                        Left = new BinaryTreeNode<int>() { Data = 26 },
                        Right = new BinaryTreeNode<int>()
                        {
                            Data = 29
                        }
                    }
                }
            };

            BinaryTreeHelpers<int>.Print(root);
            Console.WriteLine("Is BST : {0}", IsBSTNonRecursive(root));
            
            Console.ReadLine();
        }
        
        public static bool IsBSTRecursive(BinaryTreeNode<int> head)
        {
            if (head == null)
                return true;

            bool left = (head.Left == null || (head.Left.Data < head.Data && IsBSTRecursive(head.Left)));
            bool right = (head.Right == null || (head.Right.Data > head.Data && IsBSTRecursive(head.Right)));
            
            return left && right;     
        }

        public static bool IsBSTNonRecursive(BinaryTreeNode<int> head)
        {
            if (head == null)
                return true;

            // perform inorder traversl and see if the elements are in order
            Stack<BinaryTreeNode<int>> s = new Stack<BinaryTreeNode<int>>();

            while (true)
            {
                if (head != null)
                {
                    s.Push(head);
                    if(head.Left!=null && head.Left.Data>=head.Data)
                    {
                        return false;
                    }

                    head = head.Left;
                }
                else
                {
                    if(s.Count>0)
                    {
                        head = s.Pop();

                        if (head.Right != null && head.Right.Data <= head.Data)
                        {
                            return false;
                        }

                       
                        head = head.Right;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }
}
