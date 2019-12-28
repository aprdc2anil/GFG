using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes
{
    public class BSTPredesseorSuccessor
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

            BinaryTreeNode<int> pred = null;
            BinaryTreeNode<int> succ = null;

            var isTrue = BSTPredesseorNon(root, 28, ref pred, ref succ);

            if (isTrue)
            {
                if (pred != null)
                    Console.WriteLine("predecessor: {0}", pred.Data);

                if (succ != null)
                    Console.WriteLine("Successor: {0}", succ.Data);
            }

            Console.ReadLine();
        }
       
        public static bool BSTPredesseor(BinaryTreeNode<int> head, int elem, ref BinaryTreeNode<int> pred, ref BinaryTreeNode<int> succ)
        {
            // assumes its a bst
            if (head == null)
                return false;

            if (head.Data == elem)
            {
                //predecessor
                if (head.Left != null)
                {
                    pred = head.Left;

                    while (pred.Right != null)
                    {
                        pred = pred.Right;
                    }
                }

                // successor
                if (head.Right!= null)
                {
                    succ = head.Right;
                    while (succ.Left != null)
                    {
                        succ = succ.Left;
                    }
                }

                return true;
            }
            else if (elem < head.Data)
            {
                succ = head;
                return BSTPredesseor(head.Left, elem, ref pred, ref succ);
            }
            else
            {
                pred = head;
                return BSTPredesseor(head.Right, elem, ref pred, ref succ);
            }
        }
        
        public static bool BSTPredesseorNon(BinaryTreeNode<int> head, int elem, ref BinaryTreeNode<int> pred, ref BinaryTreeNode<int> succ)
        {
            // assumes its a bst
            if (head == null)
                return false;
            while (head != null)
            {
                if (head.Data == elem)
                {
                    //predecessor
                    if (head.Left != null)
                    {
                        pred = head.Left;

                        while (pred.Right != null)
                        {
                            pred = pred.Right;
                        }
                    }

                    // successor
                    if (head.Right != null)
                    {
                        succ = head.Right;
                        while (succ.Left != null)
                        {
                            succ = succ.Left;
                        }
                    }

                    return true;
                }
                else if (elem < head.Data)
                {
                    succ = head;
                    head = head.Left;
                }
                else
                {
                    pred = head;
                    head = head.Right;
                }
            }

            return false;
        }
    }
}
