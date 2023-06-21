using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfaceCollection
{
    public interface IMyList : IMyCollection
    {
        object? this[int index] { get; set; }
        int Capaсity { get; }

        void Add(object? value);        
        int IndexOf(object? value);
        void Insert(int index, object? value);
        void Remove(object? value);
        void RemoveAt(int index);
    }
}
