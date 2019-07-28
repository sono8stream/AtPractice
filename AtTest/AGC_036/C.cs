using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_036
{
    class C
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
            int[] nm = ReadInts();
            long n = nm[0];
            long m = nm[1];
            long mask = 998244353;

            long[] perms = AllPermutations(3 * m + n - 1, mask);
            long allPat = MultiMod(perms[3 * m + n - 1],
                ReverseMod(MultiMod(perms[3 * m], perms[n - 1], mask),
                mask - 2, mask), mask);

            long cannots = n;
            for(long i = 1; i < n; i++)
            {
                long remain = 3 * m - i;
                if (remain <= 0) break;
                long ones = i;
                if (remain == 1) ones++;
                long zeros = n - i - 1;

                if (ones == m) continue;

                cannots += MultiMod(perms[n],
                ReverseMod(MultiMod(perms[ones], perms[zeros], mask),
                mask - 2, mask), mask);
                cannots %= mask;
            }

            long res = (allPat - cannots + mask) % mask;
            WriteLine(res);
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
