using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_109
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            long x = long.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var xs = new long[n];
            for (int i = 0; i < n; i++)
            {
                xs[i] = Math.Abs(long.Parse(input[i])-x);
            }

            Array.Sort(xs);
            long distMax = xs[0];
            for (int i = 1; i < n; i++)
            {
                distMax = GCD(xs[i], distMax);
            }

            Console.WriteLine(distMax);
        }

        static long GCD(long a, long b)
        {
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }
    }
}
