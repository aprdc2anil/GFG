using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class BTRecursive
    {
        public static void EntryPoint()
        {
            BinaryTreeNode root = GetBinaryTree();

            int depth = 0;
            int height = -1;
            int node = 15;

            int diameter = 0;

            DiameterOfATreeRecursive(root, ref diameter);

            Console.WriteLine("diameter of the tree is {0} is ", diameter);

            HeightOfANodeRecursive(root, node, ref height);

            if (height != -1)
            {
                Console.WriteLine("Height of the node {0} is {1}", node, height);
            }
            else
            {
                Console.WriteLine("Node {0} does not exist in the tree {1}", node, height);
            }

            if (DepthOfANodeRecursive(root, node, ref depth))
            {
                Console.WriteLine("Depth of the Node {0} is {1} ", node, depth);
            }
            else
            {
                Console.WriteLine("Node {0} does not exist in the tree ", node);
            }

            Console.ReadLine();
        }

        private static BinaryTreeNode GetBinaryTree()
        {
            BinaryTreeNode root = new BinaryTreeNode(8, new BinaryTreeNode(4, new BinaryTreeNode(2, new BinaryTreeNode(1), new BinaryTreeNode(3)),
            new BinaryTreeNode(6, new BinaryTreeNode(5), new BinaryTreeNode(7))),
            new BinaryTreeNode(12, new BinaryTreeNode(10, new BinaryTreeNode(9, new BinaryTreeNode(-2, new BinaryTreeNode(-3, new BinaryTreeNode(-4, new BinaryTreeNode(-5), null), null), null), null), new BinaryTreeNode(11)),
            new BinaryTreeNode(14, new BinaryTreeNode(13), new BinaryTreeNode(15, new BinaryTreeNode(18, null, new BinaryTreeNode(19, new BinaryTreeNode(20), null)), null))));
            return root;
        }

        private static int HeightOfTreeRecursive(BinaryTreeNode root)
        {
            if (root == null || (root.Left == null && root.Right == null))
                return 0;

            return 1 + Math.Max(HeightOfTreeRecursive(root.Left), HeightOfTreeRecursive(root.Right));
        }

        private static bool DepthOfANodeRecursive(BinaryTreeNode root, int data, ref int depth)
        {
            if (root == null)
                return false;
            else if (root.Data == data)
                return true;
            else if (root.Left == null && root.Right == null)
                return false;
            else
            {
                int left = 0; int right = 0;
                if (DepthOfANodeRecursive(root.Left, data, ref left) || DepthOfANodeRecursive(root.Right, data, ref right))
                {
                    depth = 1 + Math.Max(left, right);
                    return true;
                }

                return false;
            }
        }

        private static int HeightOfANodeRecursive(BinaryTreeNode root, int data, ref int height)
        {
            if (root == null)
                return 0;

            if (root.Left == null && root.Right == null)
            {
                if (root.Data == data)
                {
                    height = 0;
                }

                return 0;
            }

            int h = 1 + Math.Max(HeightOfANodeRecursive(root.Left, data, ref height), HeightOfANodeRecursive(root.Right, data, ref height));

            if (root.Data == data)
            {
                height = h;
            }

            return h;
        }


        private static int DiameterOfATreeRecursive(BinaryTreeNode root, ref int diameter)
        {
            if (root == null)
                return 0;

            int leftHeight = DiameterOfATreeRecursive(root.Left, ref diameter);
            int rightHeight = DiameterOfATreeRecursive(root.Right, ref diameter);

            int h = 1 + Math.Max(leftHeight, rightHeight);

            if (leftHeight > 0 && rightHeight > 0)
            {
                diameter = Math.Max(diameter, 1 + leftHeight + rightHeight);
            }

            return h;
        }
    }
}
