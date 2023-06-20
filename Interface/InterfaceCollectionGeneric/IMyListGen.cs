using Interface.InterfaceCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollectionGeneric
{
    public interface IMyListGen<T> : IMyCollectionGen<T>, IMyEnumerableGen<T>//,IMyList
    {
        T? this[int index] { get; set; }
        int Capasity { get; }

        void Add(T? value);
        bool Contains(T? value);
        int IndexOf(T? value);
        void Insert(int index, T? value);
        void Remove(T? value);
        void RemoveAt(int index);
    }
}
