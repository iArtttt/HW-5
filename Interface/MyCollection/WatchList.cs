using Interface.InterfaceCollection;
using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.MyCollection
{
    internal class WatchList<T> : IMyList<T>, IMyList
    {
        public T this[int index] { get => _watchListList[index]; set => _watchListList[index] = value; }

        public int Count => _watchListList.Count;

        public int Capaсity => _watchListList.Capaсity;

        object? IMyList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private readonly MyList<T> _watchListList;
        public WatchList() 
        {
            _watchListList = new MyList<T>();
        }
        public void Add(T? item)
        {
            _watchListList.Add(item);
            Action<T> ate = LAdd;
            ate(item);
        }

        public void Clear()
        {
            _watchListList.Clear();
            Action action = LClear;
            action();
        }

        public bool Contains(T? item)
        {
            return _watchListList.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _watchListList.GetEnumerator();
        }

        public int IndexOf(T? item)
        {
            return _watchListList.IndexOf(item);
        }

        public void Insert(int index, T? item)
        {
            _watchListList.Insert(index, item);
            Action<T> ate = LAdd;
            ate(item);
        }

        public void Remove(T? item)
        {
            _watchListList.Remove(item);
            Action<T> remove = LRemove;
            remove(item);
        }

        public void RemoveAt(int index)
        {
            _watchListList.RemoveAt(index);
            Action<int> remove = LRemoveAt;
            remove(index);
        }

        public T[] ToArray() => _watchListList.ToArray();

        #region IEnumerator implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void IMyList.Add(object? value)
        {
            try
            {
                Add((T?)value);
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
                return Contains((T?)value);
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

        private void LAdd(T item) => Console.WriteLine($"{item} was Add to WatchList");        
        private void LClear() => Console.WriteLine("List is Clear");
        private void LRemove(T item) => Console.WriteLine($"{item} was remove");
        private void LRemoveAt(int index) => Console.WriteLine($"{index} was remove");
    }
}
