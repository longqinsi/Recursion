using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public static class RecursionExtensions
    {
        public static LazyRef<T> AsLazyRef<T>(this T value) => (LazyRef<T>)value;
    }
}
