using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface.InterfaceCollection;

namespace Interface.InterfaceCollectionGeneric
{
    public interface IMyEnumerableGen<T> : IMyEnumerable
    {
        IMyEnumeratorGen<T> GetEnumerator();
    }
}
