using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes.Nodes
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }
      
        public SinglyLinkedListNode(): this(default(T), null)
        {
        }

        public SinglyLinkedListNode(T data) : this(data, null)
        {
        }

        public SinglyLinkedListNode(T data, SinglyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Next = next;
        }

    }
}
