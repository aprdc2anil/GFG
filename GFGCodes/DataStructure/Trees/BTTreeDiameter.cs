using GFGCodes.DataStructure.Helpers;
using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes.DataStructure
{
    public class BTTreeDiameter
    {
        public static void EntryPoint()
        {

            BinaryTreeNodeHeight<int> root = new BinaryTreeNodeHeight<int>()
            {
                Data = 11,
                Left = new BinaryTreeNodeHeight<int>()
                {
                    Data = 5,

                    Left = new BinaryTreeNodeHeight<int>()
                    {
                        Data = 2,
                        Left = new BinaryTreeNodeHeight<int>()
                        {
                            Data = 1,
                            Left = new BinaryTreeNodeHeight<int>()
                            {
                                Data = 12,
                                Right = new BinaryTreeNodeHeight<int>()
                                {
                                    Data = 15
                                }
                            }
                        }
                    },
                    Right = new BinaryTreeNodeHeight<int>()
                    {
                        Data = 4,
                        Right = new BinaryTreeNodeHeight<int>()
                        {
                            Data = 3,
                            Right = new BinaryTreeNodeHeight<int>()
                            {
                                Data = 121,
                                Left = new BinaryTreeNodeHeight<int>()
                                {
                                    Data = 151,
                                    Left = new BinaryTreeNodeHeight<int>()
                                    {
                                        Data = 153
                                    }
                                }
                            }
                        }
                    }
                },

                Right = new BinaryTreeNodeHeight<int>()
                {
                    Data = 10,
                    Left = new BinaryTreeNodeHeight<int>()
                    {
                        Data = 7
                    },
                    Right = new BinaryTreeNodeHeight<int>()
                    {
                        Data = 9
                    }
                }
            };

            BinaryTreeHelpers<int>.Print(root);

            int diameter = 0;
            int height = DiameterRecursive(root, ref diameter);
            Console.WriteLine("Height is : {0}, Diameter: {1}", height, diameter+1);

            diameter = DiameterNonRecursive(root);
            Console.WriteLine("Diameter is : {0}", diameter + 1);

            Console.ReadLine();
        }
        
        public static int DiameterRecursive(IBinaryTreeNode<int> head, ref int diameter)
        {
            if (head == null)
                return 0;

            if (head.Left == null && head.Right==null)
                return 0;

            int leftHeight = DiameterRecursive(head.Left, ref diameter);
            int rightHeight = DiameterRecursive(head.Right, ref diameter);

            int tempDiameter = 1 + leftHeight + rightHeight;

            if (tempDiameter > diameter)
            {
                diameter = tempDiameter;
            }

            return 1 + Math.Max(leftHeight, rightHeight);    
        }

        public static int DiameterNonRecursive(BinaryTreeNodeHeight<int> head)
        {
            if (head == null)
                return 0;

            int diameter = 0;

            // do post order traversal
            Stack<BinaryTreeNodeHeight<int>> s = new Stack<BinaryTreeNodeHeight<int>>();

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
                    if (s.Count > 0)
                    {
                        head = s.Pop();

                        if (s.Count > 0 && head.Right == s.Peek())
                        {
                            s.Pop();
                            s.Push(head);
                            head = head.Right;
                        }
                        else
                        {
                            Console.WriteLine(head.Data);
                            
                            int leftHeight = head.Left != null ? head.Left.Height : 0;
                            int rightHeight = head.Right != null ? head.Right.Height : 0;

                            if (head.Left != null || head.Right != null)
                            {
                                head.Height = 1 + Math.Max(leftHeight, rightHeight);

                                int diam = 1 + leftHeight + rightHeight;

                                if (diam > diameter)
                                    diameter = diam;
                            }

                            head = null;
                        }
                    }
                    else
                    {
                        return diameter;
                    }
                }
            }
        }

    }
}
