using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public static class Recursion
    {
        public static Func<T, R> ToTailCall<T, R>(
            this Func<Func<T, LazyRef<R>>, T, LazyRef<R>> target)
        {
            var calledRef = new Ref<bool>();
            var paramRef = new Ref<T>();
            var currResult = new Ref<LazyRef<R>>();

            R Factory()
            {
                return currResult.Value.Value;
            }

            var lazyResult = new LazyRef<R>(
                Factory);

            LazyRef<R> SetRef(T t)
            {
                calledRef.Value = true;
                paramRef.Value = t;
                return lazyResult;
            }

            R TailCall(T t)
            {
                paramRef.Value = t;

                do
                {
                    calledRef.Value = false;
                    currResult.Value = target(SetRef, paramRef.Value);
                } while (calledRef.Value);

                return lazyResult.Value;
            }

            return TailCall;
        }

        public static Func<T1, T2, R> ToTailCall<T1, T2, R>(
            this Func<Func<T1, T2, LazyRef<R>>, T1, T2, LazyRef<R>> target)
        {
            R TailCall(T1 a, T2 b)
            {
                LazyRef<R> Target(Func<(T1, T2), LazyRef<R>> func1, (T1, T2) tuple)
                {
                    LazyRef<R> Func(T1 arg1, T2 arg2)
                    {
                        return func1(ValueTuple.Create(arg1, arg2));
                    }

                    return target(Func, tuple.Item1, tuple.Item2);
                }

                return ToTailCall<ValueTuple<T1, T2>, R>(Target)(ValueTuple.Create(a, b));
            }

            return TailCall;
        }

        public static Func<T1, T2, T3, R> ToTailCall<T1, T2, T3, R>(
            this Func<Func<T1, T2, T3, LazyRef<R>>, T1, T2, T3, LazyRef<R>> target)
        {
            R TailCall(T1 a, T2 b, T3 c)
            {
                LazyRef<R> Target(Func<(T1, T2, T3), LazyRef<R>> func1, (T1, T2, T3) tuple)
                {
                    LazyRef<R> Func(T1 arg1, T2 arg2, T3 arg3)
                    {
                        return func1(ValueTuple.Create(arg1, arg2, arg3));
                    }

                    return target(Func, tuple.Item1,
                        tuple.Item2, tuple.Item3);
                }

                return ToTailCall<ValueTuple<T1, T2, T3>, R>(Target)(ValueTuple.Create(a, b, c));
            }

            return TailCall;
        }

        public static Func<T1, T2, T3, T4, R> ToTailCall<T1, T2, T3, T4, R>(
            this Func<Func<T1, T2, T3, T4, LazyRef<R>>, T1, T2, T3, T4, LazyRef<R>> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d)
            {
                LazyRef<R> Target(Func<(T1, T2, T3, T4), LazyRef<R>> func1, (T1, T2, T3, T4) tuple)
                {
                    LazyRef<R> Func(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
                    {
                        return func1(ValueTuple.Create(arg1, arg2, arg3, arg4));
                    }

                    return target(Func,
                        tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
                }

                return ToTailCall<ValueTuple<T1, T2, T3, T4>, R>(Target)(ValueTuple.Create(a, b, c, d));
            }

            return TailCall;
        }

        public static Func<T1, T2, T3, T4, T5, R> ToTailCall<T1, T2, T3, T4, T5, R>(
            this Func<Func<T1, T2, T3, T4, T5, LazyRef<R>>, T1, T2, T3, T4, T5, LazyRef<R>> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d, T5 e)
            {
                LazyRef<R> Target(Func<(T1, T2, T3, T4, T5), LazyRef<R>> func1, (T1, T2, T3, T4, T5) tuple)
                {
                    LazyRef<R> Func(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
                    {
                        return func1(ValueTuple.Create(arg1, arg2, arg3, arg4, arg5));
                    }

                    return target(Func, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
                }

                return ToTailCall<ValueTuple<T1, T2, T3, T4, T5>, R>(Target)(ValueTuple.Create(a, b, c, d, e));
            }

            return TailCall;
        }

        public static Func<T1, T2, T3, T4, T5, T6, R> ToTailCall<T1, T2, T3, T4, T5, T6, R>(
            this Func<Func<T1, T2, T3, T4, T5, T6, LazyRef<R>>, T1, T2, T3, T4, T5, T6, LazyRef<R>> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
            {
                LazyRef<R> Target(Func<(T1, T2, T3, T4, T5, T6), LazyRef<R>> func1, (T1, T2, T3, T4, T5, T6) tuple)
                {
                    LazyRef<R> Func(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
                    {
                        return func1(ValueTuple.Create(arg1, arg2, arg3, arg4, arg5, arg6));
                    }

                    return target(Func, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
                }

                return ToTailCall<ValueTuple<T1, T2, T3, T4, T5, T6>, R>(Target)(ValueTuple.Create(a, b, c, d, e, f));
            }

            return TailCall;
        }

        public static Func<T1, T2, T3, T4, T5, T6, T7, R> ToTailCall<T1, T2, T3, T4, T5, T6, T7, R>(
            this Func<Func<T1, T2, T3, T4, T5, T6, T7, LazyRef<R>>, T1, T2, T3, T4, T5, T6, T7, LazyRef<R>> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g)
            {
                LazyRef<R> Target(Func<(T1, T2, T3, T4, T5, T6, T7), LazyRef<R>> func1, (T1, T2, T3, T4, T5, T6, T7) tuple)
                {
                    LazyRef<R> Func(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
                    {
                        return func1(ValueTuple.Create(arg1, arg2, arg3, arg4, arg5, arg6, arg7));
                    }

                    return target(
                        Func, tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5,
                        tuple.Item6, tuple.Item7);
                }

                return ToTailCall<ValueTuple<T1, T2, T3, T4, T5, T6, T7>, R>(Target)(ValueTuple.Create(a, b, c, d, e, f, g));
            }

            return TailCall;
        }

    }

}
