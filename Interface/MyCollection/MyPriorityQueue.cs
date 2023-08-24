using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    public class MyPriorityQueue<T> : IMyCollection<T>
    {
        public int Count => _arr.Count;

        private readonly MyList<T> _arr;
        private readonly IComparer<T>? _priority = null;
        public MyPriorityQueue()
        {
            _arr = new MyList<T>();
        }
        public MyPriorityQueue(IComparer<T>? priority)
        {
            _arr = new MyList<T>();
            _priority = priority;
        }

        public void Enqueue(T item)
        {
            if (_priority == null)
            {
                _arr.Add(item);
                _arr.Sort();
            }
            else
            {
                _arr.Add(item);
                _arr.Sort(_priority);
            }
        } 

        public T Dequeue()
        {
            if (_arr.Count > 0)
            {
                T item = _arr[0];
                _arr.RemoveAt(0);
                return item;
            }
            return default;
        }

        public T Peek()
        {
            if (_arr.Count > 0) return _arr[_arr.Count - 1];
            return default;
        }


        public bool Contains(T? value) => _arr.Contains(value);

        public IEnumerator<T> GetEnumerator() => _arr.GetEnumerator();

        public void Clear() => _arr.Clear();

        public T[] ToArray() => _arr.ToArray();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class Iterator<T> : IEnumerator<T>
        {
            private readonly MyList<T> _list;
            private int _index;
            private T? _current;

            public Iterator(MyList<T> list)
            {
                _list = list;
                _index = 0;
            }

            public T Current => _current;

            object IEnumerator.Current => Current;


            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
                _current = default;
            }
        }
    }
}
