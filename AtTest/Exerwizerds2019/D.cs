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
            var list = new List<long>();
            for(int i =0; i < n; i++)
            {
                list.Add(ss[i]);
            }
            long mask = 1000000000 + 7;
            perms = AllPermutations(n, mask);
            WriteLine(Pats(ref list, x, mask));
        }

        static long Pats(ref List<long> list,
            long val, long mask)
        {
            long res = 0;
            for(int i=0;i<list.Count;i++)
            {
                long now = val % list[i];
                var next = new List<long>();
                for (int j=0;j<list.Count;j++)
                {
                    if (list[j] <= now) next.Add(list[j]);
                }
                if (next.Count == 0)
                {
                    res += MultiMod(now, perms[list.Count - 1], mask);
                    res %= mask;
                }
                else if (next.Count == 1 && next[0] == list[i]) continue;
                else
                {
                    res += MultiMod(Pats(ref next, now, mask)
                        , Permutation(
                            list.Count - 1,
                            list.Count - 1 - next.Count, mask),
                            mask);
                    res %= mask;
                }
            }
            return res;
        }

        static long Combination(long n, long m, long mask)
        {
            if (n < m) return 0;

            if (n - m < m) m = n - m;

            long val = Permutation(n, m, mask);
            long div = Permutation(m, m, mask);
            return MultiMod(val, ReverseMod(div, mask - 2, mask), mask);
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

        static long[] AllPermutations(long n, long mask)
        {
            var perms = new long[n + 1];
            perms[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                perms[i] = MultiMod(perms[i - 1], i, mask);
            }
            return perms;
        }

        static long MultiMod(long a, long b, long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        static long ReverseMod(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = ReverseMod(a, pow / 2, mask);
                long nextMod = MultiMod(halfMod, halfMod, mask);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return MultiMod(nextMod, a, mask);
                }
            }
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
