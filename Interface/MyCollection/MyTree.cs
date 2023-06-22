using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    internal class MyTree<T> : IMyCollection<T> where T: IComparable<T>
    {
        private int _count = 0;
        public int Count { get { return _count; } }
        public MyTreeNode<T>? Root { get; private set; }
        public void Add(T? item)
        {
            if (item is IConvertible)
                if (Root == null)
                {
                    Root = new MyTreeNode<T>(item);
                    _count++;
                }
                else if(!Contains(item))
                {
                    SetPosition(Root, item);
                    _count++;
                }
            else { throw new Exception(); }
        }

        private MyTreeNode<T> SetPosition(MyTreeNode<T>? current, T item)
        {
            if(current == null)
                return new MyTreeNode<T>(item);
            else
            {
                if (current.Item.CompareTo(item) > 0)
                    current.Left = SetPosition(current.Left, item);
                else
                    current.Right = SetPosition(current.Right,item);
            }
            return current;
        }        
        public bool Contains(T? item) => Contains(Root, item);
        private bool Contains(MyTreeNode<T>? current, T? item)
        {
            if (current != null)
            {
                if (current.Item.Equals(item))
                    return true;
                if (current.Item.CompareTo(item) > 0)
                    return Contains(current.Left, item);
                else    
                    return Contains(current.Right, item);
            }
            return false;
        }

        public T[] ToArray()
        {
            if (Root == null)
                return null;
            int i = 0;
            T[] array = new T[Count];
            ToArray(Root, array, ref i);
            return array;

        }

        private void ToArray(MyTreeNode<T>? current, T[] ints, ref int i)
        {
            if (current != null)
            {                
                ToArray(current.Left, ints, ref i);
                ints[i++] = current.Item;
                ToArray(current.Right, ints, ref i);
            }
        }

        public void Clear()
        {
            Root = default;
            _count = 0;
        }

        public void PrintTree() => PrintTree(Root);

        private void PrintTree(MyTreeNode<T>? current)
        {
            if (current != null)
            {
                PrintTree(current.Left);
                Console.WriteLine(current.Item);
                PrintTree(current.Right);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private readonly MyTree<T> _tree;
            private MyTreeNode<T>? _node;
            private MyTreeNode<T>? _leftNode;
            private MyTreeNode<T>? _rightNode;
            private T? _current;
            private int _index;
            internal Enumerator(MyTree<T> tree)
            {
                _tree = tree;
                _node = tree.Root;
                _current = default;
                _index = 0;
            }

            public T Current => _current!;

            object? IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || (_index == _tree.Count + 1))
                    {
                        throw new InvalidOperationException();
                    }

                    return Current;
                }
            }

            public bool MoveNext()
            {
                return MoveLeftRight();
            }
            private bool MoveLeftRight()
            {
                if (_node == null || _index == _tree.Count)
                {
                    _index = _tree.Count + 1;
                    return false;
                }
                if (_node.Left == null && _node.Right == null)


                ++_index;
                _current = _node.Item;
                _node = _node.Left;
                if (_node == _tree.Root)
                {
                    _node = null;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                _current = default;
                _node = _tree.Root;
                _leftNode = null;
                _rightNode = null;
                _index = 0;
            }

            public void Dispose()
            {
            }
        }
    }
}
