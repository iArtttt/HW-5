using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollectionGeneric
{
    public interface IMyCollectionGen<T> : IMyEnumerableGen<T>
    {
        int Count { get; }
        T[] ToArray();
        void Clear();
    }
}
