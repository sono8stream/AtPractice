using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_130
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] ss = ReadInts();
            int[] ts = ReadInts();

            long mask = 1000000000 + 7;
            long[,] dp = new long[n + 1, m + 1];
            long[,] sums = new long[n + 1, m + 1];
            dp[0, 0] = 1;
            sums[0, 0] = 1;
            for (int i = 1; i <= n; i++) sums[i, 0] = 1;
            for (int i = 1; i <= m; i++) sums[0, i] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (ss[i - 1] == ts[j - 1]) dp[i, j] = sums[i - 1, j - 1];
                    sums[i, j] = dp[i, j];
                    sums[i, j] += sums[i - 1, j] + sums[i, j - 1]
                        - sums[i - 1, j - 1];
                    while (sums[i, j] < 0) sums[i, j] += mask;
                    sums[i, j] %= mask;
                }
            }

            WriteLine(sums[n, m]);
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
