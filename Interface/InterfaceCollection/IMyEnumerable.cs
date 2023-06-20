using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollection
{
    public interface IMyEnumerable
    {
        IMyEnumerator GetEnumerator();
    }
}
