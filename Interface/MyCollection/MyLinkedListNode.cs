using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    public sealed class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T>? Next { get; set; }
        public MyLinkedListNode<T>? Preveouse { get; set; }
        public T Item { get; private set; }

        public MyLinkedListNode(T item)
        {
            Item = item;
        }
        public MyLinkedListNode(MyLinkedListNode<T> preveouse, T item)
        {
            Preveouse = preveouse;
            Item = item;
        }
        public MyLinkedListNode(MyLinkedListNode<T> preveouse, MyLinkedListNode<T> next, T item)
        {
            Next = next;
            Preveouse = preveouse;
            Item = item;
        }

    }
}
