using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_151
{
    class E
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
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];
            long[] array = ReadLongs();
            Array.Sort(array);
            long mask = 1000000000 + 7;
            for (int i = 0; i < n; i++)
            {
                array[i] = mask * 10 + array[i];
                array[i] %= mask;
            }
            if (k == 1)
            {
                WriteLine(0);
                return;
            }

            CaseCalculator calculator = new CaseCalculator(mask, n);
            long res = 0;
            for (long i = k - 1; i < n; i++)
            {
                long tmp = array[i] * calculator.Combination(i, k - 1);
                tmp %= mask;
                res += tmp;
                res %= mask;
            }
            for(long i = 0; i < n - k + 1; i++)
            {
                long tmp = array[i] * calculator.Combination(n - i - 1, k - 1);
                tmp %= mask;
                res += mask - tmp;
                res %= mask;
            }
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
                    Reverse(
                        Multi(allPermutations[n - m], allPermutations[m]),
                        mask - 2));
            }

            public long Permutation(long n, long m)
            {
                if (n < m) return 0;

                return Multi(allPermutations[n],
                    Reverse(allPermutations[n - m], mask - 2));
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

            long Reverse(long a, long pow)
            {
                if (pow == 0) return 1;
                else if (pow == 1) return a % mask;
                else
                {
                    long halfMod = Reverse(a, pow / 2);
                    long nextMod = Multi(halfMod, halfMod);
                    if (pow % 2 == 0)
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
