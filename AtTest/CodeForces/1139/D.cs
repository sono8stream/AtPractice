using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1139
{
    class D
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
            long m = ReadLong();
            long mask = 1000000000 + 7;
            long[] dp = new long[m+1];
            long sq = ((m - 1) * (m - 1)) % mask;
            long def = (m * Reverse(sq, mask - 2, mask)) % mask;
            long rev = Reverse(m, mask - 2, mask);
            long[] ins = new long[m + 1];
            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j * j <= i; j++)
                {
                    if (i % j != 0) continue;
                    ins[j]++;
                    if (j * j != i) ins[i / j]++;
                }
            }
            for(long i = m; i > 1; i--)
            {
                dp[i] += def;
                dp[i] %= mask;
                long cnt = 0;
                for (long j = 2; j * j <= i; j++)
                {
                    if (i % j != 0) continue;

                    dp[j] += (dp[i] + def) * (m / j) % mask * rev;
                    dp[j] %= mask;
                    cnt++;
                    if (j * j < i)
                    {
                        dp[i / j] += (dp[i] + def) * (m / (i / j)) % mask * rev;
                        dp[i / j] %= mask;
                        cnt++;
                    }
                }
                dp[1] += (dp[i] + 1) * (m - cnt - 1) % mask * rev;
                dp[1] %= mask;
            }
            dp[1] += rev;
            dp[1] %= mask;
            WriteLine(dp[1]);
        }

        static long Reverse(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = Reverse(a, pow / 2, mask);
                long nextMod = (halfMod * halfMod) % mask;
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return (nextMod * a) % mask;
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
