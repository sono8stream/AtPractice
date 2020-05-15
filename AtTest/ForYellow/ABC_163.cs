using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ABC_163
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
            int n = ReadInt();
            long[] array = ReadLongs();
            long[][] vals = new long[n][];
            for(int i = 0; i < n; i++)
            {
                vals[i] = new long[2] { array[i], i };
            }
            vals = vals.OrderBy(a => -a[0]).ToArray();

            long[,] dp = new long[n, n + 1];
            dp[0, 1] = vals[0][1] * vals[0][0];
            dp[0, 0] = (n - 1 - vals[0][1]) * vals[0][0];

            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    long left= dp[i - 1, j] + Abs(j-vals[i][1]) * vals[i][0];
                    long right = dp[i - 1, j] + Abs(n - 1 - (i - j) - vals[i][1]) * vals[i][0];
                    dp[i, j + 1] = Max(dp[i, j + 1], left);
                    dp[i, j] = Max(dp[i, j], right);
                }
            }

            long res = 0;
            for(int i = 0; i <= n; i++)
            {
                res = Max(res, dp[n - 1, i]);
            }
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
