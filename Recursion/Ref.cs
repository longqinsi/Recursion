using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    internal class Ref<T>
    {
        public T Value { get; set; }
        public static implicit operator T(Ref<T> obj)
        {
            return obj.Value;
        }
    }
}
