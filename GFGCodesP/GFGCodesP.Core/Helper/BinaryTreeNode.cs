using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public BinaryTreeNode(int data): this(data, null, null)
        {

        }

        public int Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
    }
}