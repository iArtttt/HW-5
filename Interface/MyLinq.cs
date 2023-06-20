using Interface.InterfaceCollection;
using Interface.InterfaceCollectionGeneric;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal static class MyLinq
    {
        private class BaseEnumerable<T> : IMyEnumerableGen<T>
        {
            private readonly Func<IMyEnumeratorGen<T>> _enumerator;
            public BaseEnumerable(Func<IMyEnumeratorGen<T>> enumerator) 
            {
                _enumerator = enumerator;
            }

            public IMyEnumeratorGen<T> GetEnumerator() => _enumerator();

            IMyEnumerator IMyEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class FilterIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private readonly Predicate<T?> _predicate;

            public FilterIterator(IMyEnumerableGen<T> list, Predicate<T?> predicate)
            {
                _list = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                do
                {
                    res = _list.MoveNext();
                } while (!_predicate(Current) && res);
                return res;
            }

            public void Reset()
            {
                
            }
        }

        private class SkipIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private int _count;

            public SkipIterator(IMyEnumerableGen<T> list, int count)
            {
                _list = list.GetEnumerator();
                _count = count;
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                for (; _count > 0; _count--)
                {
                    _list.MoveNext();
                }

                return _list.MoveNext();
            }

            public void Reset()
            {
                
            }
        }
        private class SkipWhileIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private readonly Predicate<T?> _predicate;

            public SkipWhileIterator(IMyEnumerableGen<T> list, Predicate<T?> predicate)
            {
                _list = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                do
                {
                    res = _list.MoveNext();
                } while (_predicate(Current) && res);
                return res;
            }

            public void Reset()
            {
                
            }
        }

        private class TakeIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private int _count;

            public TakeIterator(IMyEnumerableGen<T> list, int count)
            {
                _list = list.GetEnumerator();
                _count = count;
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                while (_count > 0)
                {
                    _count--;
                    return _list.MoveNext();
                }
                //_list.MoveNext();
                return false;
            }

            public void Reset()
            {
                
            }
        }
        private class TakeWhileIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private readonly Predicate<T?> _predicate;

            public TakeWhileIterator(IMyEnumerableGen<T> list, Predicate<T?> predicate)
            {
                _list = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                res = _list.MoveNext();
                if (_predicate(Current) && res)
                    return res;
                return false;
            }

            public void Reset()
            {
                
            }
        }

        private class FirstIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private int _first = 0;
            public FirstIterator(IMyEnumerableGen<T> list)
            {
                _list = list.GetEnumerator();
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                
                res = _list.MoveNext();

                return _first-- == 0 && res ? res : false;
            }

            public void Reset()
            {

            }
        }
        private class FirstOrDefaultIterator<T> : IMyEnumeratorGen<T>
        {
            private readonly IMyEnumeratorGen<T> _list;
            private int _first = 0;
            public FirstOrDefaultIterator(IMyEnumerableGen<T> list)
            {
                _list = list.GetEnumerator();
            }

            public T Current => _list.Current;

            object IMyEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                
                res = _list.MoveNext();
                if (_first-- == 0)
                    return res == false? true : res;
                return false;
            }

            public void Reset()
            {

            }
        }





        public static IMyEnumerableGen<T> Filter<T>(this IMyEnumerableGen<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnumerable<T>(() => new FilterIterator<T>(enumeration, predicate));
        }

        public static IMyEnumerableGen<T> Skip<T>(this IMyEnumerableGen<T> enumeration, int count)
        {
            return new BaseEnumerable<T>(() => new SkipIterator<T>(enumeration, count));
        }
        public static IMyEnumerableGen<T> SkipWhile<T>(this IMyEnumerableGen<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnumerable<T>(() => new SkipWhileIterator<T>(enumeration, predicate));
        }
        public static IMyEnumerableGen<T> Take<T>(this IMyEnumerableGen<T> enumeration, int count)
        {
            return new BaseEnumerable<T>(() => new TakeIterator<T>(enumeration, count));
        }
        public static IMyEnumerableGen<T> TakeWhile<T>(this IMyEnumerableGen<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnumerable<T>(() => new TakeWhileIterator<T>(enumeration, predicate));
        }
        public static IMyEnumerableGen<T> First<T>(this IMyEnumerableGen<T> enumeration)
        {
            return new BaseEnumerable<T>(() => new FirstIterator<T>(enumeration));
        }
        public static IMyEnumerableGen<T> FirstOrDefault<T>(this IMyEnumerableGen<T> enumeration)
        {
            return new BaseEnumerable<T>(() => new FirstOrDefaultIterator<T>(enumeration));
        }

    }
}
