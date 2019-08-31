using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC091_E
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] nab = ReadInts();
            long n = nab[0];
            long a = nab[1];
            long b = nab[2];
            bool reverse = a < b;
            long high = Max(a, b);
            long low = Min(a, b);
            if (a * b < n || n + 1 < a + b)
            {
                WriteLine(-1);
                return;
            }

            long first = n - high + 1;
            List<long> res = new List<long>();
            for(int i = 0; i < high; i++)
            {
                res.Add(first + i);
            }
            if (low > 1)
            {
                long now = first - 1;
                for(long i = low-1; i >=1; i--)
                {
                    List<long> cache = new List<long>();
                    long cnt = 0;
                    while (now >= i && cache.Count < high)
                    {
                        cache.Add(now);
                        now--;
                    }
                    cache.Reverse();
                    res.AddRange(cache);
                }
            }
            for(int i = 0; i < res.Count; i++)
            {
                Write(reverse ? n - res[i] + 1 : res[i]);
                if (i < res.Count - 1) Write(' ');
            }
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
