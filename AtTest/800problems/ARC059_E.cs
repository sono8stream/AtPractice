using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._800problems
{
    class ARC059_E
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
            long[] nc = ReadLongs();
            long n = nc[0];
            long c = nc[1];
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();
            long mask = 1000000000 + 7;
            long[,] sums = new long[c+1, 401];
            for (int i = 0; i <= 400; i++) sums[0, i] = 1;
            for (int i = 1; i <= c; i++)
            {
                for (long j = 0; j <= 400; j++)
                {
                    sums[i, j] = j;
                    if (i > 0) sums[i, j] *= sums[i-1, j];
                    sums[i, j] %= mask;
                }
            }
            for(int i = 0; i <= c; i++)
            {
                for(long j = 1; j <= 400; j++)
                {
                    sums[i, j] += sums[i, j - 1];
                    sums[i, j] %= mask;
                }
            }

            long[,] dp = new long[n+1, c + 1];
            dp[0, 0] = 1;
            for (int i = 0; i < n; i++)
            {
                for(long j = 0; j <= c; j++)
                {
                    long sum = sums[j, bArray[i]] - sums[j, aArray[i]-1];
                    if (sum < 0) sum += mask;

                    for(long k = 0; j + k <= c; k++)
                    {
                        dp[i + 1, j + k] += dp[i, k] * sum;
                        dp[i + 1, j + k] %= mask;
                    }
                }
            }
            WriteLine(dp[n, c]);
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
