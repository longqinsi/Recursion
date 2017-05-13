using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Recursion.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Fib(10000000, 1):{Fib(10000000, 1)}");
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds / 1000} seconds elpased.");
            Console.ReadLine();
        }

        public static BigInteger Fib(BigInteger i, BigInteger acc)
        {
            Target2<BigInteger> target = (recurse, i1, acc1) =>
            {
                if (i1 == 0)
                {
                    return acc1;
                }
                if (i1 % 100000 == 0)
                {
                    Console.WriteLine($"i:{i1},acc:{acc1}");
                }
                return recurse(i1 - 1, acc1 + i);
            };
            return target.Call(i, acc);
        }
    }
}
