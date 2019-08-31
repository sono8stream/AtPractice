using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TTPC2019
{
    class G
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
            string t = Read();
            long equals = 0;
            long notEquals = 0;
            for (int i = 0; i < t.Length / 2; i++)
            {
                if (t[i] == t[(int)n - i - 1]) equals++;
                else notEquals++;
            }
            long mask = 1000000000 + 7;
            long[] equalPats = new long[equals+1];
            long[] notEqualPats = new long[notEquals+1];
            CaseCalculator calculator = new CaseCalculator(mask, n);
            long pow25 = 1;
            for(long i = 0; i <= equals; i++)
            {
                equalPats[i] = calculator.Combination(equals, i);
                equalPats[i] = calculator.Multi(equalPats[i], pow25);
                pow25 *= 25;
                pow25 %= mask;
                if (i > 0)
                {
                    equalPats[i] += equalPats[i - 1];
                    equalPats[i] %= mask;
                }
            }
            long[] twoPows = new long[notEquals + 1];
            twoPows[0] = 1;
            for(long i = 1; i <= notEquals; i++)
            {
                twoPows[i] = twoPows[i - 1] * 2;
                twoPows[i] %= mask;
            }
            long pow24 = 1;
            for(long i = 0; i <= notEquals; i++)
            {
                notEqualPats[i] = calculator.Multi(
                    calculator.Combination(notEquals, i), twoPows[notEquals - i]);
                notEqualPats[i] = calculator.Multi(notEqualPats[i], pow24);
                pow24 *= 24;
                pow24 %= mask;
            }
            /*
            long[] notEqualSums = new long[notEquals + 1];
            for (long i = 0; i <= notEquals; i++)
            {
                notEqualSums[i] = notEqualPats[i];
                if (i > 0) notEqualSums[i] += notEqualSums[i - 1];
                notEqualSums[i] %= mask;
            }
            */

            long res = 0;
            bool haveCenter = n % 2 == 1;
            for (long i = 0; i <= notEquals; i++)
            {
                long remain = k - notEquals - i;
                if (remain < 0) continue;

                if (!(notEquals == 0 && remain == 1))
                {
                    res += calculator.Multi(notEqualPats[i],
                        equalPats[Min(equals, remain / 2)]);
                }

                if (remain > 0 && haveCenter)
                {
                    long tmp = calculator.Multi(notEqualPats[i],
                        equalPats[Min(equals,(remain - 1) / 2)]);
                    tmp = calculator.Multi(tmp, 25);
                    res += tmp;
                }
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
