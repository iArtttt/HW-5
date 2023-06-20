using Interface.InterfaceCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollectionGeneric
{
    public interface IMyEnumeratorGen<T> : IMyEnumerator
    {
        T Current { get; }
        bool MoveNext();
        void Reset();
    }
}
