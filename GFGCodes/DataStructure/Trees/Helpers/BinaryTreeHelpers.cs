using GFGCodes.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes.DataStructure.Helpers
{
    public enum NodePosition
    {
        left,
        right,
        center
    }
    public static class BinaryTreeHelpers<T>
    {
        public static IBinaryTreeNode<T> Generate(T[] array)
        {
            IBinaryTreeNode<T> root, temp;
            temp = root = new BinaryTreeNode<T>(array[0]);
            Queue<IBinaryTreeNode<T>> tempStack = new Queue<IBinaryTreeNode<T>>();

            Random r = new Random();

            int i = 1;
            while (i < array.Length)
            {
                if (i == 1)
                {
                    temp.Left = new BinaryTreeNode<T>(array[i]);
                    tempStack.Enqueue(temp.Left);
                    ++i;
                }
                else if (i == 2)
                {
                    temp.Right = new BinaryTreeNode<T>(array[i]);
                    tempStack.Enqueue(temp.Right);
                    ++i;
                }
                else if (temp.Right == null && r.Next(2, 9) % 2 == 0)
                {
                    temp.Right = new BinaryTreeNode<T>(array[i]);
                    tempStack.Enqueue(temp.Right);
                    ++i;
                }               
                else if (temp.Left == null && r.Next(2, 9) % 2 == 0)
                {
                    temp.Left = new BinaryTreeNode<T>(array[i]);
                    tempStack.Enqueue(temp.Left);
                    ++i;
                }
                else if (tempStack.Count > 0)
                {
                    temp = tempStack.Dequeue();
                }
            }

            return root;
            
        }

        public static void Print(IBinaryTreeNode<T> root)
        {
            PrintPretty(root, "", NodePosition.center, true, false);
        }

        private static void PrintPretty(IBinaryTreeNode<T> root, string indent, NodePosition nodePosition, bool last, bool empty)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }

            var stringValue = empty ? "-" : root.Data.ToString();
            PrintValue(stringValue, nodePosition);

            if (!empty && (root.Left != null || root.Right != null))
            {
                if (root.Left != null)
                    PrintPretty(root.Left, indent, NodePosition.left, false, false);
                else
                    PrintPretty(root, indent, NodePosition.left, false, true);

                if (root.Right != null)
                    PrintPretty(root.Right, indent, NodePosition.right, true, false);
                else
                    PrintPretty(root, indent, NodePosition.right, true, true);
            }
        }

        private static void PrintValue(string value, NodePosition nodePostion)
        {
            switch (nodePostion)
            {
                case NodePosition.left:
                    PrintLeftValue(value);
                    break;
                case NodePosition.right:
                    PrintRightValue(value);
                    break;
                case NodePosition.center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }


        private static void PrintLeftValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void PrintRightValue(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
        

       







        
    




