using System;

namespace Recursion
{
    public class LazyRef<T>
    {
        public T Value => Factory();
        public Func<T> Factory { get; set; }

        public LazyRef()
        {
        }

        public LazyRef(Func<T> factory)
        {
            this.Factory = factory;
        }

        public static implicit operator T(LazyRef<T> obj)
        {
            return obj.Value;
        }

        public static implicit operator LazyRef<T>(T obj)
        {
            return new LazyRef<T>(() => obj);
        }
    }
}
