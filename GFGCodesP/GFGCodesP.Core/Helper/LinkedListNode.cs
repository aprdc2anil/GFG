using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class LinkedListNode
    {

        public LinkedListNode(int data, LinkedListNode next)
        {
            this.Data = data;
            this.Next = next;
        }

        public int Data {get; set;}
        public LinkedListNode Next {get; set;}
    }
}