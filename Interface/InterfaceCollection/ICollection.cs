using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollection
{
    internal interface ICollection : IEnumerable
    {
        int Count { get; }
        int Capasity { get; }
        object[] ToArray();
        void Clear();
    }
}
