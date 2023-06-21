using Interface.InterfaceCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollectionGeneric
{
    public interface IMyList<T> : IMyCollection<T>, IEnumerable<T>
    {
        T? this[int index] { get; set; }
        int Capaсity { get; }

        void Add(T? value);
        int IndexOf(T? value);
        void Insert(int index, T? value);
        void Remove(T? value);
        void RemoveAt(int index);
    }
}
