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
        abstract class Iterator<U> : IEnumerable<U>, IEnumerator<U>
        {
            internal int state;
            internal U current;

            public U Current
            {
                get { return current; }
            }

            public abstract Iterator<U> Clone();

            public virtual void Dispose()
            {
                current = default(U);
                state = -1;
            }

            public IEnumerator<U> GetEnumerator()
            {
                if (state == 0)
                {
                    state = 1;
                    return this;
                }
                Iterator<U> duplicate = Clone();
                duplicate.state = 1;
                return duplicate;
            }

            public abstract bool MoveNext();

            public abstract IEnumerable<T> Select<T>(Func<U, T> selector);
            object IEnumerator.Current
            {
                get { return Current; }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }
        }
        private class BaseEnumerable<T> : IEnumerable<T>
        {
            private readonly Func<IEnumerator<T>> _enumerator;
            public BaseEnumerable(Func<IEnumerator<T>> enumerator) 
            {
                _enumerator = enumerator;
            }

            public IEnumerator<T> GetEnumerator() => _enumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class FilterIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _list;
            private readonly Predicate<T?> _predicate;

            public FilterIterator(IEnumerable<T> list, Predicate<T?> predicate)
            {
                _list = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _list.Current;

            object IEnumerator.Current => Current;

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

        private class SkipIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _list;
            private int _count;

            public SkipIterator(IEnumerable<T> list, int count)
            {
                _list = list.GetEnumerator();
                _count = count;
            }

            public T Current => _list.Current;

            object IEnumerator.Current => Current;

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
        private class SkipWhileIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _list;
            private readonly Predicate<T?> _predicate;

            public SkipWhileIterator(IEnumerable<T> list, Predicate<T?> predicate)
            {
                _list = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _list.Current;

            object IEnumerator.Current => Current;

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

        private class TakeIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _list;
            private int _count;

            public TakeIterator(IEnumerable<T> list, int count)
            {
                _list = list.GetEnumerator();
                _count = count;
            }

            public T Current => _list.Current;

            object IEnumerator.Current => Current;

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
        private class TakeWhileIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _list;
            private readonly Predicate<T?> _predicate;

            public TakeWhileIterator(IEnumerable<T> list, Predicate<T?> predicate)
            {
                _list = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _list.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                res = _list.MoveNext();
                //if (_predicate(Current) && res)
                //    return res;
                return _predicate(Current) && res;
            }

            public void Reset()
            {
                
            }
        }

        static Func<TSource, TResult> CombineSelectors<TSource, TMiddle, TResult>(Func<TSource, TMiddle> selector1, Func<TMiddle, TResult> selector2)
        {
            return x => selector2(selector1(x));
        }

        private class SelectIterator<T, U> : Iterator<U>
        {
            private readonly IEnumerable<T> _list;
            private IEnumerator<T?> _enumerator;
            private readonly Func<T, U> _func;
            private U _current;

            public SelectIterator(IEnumerable<T> list, Func<T, U> func)
            {
                _list = list;
                _func = func;
            }

            public T Current => _enumerator.Current;

            //object IEnumerator.Current => Current;

            public override Iterator<U> Clone() =>
                new SelectIterator<T, U>(_list, _func);

            public override void Dispose()
            {
            }

            public override bool MoveNext()
            {
                bool res;
                _enumerator = _list.GetEnumerator();
                res = _enumerator.MoveNext();
                if (res)
                    _current = _func(Current);
                return res;
            }

            public void Reset()
            {

            }

            public override IEnumerable<U1> Select<U1>(Func<U, U1> selector) => new SelectIterator<T, U1>(_list, CombineSelectors(_func, selector));
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnumerable<T>(() => new FilterIterator<T>(enumeration, predicate));
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> enumeration, int count)
        {
            return new BaseEnumerable<T>(() => new SkipIterator<T>(enumeration, count));
        }
        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnumerable<T>(() => new SkipWhileIterator<T>(enumeration, predicate));
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> enumeration, int count)
        {
            return new BaseEnumerable<T>(() => new TakeIterator<T>(enumeration, count));
        }
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnumerable<T>(() => new TakeWhileIterator<T>(enumeration, predicate));
        }
        
        public static T First<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            if (enumeration == null || predicate == null) throw new ArgumentNullException();

            foreach (T item in enumeration)
            {
                if (predicate(item))
                    return item;
            }
            throw new ArgumentNullException();
        }
        public static T FirstOrDefault<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            if (enumeration == null || predicate == null) throw new ArgumentNullException();

            foreach (T item in enumeration)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }


        public static T Last<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            if (enumeration == null || predicate == null) throw new ArgumentNullException();
            T last = default;
            foreach (T item in enumeration)
            { 
                if (predicate(item))
                    last = item;
            }
            if (last != null)   
                return last;

            throw new ArgumentNullException();
        }
        public static T LastOrDefault<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            if (enumeration == null || predicate == null) throw new ArgumentNullException();
            T last = default;
            foreach (T item in enumeration)
            {
                if (predicate(item))
                    last = item;
            }

            return last != null ? last : default;

        }

        public static IEnumerable<U> Select<T, U>(this IEnumerable<T> enumeration, Func<T, U> func)
        {
            return new SelectIterator<T, U>(enumeration, func);
        }

        public static bool All<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            if (enumeration == null || predicate == null) throw new ArgumentNullException();

            foreach (T item in enumeration)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }
        public static bool Any<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            if (enumeration == null || predicate == null) throw new ArgumentNullException();

            foreach (T item in enumeration)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }

        public static T[] ToArray<T>(this IEnumerable<T> enumeration)
        {
            MyList<T> arr = new MyList<T>();
            foreach (T item in enumeration)
            {
                arr.Add(item);
            }
            return arr.ToArray();
        }
        public static MyList<T> ToList<T>(this IEnumerable<T> enumeration)
        {
            MyList<T> arr = new MyList<T>();

            foreach (T item in enumeration)
            {
                arr.Add(item);
            }
            return arr;
        }

    }
}
