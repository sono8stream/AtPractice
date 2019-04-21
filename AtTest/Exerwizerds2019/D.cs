using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Exerwizerds2019
{
    class D
    {
        static long[] perms;

        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nx = ReadInts();
            long n = nx[0];
            long x = nx[1];
            long[] ss = ReadLongs();
            ss = ss.OrderBy(a => -a).ToArray();

            long mask = 1000000000 + 7;
            var dict = new Dictionary<long, long>();
            dict.Add(x, 1);

            for(int i = 0; i < n; i++)
            {
                var next = new Dictionary<long, long>();
                foreach (long key in dict.Keys)
                {
                    long nextKey = key % ss[i];
                    if (!next.ContainsKey(nextKey)) next.Add(nextKey, 0);
                    next[nextKey] += dict[key];
                    next[nextKey] %= mask;

                    if (!next.ContainsKey(key)) next.Add(key, 0);
                    next[key] += dict[key] * (n - 1 - i);
                    next[key] %= mask;
                }
                dict = next;
            }
            long res = 0;
            foreach(long key in dict.Keys)
            {
                if (key >= ss[n - 1]) continue;

                res += key * dict[key];
                res %= mask;
            }
            WriteLine(res);
        }

        static long Permutation(long n, long m, long mask)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= ((n - i) % mask);
                val %= mask;
            }
            return val;
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
