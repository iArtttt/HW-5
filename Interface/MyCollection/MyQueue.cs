using Interface.InterfaceCollection;
using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Interface.MyCollection
{
    public class MyQueue<T> : IMyCollection<T>
    {
        public int Count { get { return _size; } }

        private readonly MyList<T> _arr;
        private int _head;
        private int _size;
        public MyQueue()
        {
            _arr = new MyList<T>();
            _head = 0;
            _size = 0;
        }
        public void Enqueue(T obj)
        {
            _arr.Add(obj);
            _size++;
        }

        public T Dequeue()
        {

            if (_size > 0)
            {
                T obj = _arr[_head];
                MoveNext(ref _head);
                _size--;
                return obj;
            }
            return default;
        }

        public T Peek()
        {
            if (_arr.Count > 0) return _arr[0];
            return default;
        }

        public bool Contains(T? item) => _arr.Contains(item);

        public T[] ToArray() => _arr.ToArray();

        public void Clear()
        {
            _arr.Clear();
            _head = 0;
            _size = 0;
        }

        private void MoveNext(ref int index)
        {
            int tmp = index + 1;
            if (tmp == _arr.Count)
            {
                tmp = 0;
            }
            index = tmp;
        }
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
