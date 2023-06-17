using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollection
{
    internal interface IList : ICollection, IEnumerable
    {
        object? this[int index] { get; set; }
        void Add(object? value);
        bool Contains(object? value);
        int IndexOf(object? value);
        void Insert(int index, object? value);
        void Remove(object? value);
        void RemoveAt(int index);
    }
}
