using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTPostOrder
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
            PostOrderNonRecursive(root);
            
            Console.ReadLine();
        }
       
        public static void PostOrderNonRecursive(BinaryTreeNode<int> head)
        {
            if (head == null)
                return;

            // perform inorder traversl and see if the elements are in order
            Stack<BinaryTreeNode<int>> s = new Stack<BinaryTreeNode<int>>();

            while (true)
            {
                if (head != null)
                {
                    if (head.Right != null)
                    {
                        s.Push(head.Right);
                    }
                    s.Push(head);                   
                    head = head.Left;
                }
                else
                {
                    if(s.Count>0)
                    {
                        head = s.Pop();
                        
                        if (s.Count>0 && head.Right == s.Peek())
                        {
                            s.Pop();
                            s.Push(head);
                            head = head.Right;
                        }
                        else
                        {
                            Console.WriteLine(head.Data);
                            head = null;
                        }                        
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
