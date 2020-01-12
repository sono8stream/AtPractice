using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Dwango6_prelims
{
    class B
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
            long n = ReadLong();
            long[] xs = ReadLongs();
            long mask = 1000000000 + 7;
            CaseCalculator calculator = new CaseCalculator(mask, n);
            long[] divs = new long[n];
            for (int i = 0; i < n; i++) divs[i] = calculator.Reverse(i + 1);
            long[] sums = new long[n];
            sums[0] = divs[0];
            for (int i = 1; i < n; i++) sums[i] = (sums[i - 1] + divs[i]) % mask;
            long res = 0;
            for (int i = 0; i < n - 1; i++)
            {
                long dist = xs[i + 1] - xs[i];
                res += dist * sums[i];
                res %= mask;
            }
            for (int i = 1; i < n; i++) res = (res * i) % mask;
            WriteLine(res);
        }

        class CaseCalculator
        {
            long mask;
            long[] allPermutations;

            public CaseCalculator(long mask, long permutationCnt)
            {
                this.mask = mask;
                allPermutations = AllPermutations(permutationCnt);
            }

            public long Combination(long n, long m)
            {
                if (n < m) return 0;

                if (n - m < m) m = n - m;

                return Multi(allPermutations[n],
                    Reverse(Multi(allPermutations[n - m], allPermutations[m])));
            }

            public long Permutation(long n, long m)
            {
                if (n < m) return 0;

                return Multi(allPermutations[n],
                    Reverse(allPermutations[n - m]));
            }

            long[] AllPermutations(long n)
            {
                var perms = new long[n + 1];
                perms[0] = 1;
                for (int i = 1; i <= n; i++)
                {
                    perms[i] = Multi(perms[i - 1], i);
                }
                return perms;
            }

            public long Multi(long a, long b)
            {
                return ((a % mask) * (b % mask)) % mask;
            }

            public long Reverse(long val)
            {
                return Pow(val, mask - 2);
            }

            long Pow(long a, long exp)
            {
                if (exp == 0) return 1;
                else if (exp == 1) return a % mask;
                else
                {
                    long halfMod = Pow(a, exp / 2);
                    long nextMod = Multi(halfMod, halfMod);
                    if (exp % 2 == 0)
                    {
                        return nextMod;
                    }
                    else
                    {
                        return Multi(nextMod, a);
                    }
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
