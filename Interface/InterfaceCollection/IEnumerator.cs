using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollection
{
    internal interface IEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
}
