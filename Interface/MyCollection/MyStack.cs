using System;
using System.Collections.Generic;
using Interface.InterfaceCollectionGeneric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Interface.MyCollection
{
    public class MyStack<T> : IMyCollection<T>
    {
        public int Count { get { return _arr.Count; } }

        private readonly MyList<T> _arr;
        public MyStack()
        {
            _arr = new MyList<T>();
        }
        public void Push(T obj) => _arr.Add(obj);

        public T Pop()
        {
            if (_arr.Count > 0)
            {
                T item = _arr[_arr.Count - 1];
                _arr.RemoveAt(_arr.Count - 1);
                return item;
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

        public IEnumerator<T> GetEnumerator()
        {
            return _arr.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
