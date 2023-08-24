using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Interface.MyCollection
{
    public class MyOneWayLinkedListNode<T>
    {
        public MyOneWayLinkedListNode<T>? Next { get; set; }
        public T Item { get; set; }

        public MyOneWayLinkedListNode(T item)
        {
            Item = item;
        }
        public MyOneWayLinkedListNode(MyOneWayLinkedListNode<T> next, T item)
        {
            Next = next;
            Item = item;
        }        
    }
}
