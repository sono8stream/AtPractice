using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC102_E
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
            long[] kn = ReadLongs();
            long k = kn[0];
            long n = kn[1];
            long mask = 998244353;

            CaseCalculator calculator = new CaseCalculator(mask, n + k - 1);

            long allPat = calculator.Combination(n + k - 1, n);

            long[] res = new long[2 * k - 1];

            long prevPats = 0;
            for(long val = 2; val <= k+1; val++)
            {
                long pats = Min(val - 2, 2 * k - val) / 2 + 1;
                if (pats == prevPats)
                {
                    res[val - 2] = res[val - 3];
                    res[2 * k - val] = res[val - 3];
                    continue;
                }

                long seqCnt = Min(pats, n / 2);
                long resTmp = allPat;
                for (long i = 1; i <= seqCnt; i++)
                {
                    long tmp = calculator.Combination(pats, i);
                    tmp = calculator.Multi(tmp,
                        calculator.Combination(k - 1 + n - i * 2, k - 1));
                    if (i % 2 == 1)
                    {
                        resTmp += mask - tmp;
                    }
                    else
                    {
                        resTmp += tmp;
                    }
                    resTmp %= mask;
                }

                res[val - 2] = resTmp;
                res[2 * k - val] = resTmp;
                prevPats = pats;
            }

            for (int i = 0; i < 2 * k - 1; i++) WriteLine(res[i]);
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
