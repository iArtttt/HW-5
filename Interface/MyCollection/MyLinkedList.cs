using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Interface.MyCollection
{
    internal class MyLinkedList<T> : MyOneWayLinkedList<T>
    {
        internal new MyLinkedListNode<T>? _head;
        public new MyLinkedListNode<T>? First { get { return _head; } }
        public new MyLinkedListNode<T>? Last { get; private set; }
        public MyLinkedList()
        {

        }
        public new void Add(T item)
        {
            if (_head == null)
            {
                _head = new MyLinkedListNode<T>(item);
                Last = _head;
                _count++;
            }
            else
            {
                MyLinkedListNode<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new MyLinkedListNode<T>(current, item);
                Last = current.Next;
                _count++;
            }
        }

        public new void AddFirst(T item)
        {
            if (_head == null)
            {
                _head = new MyLinkedListNode<T>(item);
                Last = _head;
                _count++;
            }
            else
            {
                MyLinkedListNode<T> current = _head;
                _head = new MyLinkedListNode<T>(default ,current , item);
                current.Preveouse = _head;
                _count++;
            }
        }

        public new void Insert(int index, T item)
        {
            if (_head == null)
            {
                _head = new MyLinkedListNode<T>(item);
                Last = _head;
                _count++;
            }
            else if (index <= Count)
            {
                MyLinkedListNode<T> current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Preveouse.Next = new MyLinkedListNode<T>(current.Preveouse, current, item);
                current.Preveouse = current.Preveouse.Next;
                _count++;
            }
        }

        public void Remove(T item)
        {
            if (_head != null)
            {
                MyLinkedListNode<T>? current = _head;
                for (int i = 0; i < Count; i++)
                {
                    if (current.Item.GetHashCode() == item.GetHashCode())
                    {
                        if (current == _head)
                            RemoveFirst();
                        else if (current == Last)
                            RemoveLast();
                        else
                        {
                            current.Preveouse.Next = current.Next.Preveouse;
                            current.Next = null;
                            current.Preveouse = null;
                            _count--;
                        }
                    }
                    current = current.Next;
                }
            }
        }
        public void RemoveFirst()
        {
            if (_head != null)
            {
                _head.Next.Preveouse = null;
                _head = _head.Next;
                _count--;
            }
        }
        public void RemoveLast()
        {
            if (_head != null)
            {
                Last.Preveouse.Next = null;
                Last = Last.Preveouse;
                _count--;
            }
        }

        public new bool Contains(T item)
        {
            if (_head != null)
            {
                MyLinkedListNode<T>? current = _head;
                for (int i = 0; i < Count; i++)
                {
                    if (current.Equals(item))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }

        public new T[] ToArray()
        {
            if (_head != null)
            {
                T[] Arr = new T[Count];
                MyLinkedListNode<T>? current = _head;
                for (int i = 0; i < Count; i++)
                {
                    Arr[i] = current.Item;
                    current = current.Next;
                }
                return Arr;
            }
            return default;
        }

        public new void Clear()
        {
            MyLinkedListNode<T>? current = _head;
            while(current != null)
            {
                MyLinkedListNode<T> temp = current;
                current = current.Next;
                temp.Next = null;
                temp.Preveouse = null;
            }
            _head = null;
            Last = null;
            _count = 0;
        }
        public override IEnumerator<T> GetEnumerator()
        {
            return new LinkedEnumerator(this);
        }
        public struct LinkedEnumerator : IEnumerator<T>, IEnumerator
        {
            private readonly MyLinkedList<T> _list;
            private MyLinkedListNode<T>? _node;
            private T? _current;
            private int _index;
            internal LinkedEnumerator(MyLinkedList<T> list)
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
                _current = _node.Item;
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
