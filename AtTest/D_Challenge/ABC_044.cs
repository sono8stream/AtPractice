using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_044
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long s = ReadLong();
            if (n == s)
            {
                Console.WriteLine(n + 1);
                return;
            }

            long sqrt = (long)Math.Sqrt(n);

            for(long i = 2; i <= sqrt; i++)
            {
                long val = 0;
                long nn = n;
                while (nn > 0)
                {
                    val += nn % i;
                    nn /= i;
                }
                if (val == s)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            for (long i = Math.Min(sqrt, s); i >= 1; i--)
            {
                long margin = s - i;
                if (n - margin < 0) continue;

                if ((n - margin) % i == 0)
                {
                    long val = (n - margin) / i;
                    if (i==val
                        ||val <= margin) continue;

                    Console.WriteLine((n - margin) / i);
                    return;
                }
            }
            Console.WriteLine(-1);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
