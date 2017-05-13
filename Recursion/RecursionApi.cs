using System;

namespace Recursion
{
    public static class RecursionApi
    {
        public static T Call<T>(this Target<T> target, T arg) => target.ToTailCall()(arg);
        public static T Call<T>(this Target2<T> target, T arg1, T arg2) => target.ToTailCall()(arg1, arg2);
        public static T Call<T>(this Target3<T> target, T arg1, T arg2, T arg3) => target.ToTailCall()(arg1, arg2, arg3);
        public static T Call<T>(this Target4<T> target, T arg1, T arg2, T arg3, T arg4) => target.ToTailCall()(arg1, arg2, arg3, arg4);
        public static T Call<T>(this Target5<T> target, T arg1, T arg2, T arg3, T arg4, T arg5) => target.ToTailCall()(arg1, arg2, arg3, arg4, arg5);
        public static T Call<T>(this Target6<T> target, T arg1, T arg2, T arg3, T arg4, T arg5, T arg6) => target.ToTailCall()(arg1, arg2, arg3, arg4, arg5, arg6);
        public static T Call<T>(this Target7<T> target, T arg1, T arg2, T arg3, T arg4, T arg5, T arg6, T arg7) => target.ToTailCall()(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        public static R Call<T, R>(this Target<T, R> target, T arg) => target.ToTailCall()(arg);

        public static R Call<T1, T2, R>(this Target<T1, T2, R> target, T1 arg1, T2 arg2) => target.ToTailCall()(arg1, arg2);

        public static R Call<T1, T2, T3, R>(this Target<T1, T2, T3, R> target, T1 arg1, T2 arg2, T3 arg3) => target.ToTailCall()(arg1, arg2, arg3);

        public static R Call<T1, T2, T3, T4, R>(this Target<T1, T2, T3, T4, R> target, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => target.ToTailCall()(arg1, arg2, arg3, arg4);

        public static R Call<T1, T2, T3, T4, T5, R>(this Target<T1, T2, T3, T4, T5, R> target, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => target.ToTailCall()(arg1, arg2, arg3, arg4, arg5);

        public static R Call<T1, T2, T3, T4, T5, T6, R>(this Target<T1, T2, T3, T4, T5, T6, R> target, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => target.ToTailCall()(arg1, arg2, arg3, arg4, arg5, arg6);

        public static R Call<T1, T2, T3, T4, T5, T6, T7, R>(this Target<T1, T2, T3, T4, T5, T6, T7, R> target, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => target.ToTailCall()(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        public static Func<T, T> ToTailCall<T>(
            this Target<T> target) => ToTailCall<T, T>((recurse, arg) => target(_arg => recurse(_arg), arg));

        public static Func<T, T, T> ToTailCall<T>(
            this Target2<T> target) => ToTailCall<T, T, T>((recurse, arg1, arg2) => target((_arg1, _arg2) => recurse(_arg1, _arg2), arg1, arg2));

        public static Func<T, T, T, T> ToTailCall<T>(
            this Target3<T> target) => ToTailCall<T, T, T, T>((recurse, arg1, arg2, arg3) => target((_arg1, _arg2, _arg3) => recurse(_arg1, _arg2, _arg3), arg1, arg2, arg3));

        public static Func<T, T, T, T, T> ToTailCall<T>(
            this Target4<T> target) => ToTailCall<T, T, T, T, T>((recurse, arg1, arg2, arg3, arg4) => target((_arg1, _arg2, _arg3, _arg4) => recurse(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4));

        public static Func<T, T, T, T, T, T> ToTailCall<T>(
            this Target5<T> target) => ToTailCall<T, T, T, T, T, T>((recurse, arg1, arg2, arg3, arg4, arg5) => target((_arg1, _arg2, _arg3, _arg4, _arg5) => recurse(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5));

        public static Func<T, T, T, T, T, T, T> ToTailCall<T>(
            this Target6<T> target) => ToTailCall<T, T, T, T, T, T, T>((recurse, arg1, arg2, arg3, arg4, arg5, arg6) => target((_arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => recurse(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6));

        public static Func<T, T, T, T, T, T, T, T> ToTailCall<T>(
            this Target7<T> target) => ToTailCall<T, T, T, T, T, T, T, T>((recurse, arg1, arg2, arg3, arg4, arg5, arg6, arg7) => target((_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => recurse(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7));



        public static Func<T, R> ToTailCall<T, R>(
            this Target<T,R> target)
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
            this Target<T1, T2, R> target)
        {
            R TailCall(T1 a, T2 b)
            {
                LazyRef<R> Target(Recurse<(T1, T2), R> func1, (T1, T2) tuple)
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
            this Target<T1, T2, T3, R> target)
        {
            R TailCall(T1 a, T2 b, T3 c)
            {
                LazyRef<R> Target(Recurse<(T1, T2, T3), R> func1, (T1, T2, T3) tuple)
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
            this Target<T1, T2, T3, T4, R> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d)
            {
                LazyRef<R> Target(Recurse<(T1, T2, T3, T4), R> func1, (T1, T2, T3, T4) tuple)
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
            this Target<T1, T2, T3, T4, T5, R> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d, T5 e)
            {
                LazyRef<R> Target(Recurse<(T1, T2, T3, T4, T5), R> func1, (T1, T2, T3, T4, T5) tuple)
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
            this Target<T1, T2, T3, T4, T5, T6, R> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
            {
                LazyRef<R> Target(Recurse<(T1, T2, T3, T4, T5, T6), R> func1, (T1, T2, T3, T4, T5, T6) tuple)
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
            this Target<T1, T2, T3, T4, T5, T6, T7, R> target)
        {
            R TailCall(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f, T7 g)
            {
                LazyRef<R> Target(Recurse<(T1, T2, T3, T4, T5, T6, T7), R> func1, (T1, T2, T3, T4, T5, T6, T7) tuple)
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
