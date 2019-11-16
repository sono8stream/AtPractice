using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_145
{
    class E
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
            int[] nt = ReadInts();
            int n = nt[0];
            int t = nt[1];
            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }
            Array.Sort(abs, (a, b) => a[0] - b[0]);
            int[,] dp = new int[n, t + 1];
            dp[0, Min(t, abs[0][0])] = abs[0][1];
            for(int i = 1; i < n; i++)
            {
                for (int j = 0; j <= t; j++) dp[i, j] = dp[i - 1, j];
                for(int j = 0; j < t; j++)
                {
                    int next = Min(t, j + abs[i][0]);
                    dp[i, next] = Max(dp[i, next], dp[i - 1, j] + abs[i][1]);
                }
            }
            int res = 0;
            for (int i = 0; i <= t; i++) res = Max(res, dp[n - 1, i]);
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
