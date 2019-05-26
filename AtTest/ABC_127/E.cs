using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_127
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int n = Max(nmk[0], nmk[1]);
            int m = Min(nmk[0], nmk[1]);
            int k = nmk[2];
            long mask = 1000000000 + 7;
            long val = 0;
            for (int i = 1; i <= n + m - 2; i++)
            {
                long w = i + 1;
                long h = 1;
                if (w > n)
                {
                    h += w - n;
                    w = n;
                }
                long cnt = 0;
                while (w >= 1 && h <= m)
                {
                    long tmp = (n - w + 1) * (m - h + 1);
                    if (w > 1 && h > 1) tmp *= 2;
                    cnt += tmp;
                    cnt %= mask;
                    w--;
                    h++;
                }

                val += cnt * i;
                val %= mask;
            }
            val = MultiMod(val, Combination(n * m - 2, k - 2, mask), mask);
            WriteLine(val);
        }
        static long Permutation(long n, long m)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= (n - i);
            }
            return val;
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
