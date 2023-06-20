using System;
using System.Collections;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.InterfaceCollection;
using Interface.InterfaceCollectionGeneric;

namespace Interface
{
    internal class MyList<T> : IMyListGen<T>, IMyList
    {
        public T this[int index] 
        { 
            get 
            { 
                if ((uint)index > (uint)Count) 
                    throw new NotImplementedException();
                return _arr[index];
            }
            set 
            {
                if ((uint)index >= (uint)Count) 
                    throw new NotImplementedException();
                _arr[index] = value;
            }
        }

        private int _count = 0;

        public int Count => _count;

        private T[] _arr { get; set; }

        private int _size { get; set; } = 4;

        public int Capasity => _size;

        object? IMyList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyList()
        {
            _arr = new T[_size];
        }
        public MyList(int startCapasity)
        {
            _size = Math.Abs(startCapasity);
            _arr = new T[_size];
        }
        public void Add(T item)
        {
            if (Count + 1 > _size)
            {
                _size *= 2;
                _arr = ForEach();
            }
            _arr[_count++] = item;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
                _arr[i] = default;
            _count = 0;
        }

        public bool Contains(T? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(value))
                    return true;
            }
            return false;
        }

        public IMyEnumeratorGen<T> GetEnumerator()
        {
            return new Iterator<T>(this);
        }

        public int IndexOf(T? value)
        {
            for (int i = 0; i < Count; i++)
            {
                object obj = _arr[i];

                if (obj.GetHashCode() == value.GetHashCode())
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T? value)
        {
            if (index < Count && index >= 0)
            {
                if (Count + 1 > _size)
                {
                    _size *= 2;
                    _arr = ForEach();
                }
                T temp = _arr[index];
                for (int i = index; i < Count + 1; i++)
                {
                    temp = _arr[i];
                    _arr[i] = value;
                    value = temp;
                }
                _count++;
            }
            else { throw new IndexOutOfRangeException(); }
        }

        public void Remove(T? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_arr[i].GetHashCode() == value.GetHashCode())
                {
                    _arr[i] = default;
                    _arr = ForEach();
                    _count--;
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index < Capasity && index >= 0)
            {
                _arr[index] = default;
                _arr = ForEach();
                _count--;
            }
            else { throw new IndexOutOfRangeException(); }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            for (int i = 0; i < Count; i++)
                arr[i] = _arr[i];

            return arr;
        }
        
        public void Reverse()
        {
            int j = 0;
            T[] arr = new T[_size];
            for (int i = Count - 1; i >= 0; i--)
                arr[j++] = _arr[i];
            _arr = arr;
        }

        private T[] ForEach()
        {
            T[] arr = new T[_size];

            for (int i = 0; i < Count; i++)
            {
                if (_arr[i] != null)
                    arr[i] = _arr[i];
                else
                {
                    for (int j = i; j < Count - 1; j++)
                        arr[j] = _arr[j + 1];
                    return arr;
                }
            }

            return arr;
        }

        #region Realisated
        IMyEnumerator IMyEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IMyList.Add(object? value)
        {
            throw new NotImplementedException();
        }

        bool IMyList.Contains(object? value)
        {
            throw new NotImplementedException();
        }

        int IMyList.IndexOf(object? value)
        {
            throw new NotImplementedException();
        }

        void IMyList.Insert(int index, object? value)
        {
            throw new NotImplementedException();
        }

        void IMyList.Remove(object? value)
        {
            throw new NotImplementedException();
        }

        object[] IMyCollection.ToArray()
        {
            throw new NotImplementedException();
        }
        #endregion
        private class Iterator<T> : IMyEnumeratorGen<T>
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

            object IMyEnumerator.Current => Current;


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
