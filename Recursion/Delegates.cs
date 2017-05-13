namespace Recursion
{
    public delegate LazyRef<T> Recurse<T>(T arg1);
    public delegate LazyRef<T> Target<T>(Recurse<T> recurse, T arg1);
    public delegate LazyRef<T> Recurse2<T>(T arg1, T arg2);
    public delegate LazyRef<T> Target2<T>(Recurse2<T> recurse, T arg1, T arg2);
    public delegate LazyRef<T> Recurse3<T>(T arg1, T arg2, T arg3);
    public delegate LazyRef<T> Target3<T>(Recurse3<T> recurse, T arg1, T arg2, T arg3);
    public delegate LazyRef<T> Recurse4<T>(T arg1, T arg2, T arg3, T arg4);
    public delegate LazyRef<T> Target4<T>(Recurse4<T> recurse, T arg1, T arg2, T arg3, T arg4);
    public delegate LazyRef<T> Recurse5<T>(T arg1, T arg2, T arg3, T arg4, T arg5);
    public delegate LazyRef<T> Target5<T>(Recurse5<T> recurse, T arg1, T arg2, T arg3, T arg4, T arg5);
    public delegate LazyRef<T> Recurse6<T>(T arg1, T arg2, T arg3, T arg4, T arg5, T arg6);
    public delegate LazyRef<T> Target6<T>(Recurse6<T> recurse, T arg1, T arg2, T arg3, T arg4, T arg5, T arg6);
    public delegate LazyRef<T> Recurse7<T>(T arg1, T arg2, T arg3, T arg4, T arg5, T arg6, T arg7);
    public delegate LazyRef<T> Target7<T>(Recurse7<T> recurse, T arg1, T arg2, T arg3, T arg4, T arg5, T arg6, T arg7);

    public delegate LazyRef<R> Recurse<T, R>(T arg1);
    public delegate LazyRef<R> Target<T, R>(Recurse<T, R> recurse, T arg1);
    public delegate LazyRef<R> Recurse<T1, T2, R>(T1 arg1, T2 arg2);
    public delegate LazyRef<R> Target<T1, T2, R>(Recurse<T1, T2, R> recurse, T1 arg1, T2 arg2);
    public delegate LazyRef<R> Recurse<T1, T2, T3, R>(T1 arg1, T2 arg2, T3 arg3);
    public delegate LazyRef<R> Target<T1, T2, T3, R>(Recurse<T1, T2, T3, R> recurse, T1 arg1, T2 arg2, T3 arg3);
    public delegate LazyRef<R> Recurse<T1, T2, T3, T4, R>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate LazyRef<R> Target<T1, T2, T3, T4, R>(Recurse<T1, T2, T3, T4, R> recurse, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate LazyRef<R> Recurse<T1, T2, T3, T4, T5, R>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate LazyRef<R> Target<T1, T2, T3, T4, T5, R>(Recurse<T1, T2, T3, T4, T5, R> recurse, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate LazyRef<R> Recurse<T1, T2, T3, T4, T5, T6, R>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate LazyRef<R> Target<T1, T2, T3, T4, T5, T6, R>(Recurse<T1, T2, T3, T4, T5, T6, R> recurse, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate LazyRef<R> Recurse<T1, T2, T3, T4, T5, T6, T7, R>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
    public delegate LazyRef<R> Target<T1, T2, T3, T4, T5, T6, T7, R>(Recurse<T1, T2, T3, T4, T5, T6, T7, R> recurse, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
}