using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes.Nodes
{
    public interface IBinaryTreeNode<T>
    {
        T Data { get; set; }
        IBinaryTreeNode<T> Left { get; set; }
        IBinaryTreeNode<T> Right { get; set; }
    }
    
    public class BinaryTreeNode<T>: IBinaryTreeNode<T>
    {
        public T Data { get; set; }
        IBinaryTreeNode<T> IBinaryTreeNode<T>.Left { get => this.Left; set => this.Left = new BinaryTreeNode<T>(value); }
        IBinaryTreeNode<T> IBinaryTreeNode<T>.Right { get => this.Right; set => this.Right = new BinaryTreeNode<T>(value); }

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

        public BinaryTreeNode(IBinaryTreeNode<T> head)
        {
            this.Data = head.Data;
            this.Left = new BinaryTreeNode<T>(head.Left);
            this.Right = new BinaryTreeNode<T>(head.Right);
        }
    }


    public class BinaryTreeNodeHeight<T> : IBinaryTreeNode<T>
    {
        public int Height { get; set; }
        public T Data { get; set; }
        IBinaryTreeNode<T> IBinaryTreeNode<T>.Left { get => this.Left; set => this.Left = new BinaryTreeNodeHeight<T>(value); }
        IBinaryTreeNode<T> IBinaryTreeNode<T>.Right { get => this.Right; set => this.Right = new BinaryTreeNodeHeight<T>(value); }

        public BinaryTreeNodeHeight<T> Left { get; set; }
        public BinaryTreeNodeHeight<T> Right { get; set; }

        public BinaryTreeNodeHeight() : this(default(T), null, null)
        {
        }

        public BinaryTreeNodeHeight(T data) : this(data, null, null)
        {
        }

        public BinaryTreeNodeHeight(T data, BinaryTreeNodeHeight<T> left, BinaryTreeNodeHeight<T> right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
            this.Height = 0;           
        }

        public BinaryTreeNodeHeight(IBinaryTreeNode<T> head)
        {
            this.Data = head.Data;
            this.Left = new BinaryTreeNodeHeight<T>(head.Left);
            this.Right = new BinaryTreeNodeHeight<T>(head.Right);
        }
    }
}
