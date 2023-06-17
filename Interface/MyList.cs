using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.InterfaceCollection;

namespace Interface
{
    internal class MyList : IList
    {
        public object? this[int index] 
        { 
            get 
            { 
                if ((uint)index > (uint)Count) 
                    throw new NotImplementedException();
                return this[index];
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

        private object[]? _arr { get; set; }

        private int _size { get; set; } = 4;

        public int Capasity => _size;

        public MyList()
        {
            _arr = new object[_size];
        }
        public MyList(int startCapasity)
        {
            _size = Math.Abs(startCapasity);
            _arr = new object[_size];
        }
        public void Add(object item)
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
                _arr[i] = null;
            _count = 0;
        }

        public bool Contains(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(value))
                    return true;
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                object obj = _arr[i];

                if (obj.GetHashCode() == value.GetHashCode())
                    return i;
            }
            return -1;
        }

        public void Insert(int index, object? value)
        {
            if (index < Count && index >= 0)
            {
                if (Count + 1 > _size)
                {
                    _size *= 2;
                    _arr = ForEach();
                }
                object temp = _arr[index];
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

        public void Remove(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_arr[i].GetHashCode() == value.GetHashCode())
                {
                    _arr[i] = null;
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
                _arr[index] = null;
                _arr = ForEach();
                _count--;
            }
            else { throw new IndexOutOfRangeException(); }
        }

        public object[] ToArray()
        {
            object[] arr = new object[Count];

            for (int i = 0; i < Count; i++)
                arr[i] = _arr[i];

            return arr;
        }
        public void Reverse()
        {
            int j = 0;
            object[] arr = new object[_size];
            for (int i = Count - 1; i >= 0; i--)
                arr[j++] = _arr[i];
            _arr = arr;
        }

        private object[] ForEach()
        {
            object[] arr = new object[_size];

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
    }
}
