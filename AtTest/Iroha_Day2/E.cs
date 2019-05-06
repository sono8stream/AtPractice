using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day2
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            long n = nm[0];
            long m = nm[1];

            long mask = 1000000000 + 7;
            long[] perms = AllPermutations(n + m, mask);

            long cnts = 0;
            for(int i = 0; i <= n / 2; i++)
            {
                long aCnt = n - i;
                long bRemain = m - aCnt;
                if (m < aCnt) continue;

                long tmp = MultiMod(perms[aCnt],
                    ReverseMod(MultiMod(perms[i], perms[aCnt - i], mask),
                    mask - 2, mask), mask);
                tmp = MultiMod(tmp,
                    MultiMod(perms[aCnt + bRemain - 1],
                    ReverseMod(MultiMod(perms[bRemain], perms[aCnt - 1], mask),
                    mask - 2, mask), mask), mask);
                cnts += tmp;
                cnts %= mask;
            }

            long res = MultiMod(perms[n + m-2],
                ReverseMod(MultiMod(perms[n-1], perms[m-1], mask),
                mask - 2, mask), mask);
            res -= cnts;
            while (res < 0) res += mask;

            WriteLine(res);
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
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
