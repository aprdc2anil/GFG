using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class BTDFSInOrder
    {
        public static void EntryPoint()
        {
            BinaryTreeNode root = GetBinaryTree();
            InOrderTraversal(root);
            Console.ReadLine();
        }

        private static BinaryTreeNode GetBinaryTree()
        {
            BinaryTreeNode root = new BinaryTreeNode(8, new BinaryTreeNode(4, new BinaryTreeNode(2, new BinaryTreeNode(1), new BinaryTreeNode(3)),
            new BinaryTreeNode(6, new BinaryTreeNode(5), new BinaryTreeNode(7))),
            new BinaryTreeNode(12, new BinaryTreeNode(10, new BinaryTreeNode(9), new BinaryTreeNode(11)),
            new BinaryTreeNode(14, new BinaryTreeNode(13), new BinaryTreeNode(15))));
            return root;
        }

        private static void InOrderTraversal(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();

            while (true)
            {
                while (root != null)
                {
                    inorderStack.Push(root);
                    root = root.Left;
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();
                    Console.Write("{0} ", root.Data);
                    root = root.Right;
                }
                else
                {
                    break;
                }
            }
        }
    }
}