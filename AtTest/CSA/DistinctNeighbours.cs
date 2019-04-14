using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CSA
{
    class DistinctNeighbours
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            List<long> cnts = new List<long>();
            cnts.Add(1);
            for(int i = 1; i < n; i++)
            {
                if (array[i] == array[i - 1]) cnts[cnts.Count - 1]++;
                else cnts.Add(1);
            }
            cnts.Sort();
            if (cnts[cnts.Count - 1] - 1 > n - cnts[cnts.Count - 1])
            {
                WriteLine(0);
                return;
            }
            long mask = 1000000000 + 7;
            long res = 1;
            long now = cnts[0];
            long remain = now - 1;
            for (int i = 1; i < cnts.Count; i++)
            {
                res = MultiMod(res,
                    Combination(now + 1 - remain,
                    Min(now + 1-remain, cnts[i] - remain), mask), mask);
                remain = now + 1 - cnts[i];
                if (remain < 0) remain = 0;
                now += cnts[i];
            }
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
