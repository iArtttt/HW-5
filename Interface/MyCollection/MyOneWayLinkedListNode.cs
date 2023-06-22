using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Interface.MyCollection
{
    internal class MyOneWayLinkedListNode<T>
    {
        public MyOneWayLinkedListNode<T>? Next { get; set; }
        internal T item;

        public MyOneWayLinkedListNode(T item)
        {
            this.item = item;
        }
        public MyOneWayLinkedListNode(MyOneWayLinkedListNode<T> next, T item)
        {
            Next = next;
            this.item = item;
        }        
    }
}
