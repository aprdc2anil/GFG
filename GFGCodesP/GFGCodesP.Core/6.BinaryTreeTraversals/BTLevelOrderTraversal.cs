using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class BTLevelOrderTraversal
    {
        public static void EntryPoint()
        {
            BinaryTreeNode root = GetBinaryTree();
            LeftView(root);
            // Console.WriteLine("Height of the tree {0}", MinDepth(root));
            Console.ReadLine();
        }

        private static BinaryTreeNode GetBinaryTree()
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            root.Left = new BinaryTreeNode(2, null, new BinaryTreeNode(5, null, new BinaryTreeNode(11 , new BinaryTreeNode(13, null, null), null)));
            root.Right = new BinaryTreeNode(3, null, null);

            return root;
        }

        private static void LevelOrderTraversal(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();

            if (root == null)
            {
                return;
            }

            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                    Console.WriteLine("\n");
                    if (btQueue.Count > 0)
                    {
                        btQueue.Enqueue(null);
                    }

                }
                else
                {
                    Console.Write("{0} ", root.Data);
                    if (root.Left != null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                    if (root.Right != null)
                    {
                        btQueue.Enqueue(root.Right);
                    }
                }
            }
        }

        private static void LevelOrderTraversalaverages(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();

            if (root == null)
            {
                return;
            }

            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            int height = 0;
            int sum = 0;
            int count = 0;

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                    Console.WriteLine("\n averages for level {0} is {1}", height, sum / count);
                    sum = 0;
                    count = 0;
                    if (btQueue.Count > 0)
                    {
                        height++;
                        btQueue.Enqueue(null);
                    }
                }
                else
                {
                    sum += root.Data;
                    count++;
                    if (root.Left != null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                    if (root.Right != null)
                    {
                        btQueue.Enqueue(root.Right);
                    }
                }
            }
        }

        private static int MinDepth(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();

            if (root == null)
            {
                return 0;
            }

            int height = 0;
            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                    if (btQueue.Count > 0)
                    {
                        ++height;
                        btQueue.Enqueue(null);
                    }

                }
                else
                {
                    if (root.Left != null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                    if (root.Right != null)
                    {
                        btQueue.Enqueue(root.Right);
                    }

                    if (root.Left == null && root.Right == null)
                    {
                        return height;
                    }
                }
            }

            return height;
        }

        private static int GetHeight(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();

            if (root == null)
            {
                return 0;
            }

            int height = 0;
            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                    if (btQueue.Count > 0)
                    {
                        ++height;
                        btQueue.Enqueue(null);
                    }

                }
                else
                {
                    if (root.Left != null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                    if (root.Right != null)
                    {
                        btQueue.Enqueue(root.Right);
                    }
                }
            }

            return height;
        }

        private static void ReverseLevelOrderTraversal(BinaryTreeNode root)
        {
            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();
            Stack<BinaryTreeNode> btStack = new Stack<BinaryTreeNode>();

            if (root == null)
            {
                return;
            }

            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                    if (btQueue.Count > 0)
                    {
                        btQueue.Enqueue(null);
                        btStack.Push(null);
                    }

                }
                else
                {
                    // Console.Write("{0} ", root.Data);
                    btStack.Push(root);
                    if (root.Right != null)
                    {
                        btQueue.Enqueue(root.Right);
                    }
                    if (root.Left != null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                }
            }

            while (btStack.Count > 0)
            {
                root = btStack.Pop();
                if (root == null)
                {
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.Write("{0} ", root.Data);
                }
            }
        }

        private static void ZigZagLevelOrderTraversal(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> btStack = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> btStackReverse = new Stack<BinaryTreeNode>();

            if (root == null)
            {
                return;
            }

            btStack.Push(root);

            bool isReverseOrder = false;

            while (btStack.Count > 0 || btStackReverse.Count > 0)
            {
                Console.WriteLine("\n");
                if (!isReverseOrder)
                {
                    while (btStack.Count > 0)
                    {
                        root = btStack.Pop();
                        Console.Write("{0} ", root.Data);
                        if (root.Left != null)
                        {
                            btStackReverse.Push(root.Left);
                        }
                        if (root.Right != null)
                        {
                            btStackReverse.Push(root.Right);
                        }
                    }
                }
                else
                {

                    while (btStackReverse.Count > 0)
                    {
                        root = btStackReverse.Pop();
                        Console.Write("{0} ", root.Data);
                        if (root.Right != null)
                        {
                            btStack.Push(root.Right);
                        }
                        if (root.Left != null)
                        {
                            btStack.Push(root.Left);
                        }
                    }
                }

                isReverseOrder = !isReverseOrder;
            }
        }

        private static void RightView(BinaryTreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();
            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            BinaryTreeNode prev = null;

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                    Console.WriteLine(prev.Data);
                    if(btQueue.Count>0) {
                        btQueue.Enqueue(null);
                    }
                } else{
                    prev = root;
                    if(root.Left!=null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                    if(root.Right!=null)
                    {
                        btQueue.Enqueue(root.Right);
                    }
                }
            }
        }

         private static void LeftView(BinaryTreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Queue<BinaryTreeNode> btQueue = new Queue<BinaryTreeNode>();
            btQueue.Enqueue(root);

            if (root.Left != null || root.Right != null)
            {
                btQueue.Enqueue(null);
            }

            BinaryTreeNode prev = null;

            while (btQueue.Count > 0)
            {
                root = btQueue.Dequeue();

                if (root == null)
                {
                   
                    if(btQueue.Count>0) {
                        btQueue.Enqueue(null);
                    }
                } else{
                    if(prev==null)
                    {
                         Console.WriteLine(root.Data);
                    }
                    if(root.Left!=null)
                    {
                        btQueue.Enqueue(root.Left);
                    }
                    if(root.Right!=null)
                    {
                        btQueue.Enqueue(root.Right);
                    }
                }

                 prev = root;
            }
        }
    }
}