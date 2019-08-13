using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Otemae_2019
{
    class F
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
            int[] nd = ReadInts();
            int n = nd[0];
            int d = nd[1];
            long[][] ms = new long[d][];
            for(int i = 0; i < d; i++)
            {
                ms[i] = ReadLongs();
            }

            long[,] dp = new long[d + 1, n + 1];
            for(int i = 0; i <= d; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    dp[i, j] = long.MaxValue / 2;
                }
            }
            dp[0, 0] = 0;
            for(int i = 0; i < d; i++)
            {
                long sum = 0;
                for (int j = 0; j < n; j++) sum += ms[i][j];
                long[] sums = new long[n + 1];
                sums[0] = sum;
                for(int j = 1; j <= n; j++)
                {
                    sums[j] = sums[j - 1] - ms[i][j - 1];
                }

                long minCost = long.MaxValue;
                for(int j = 0; j <= n; j++)
                {
                    minCost = Min(minCost, dp[i, j]);
                    dp[i + 1, j] = minCost + Abs(sum - sums[j] * 2);
                }
            }

            long res = long.MaxValue;
            for (int i = 0; i <= n; i++) res = Min(res, dp[d, i]);
            WriteLine(res);
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
