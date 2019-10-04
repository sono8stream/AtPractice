using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_29
{
    class D
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] nml = ReadInts();
            int n = nml[0];
            int m = nml[1];
            int l = nml[2];
            int[][] ptvs = new int[n][];
            double[] bases = new double[n];
            for (int i = 0; i < n; i++) {
                ptvs[i] = ReadInts();
                bases[i] = 1.0 * l / ptvs[i][2];
            }
            double[,] probs = new double[n, m + 1];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j <= m; j++)
                {
                    double val = 1;
                    for(int k = 0; k < m; k++)
                    {
                        if (k < j)
                        {
                            val *= ptvs[i][0] * 0.01;
                            val *= 1.0 * (m - k) / (j - k);
                        }
                        else
                        {
                            val *= 1 - (ptvs[i][0] * 0.01);
                        }
                    }
                    probs[i, j] = val;
                }
            }
            for(int h = 0; h < n; h++)
            {
                double res = 0;
                for(int i = 0; i <= m; i++)
                {
                    double tmp = 1;
                    double time = bases[h] + ptvs[h][1] * i;
                    for (int j = 0; j < n; j++)
                    {
                        if (h == j) continue;
                        double tmp2 = 0;
                        for(int k = 0; k <= m; k++)
                        {
                            if (bases[j] + ptvs[j][1] * k > time) break;
                            tmp2 += probs[j,k];
                        }
                        tmp2 = 1 - tmp2;
                        tmp *= tmp2;
                    }
                    tmp *= probs[h, i];
                    res += tmp;
                }
                WriteLine(res.ToString("F8"));
            }
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
