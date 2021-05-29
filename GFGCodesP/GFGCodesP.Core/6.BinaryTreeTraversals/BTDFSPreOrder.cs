using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class BTDFSPreOrder
    {
        public static void EntryPoint()
        {
            BinaryTreeNode root = GetBinaryTree();
            PreOrderTraversalFindDepth(root, 12);
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

        private static void PreOrderTraversal(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();

            while (true)
            {
                while (root != null)
                {
                    Console.Write("{0} ", root.Data);
                    inorderStack.Push(root);
                    root = root.Left;
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();
                    root = root.Right;
                }
                else
                {
                    break;
                }
            }
        }


        private static void PreOrderTraversalCheckPathSum(BinaryTreeNode root, int s)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();
            List<BinaryTreeNode> btList = new List<BinaryTreeNode>();

            int sum = 0;
            while (true)
            {
                while (root != null)
                {
                    // process root
                    sum += root.Data;
                    btList.Add(root);

                    if (root.Left == null && root.Right == null && sum == s)
                    {
                        Console.Write("Path with sum {0} found at leaf {1} \n with path \n ", s, root.Data);

                        foreach (var x in btList)
                        {
                            Console.Write("{0} ", x.Data);
                        }

                        Console.WriteLine("\n");
                    }

                    // process root end

                    inorderStack.Push(root);

                    root = root.Left;
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();

                    // aditional backtracking
                    while (btList[btList.Count - 1] != root)
                    {
                        sum -= btList[btList.Count - 1].Data;
                        btList.RemoveAt(btList.Count - 1);
                    }

                    if (root.Right == null)
                    {
                        sum -= root.Data;
                        btList.RemoveAt(btList.Count - 1);
                    }
                    // aditional backtracking end

                    root = root.Right;
                }
                else
                {
                    break;
                }
            }
        }


        private static void PreOrderTraversalPrintAllPathsWithSum(BinaryTreeNode root)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();
            List<BinaryTreeNode> btList = new List<BinaryTreeNode>();

            int count = 0;
            int sum = 0;
            while (true)
            {
                while (root != null)
                {
                    // process root
                    btList.Add(root);
                    sum += root.Data;

                    if (root.Left == null && root.Right == null)
                    {
                        ++count;
                        Console.Write("Path  {0} with sum {1}  \n ", count, sum);

                        foreach (var x in btList)
                        {
                            Console.Write("{0} ", x.Data);
                        }

                        Console.WriteLine("\n");
                    }

                    // process root end

                    inorderStack.Push(root);

                    root = root.Left;
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();

                    // aditional backtracking
                    while (btList[btList.Count - 1] != root)
                    {
                        sum -= btList[btList.Count - 1].Data;
                        btList.RemoveAt(btList.Count - 1);
                    }

                    if (root.Right == null)
                    {
                        sum -= btList[btList.Count - 1].Data;
                        btList.RemoveAt(btList.Count - 1);
                    }
                    // aditional backtracking end

                    root = root.Right;
                }
                else
                {
                    break;
                }
            }
        }

        private static void PreOrderTraversalCheckPthExists(BinaryTreeNode root, List<int> path)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();
            List<BinaryTreeNode> btList = new List<BinaryTreeNode>();

            while (true)
            {
                while (root != null)
                {
                    // process root 
                    if (path.Count > btList.Count && root.Data == path[btList.Count])
                    {

                        inorderStack.Push(root);

                        btList.Add(root);
                        if (root.Left == null && root.Right == null && btList.Count == path.Count)
                        {
                            Console.WriteLine("Path found \n");

                            foreach (var x in btList)
                            {
                                Console.Write("{0} ", x.Data);
                            }

                            Console.WriteLine("\n");

                            return;

                        }

                        root = root.Left;
                    }
                    else
                    {
                        root = null;
                    }
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();

                    // aditional backtracking
                    while (btList[btList.Count - 1] != root)
                    {
                        btList.RemoveAt(btList.Count - 1);
                    }

                    if (root.Right == null)
                    {
                        btList.RemoveAt(btList.Count - 1);
                    }

                    // aditional backtracking end
                    root = root.Right;
                }
                else
                {
                    Console.WriteLine("Following path not found \n");

                    foreach (var x in path)
                    {
                        Console.Write("{0} ", x);
                    }

                    Console.WriteLine("\n");
                    break;
                }
            }
        }

        private static void PreOrderTraversalFindPath(BinaryTreeNode root, int data)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();
            List<BinaryTreeNode> btList = new List<BinaryTreeNode>();

            while (true)
            {
                while (root != null)
                {
                    btList.Add(root);

                    if (root.Data == data)
                    {
                        Console.Write("Path with node {0} found \n with path \n ", root.Data);

                        foreach (var x in btList)
                        {
                            Console.Write("{0} ", x.Data);
                        }

                        Console.WriteLine("\n");
                    }

                    inorderStack.Push(root);

                    root = root.Left;
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();
                    while (btList[btList.Count - 1] != root)
                    {
                        btList.RemoveAt(btList.Count - 1);
                    }

                    if (root.Right == null)
                    {
                        btList.RemoveAt(btList.Count - 1);
                    }

                    root = root.Right;
                }
                else
                {
                    Console.WriteLine("\n Path not found.");
                    break;
                }
            }
        }

         private static void PreOrderTraversalFindDepth(BinaryTreeNode root, int data)
        {
            Stack<BinaryTreeNode> inorderStack = new Stack<BinaryTreeNode>();
            List<BinaryTreeNode> btList = new List<BinaryTreeNode>();

            int depth = 0;

            while (true)
            {
                while (root != null)
                {
                    btList.Add(root);
                    ++depth;

                    if (root.Data == data)
                    {
                        Console.Write("Path with node {0} found \n with depth {1} path \n ", root.Data, depth-1);

                        foreach (var x in btList)
                        {
                            Console.Write("{0} ", x.Data);
                        }

                        Console.WriteLine("\n");

                        return;
                    }

                    inorderStack.Push(root);

                    root = root.Left;
                }

                if (inorderStack.Count > 0)
                {
                    root = inorderStack.Pop();
                    while (btList[btList.Count - 1] != root)
                    {
                        btList.RemoveAt(btList.Count - 1);
                        --depth;
                    }

                    if (root.Right == null)
                    {
                        btList.RemoveAt(btList.Count - 1);
                        --depth;
                    }

                    root = root.Right;
                }
                else
                {
                    Console.WriteLine("\n Path not found.");
                    break;
                }
            }
        }
    }
}