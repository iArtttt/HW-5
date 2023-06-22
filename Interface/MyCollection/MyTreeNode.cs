using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    internal class MyTreeNode<T>
    {
        public MyTreeNode<T>? Left;
        public MyTreeNode<T>? Right;
        public T Item { get; private set; }
        
        public MyTreeNode(T item)
        {
            Item = item;
        }
    }
}
