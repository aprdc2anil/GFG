using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTMirror
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
            BinaryTreeHelpers<int>.Print(MirrorNonRecursive(root));
            
            Console.ReadLine();
        }
        
        public static BinaryTreeNode<int> MirrorRecursive(BinaryTreeNode<int> head)
        {
            if (head == null)
                return null;

            var temp = head.Left;
            head.Left = MirrorRecursive(head.Right);
            head.Right= MirrorRecursive(temp);
            return head;          
        }

        public static BinaryTreeNode<int> MirrorNonRecursive(BinaryTreeNode<int> root)
        {
            if (root == null)
                return null;

            var preOrderStack = new Stack<BinaryTreeNode<int>>();
            preOrderStack.Push(root);

            while (preOrderStack.Count > 0)
            {
                var head = preOrderStack.Pop();
                var temp = head.Left;
                head.Left = head.Right;
                head.Right = temp;

                if (head.Left != null)
                {
                    preOrderStack.Push(head.Left);
                }
                if (head.Right != null)
                {
                    preOrderStack.Push(head.Right);
                }
            }

            return root;
        }

    }
}
