using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    internal class MyOneWayLinkedList <T> : IMyCollection<T>
    {
        protected int _count = 0;
        internal MyOneWayLinkedListNode<T>? _head;
        public int Count { get { return _count; } }
        public MyOneWayLinkedListNode<T>? First { get { return _head; } }
        public MyOneWayLinkedListNode<T>? Last { get; private set; }

        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new MyOneWayLinkedListNode<T>(item);
                Last = _head;
                _count++;
            }
            else
            {
                MyOneWayLinkedListNode<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new MyOneWayLinkedListNode<T>(item);
                Last = current.Next;
                _count++;
            }
        }
        public void AddFirst(T item)
        {
            if (_head == null)
            {
                _head = new MyOneWayLinkedListNode<T>(item);
                Last = _head;
                _count++;
            }
            else
            {
                MyOneWayLinkedListNode<T> current = _head;
                _head = new MyOneWayLinkedListNode<T>(current, item);
                _count++;
            }
        }
        public void Insert(int index, T item)
        {
            if (_head == null)
            {
                _head = new MyOneWayLinkedListNode<T>(item);
                Last = _head;
                _count++;
            }
            else if (index <= Count) 
            {
                MyOneWayLinkedListNode<T> current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = new MyOneWayLinkedListNode<T>(current.Next, item);
                _count++;
            }
        }
        public bool Contains(T item)
        {
            if (_head != null)
            {
                MyOneWayLinkedListNode<T>? current = _head;
                for (int i = 0; i < Count; i++)
                {
                    if (current.item.GetHashCode() == item.GetHashCode())
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }
        public T[] ToArray()
        {
            if (_head != null)
            {
                T[] Arr = new T[Count];
                MyOneWayLinkedListNode<T>? current = _head;
                for (int i = 0; i < Count; i++)
                {
                    Arr[i] = current.item;
                    current = current.Next;
                }
                return Arr;
            }
            return default;
        }
        public void Clear()
        {
            MyOneWayLinkedListNode<T>? current = _head;
            while (current != default)
            {
                MyOneWayLinkedListNode<T> temp = current;
                current = current.Next;
                temp.Next = default;
            }
            _head = default;
            Last = default;
            _count = 0;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private readonly MyOneWayLinkedList<T> _list;
            private MyOneWayLinkedListNode<T>? _node;
            private T? _current;
            private int _index;
            internal Enumerator(MyOneWayLinkedList<T> list)
            {
                _list = list;
                _node = list._head;
                _current = default;
                _index = 0;
            }

            public T Current => _current!;

            object? IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || (_index == _list.Count + 1))
                    {
                        throw new InvalidOperationException();
                    }

                    return Current;
                }
            }

            public bool MoveNext()
            {

                if (_node == null)
                {
                    _index = _list.Count + 1;
                    return false;
                }

                ++_index;
                _current = _node.item;
                _node = _node.Next;
                if (_node == _list._head)
                {
                    _node = null;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                _current = default;
                _node = _list._head;
                _index = 0;
            }

            public void Dispose()
            {
            }
        }
    }
}
