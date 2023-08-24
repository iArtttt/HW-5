using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Interface.InterfaceCollection;
using Interface.InterfaceCollectionGeneric;

namespace Interface.MyCollection
{
    public class MyList<T> : IMyList<T>, IMyList
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

        private T[] _arr;

        private int _size = 4;

        public int Capaсity => _size;

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
        public void Add(T? item)
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

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator<T>(this);
        }

        public int IndexOf(T? value)
        {
            for (int i = 0; i < Count; i++)
            {
                T temp = _arr[i];

                if (temp.Equals(value))
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
                T temp;
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

        public void Sort(IComparer<T>? comparer = null)
        {
            if (_arr == null) throw new ArgumentNullException();
            if (this[0] is IComparable<T>)
            {
                BubbleSort(this, comparer);
            }
        }
        private void BubbleSort(MyList<T> arr, IComparer<T>? comparer)
        {

            if (arr == null)
                return;
            else if(comparer != null)
            {
                T temp;
                for (int i = 0; i < Count - 1; i++)
                {
                    for (int j = 0; j < Count - i - 1; j++)
                    {
                        if (comparer.Compare(arr[j],arr[j + 1]) > 0)
                        {
                            temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                IComparable<T>? comparer1;
                T temp;
                for (int i = 0; i < Count - 1; i++)
                {
                    for (int j = 0; j < Count - i - 1; j++)
                    {
                        comparer1 = arr[j] as IComparable<T>;
                        
                        if (comparer1.CompareTo(arr[j + 1]) > 0)
                        {
                            temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
                    }
                }
            }
        }

        public int BinarySearch(T? item)
        {
            Sort();
            return BinarySearch(this, item);
        }

        private int BinarySearch(MyList<T>? arr, T? item)
        {
            IComparable<T>? comparer;
            int low = 0;
            int middle;
            int high = Count - 1;
            while (low <= high)
            {
                middle = low + (high - low) / 2;
                comparer = arr[middle] as IComparable<T>;
                if 
                    (comparer.CompareTo(item) > 0) high = middle - 1;
                else if 
                    (comparer.CompareTo(item) < 0) low = middle + 1;
                else 
                    return middle;
            }
            return -1;
        }

        public void Remove(T? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_arr[i].Equals(value))
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
            if (index < Capaсity && index >= 0)
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

        #region IEnumerator implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IMyList.Add(object? value)
        {
            try
            {
                Add((T)value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        bool IMyCollection.Contains(object? value)
        {
            try
            {
                return Contains((T)value);
            }
            catch { return false; }

        }

        int IMyList.IndexOf(object? value)
        {
            if (value is T)
            {
                return IndexOf((T)value!);
            }
            return -1;
        }

        void IMyList.Insert(int index, object? value)
        {
            try
            {
                Insert(index, (T)value!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void IMyList.Remove(object? value)
        {
            if (value is T)
            {
                Remove((T)value!);
            }
        }

        object[] IMyCollection.ToArray()
        {
            throw new NotImplementedException();
        }
        #endregion
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
