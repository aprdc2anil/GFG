using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes.Nodes
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(): this(default(T), null, null)
        {
        }

        public BinaryTreeNode(T data):this(data, null, null)
        {
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

    }
}
