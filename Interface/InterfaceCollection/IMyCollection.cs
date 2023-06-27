using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollection
{
    public interface IMyCollection : IEnumerable
    {
        int Count { get; }
        bool Contains(object? value);
        object[] ToArray();
        void Clear();
    }
}
