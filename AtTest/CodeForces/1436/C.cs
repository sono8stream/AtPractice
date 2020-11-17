using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1436
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
            int[] nxp = ReadInts();
            int n = nxp[0];
            int x = nxp[1];
            int p = nxp[2];

            int bottom = 0;
            int top = n;
            int upperCnt = 0;
            int lowerCnt = 0;
            while (bottom < top)
            {
                int mid = (bottom + top) / 2;
                if (mid <= p)
                {
                    bottom = mid + 1;
                    if (mid < p)
                    {
                        lowerCnt++;
                    }
                }
                else
                {
                    top = mid;
                    upperCnt++;
                }
            }

            
            long mask = 1000000000 + 7;
            var calculator = new CaseCalculator(mask, n);
            int lowers = x - 1;
            int uppers = n - x;
            long res = calculator.Permutation(lowers, lowerCnt);
            res *= calculator.Permutation(uppers, upperCnt);
            res %= mask;
            res *= calculator.Permutation(n -1- lowerCnt - upperCnt, n -1- lowerCnt - upperCnt);
            res %= mask;
            WriteLine(res);
        }

        class CaseCalculator
        {
            long mask;
            long[] allPermutations;
            long[] allInverses;

            public CaseCalculator(long mask, long permutationCnt)
            {
                this.mask = mask;
                allPermutations = AllPermutations(permutationCnt);
                allInverses = AllInverses(permutationCnt);
            }

            public long Combination(long n, long m)
            {
                if (n < m) return 0;

                if (n - m < m) m = n - m;

                return Multi(allPermutations[n], allInverses[n - m], allInverses[m]);
            }

            public long Permutation(long n, long m)
            {
                if (n < m) return 0;

                return Multi(allPermutations[n], allInverses[n - m]);
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

            long[] AllInverses(long n)
            {
                var inverses = new long[n + 1];
                inverses[1] = 1;
                var permInverses = new long[n + 1];
                permInverses[0] = 1;
                permInverses[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    inverses[i] = mask - inverses[mask % i] * (mask / i) % mask;
                    permInverses[i] = Multi(permInverses[i - 1], inverses[i]);
                }
                return permInverses;
            }

            public long Multi(params long[] vals)
            {
                if (vals.Length == 0)
                {
                    return 0;
                }

                long val = vals[0] % mask;
                for (int i = 1; i < vals.Length; i++)
                {
                    val *= (vals[i] % mask);
                    val %= mask;
                }
                return val;
            }

            public long Inverse(long val)
            {
                long a = mask;
                long b = val % mask;
                long x = 1;
                long x1 = 0;
                long y = 0;
                long y1 = 1;
                while (b > 0)
                {
                    long q = a / b;
                    long r = a % b;
                    long x2 = (mask + x - (q * x1) % mask) % mask;
                    long y2 = (mask + y - (q * y1) % mask) % mask;
                    a = b;
                    b = r;
                    x = x1;
                    x1 = x2;
                    y = y1;
                    y1 = y2;
                }
                return y;
            }

            long DeprecatedInverse(long val)
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
