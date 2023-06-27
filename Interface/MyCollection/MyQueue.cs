using Interface.InterfaceCollection;
using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    internal class MyQueue<T> : IMyCollection<T>
    {
        public int Count { get { return _arr.Count; } }

        private readonly MyList<T> _arr;
        public MyQueue()
        {
            _arr = new MyList<T>();
        }
        public void Enqueue(T obj) => _arr.Add(obj);

        public T Dequeue()
        {
            if (_arr.Count > 0)
            {
                T obj = _arr[0];
                _arr.RemoveAt(0);
                return obj;
            }
            return default;
        }

        public T Peek()
        {
            if (_arr.Count > 0) return _arr[_arr.Count - 1];
            return default;
        }

        public bool Contains(T? item) => _arr.Contains(item);

        public T[] ToArray() => _arr.ToArray();

        public void Clear() => _arr.Clear();

        public IEnumerator<T> GetEnumerator() => _arr.GetEnumerator();


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
