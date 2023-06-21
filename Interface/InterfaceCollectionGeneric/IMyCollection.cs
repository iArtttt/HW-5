using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollectionGeneric
{
    public interface IMyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        bool Contains(T? value);
        T[] ToArray();
        void Clear();
    }
}
