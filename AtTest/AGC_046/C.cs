using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_046
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
            string[] input = Read().Split();
            string s = input[0];
            int k = int.Parse(input[1]);

            List<int> blocks = new List<int>();
            List<int> zeros = new List<int>();
            int zeroCnt = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    zeroCnt++;
                }
                else
                {
                    if (i == 0 || s[i - 1] == '0')
                    {
                        blocks.Add(1);
                        zeros.Add(zeroCnt);
                    }
                    else
                    {
                        blocks[blocks.Count - 1]++;
                    }
                }
            }

            long mask = 998244353;
            var calculator = new CaseCalculator(mask, s.Length);
            int kMin = Min(k, blocks.Sum());
            long[,] dp = new long[blocks.Count, kMin + 1];
            for(int i = 0; i < blocks.Count; i++)
            {
                dp[i, 0] = 1;
            }
            long res = 0;
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                zeroCnt = zeros[i];
                for (int j = 0; j <= kMin; j++)
                {
                    for (int l = 1; l <= blocks[i]; l++)
                    {
                        if (j + l > kMin)
                        {
                            break;
                        }

                        res += (dp[i, j]) * calculator.Combination(zeroCnt + l - 1, l);
                        res %= mask;
                        if (i > 0 && zeroCnt - 1 >= l)
                        {
                            long val = dp[i, j] * calculator.Combination(zeroCnt + l - 2, l);
                            val %= mask;
                            dp[i - 1, j + l] += val;
                            dp[i - 1, j + l] %= mask;
                        }
                    }
                }
            }

            res++;
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
