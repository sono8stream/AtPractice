using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TokioMarine_2020
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
            int n = ReadInt();
            int[][] vws = new int[n][];
            for (int i = 0; i < n; i++)
            {
                vws[i] = ReadInts();
            }
            int half = Min(n, 1 << 10 - 1);
            int[,] dp = new int[half, 100000 + 100];
            dp[0, vws[0][1]] = vws[0][0];
            for (int i = 1; i < 100000 + 100; i++)
            {
                dp[0, i] = Max(dp[0, i], dp[0, i - 1]);
            }
            for (int i = 1; i < half; i++)
            {
                for (int j = 0; j < 100000 + 100; j++)
                {
                    dp[i, j] = dp[(i - 1) / 2, j];
                    if (j >= vws[i][1])
                    {
                        dp[i, j] = Max(dp[i, j], dp[(i - 1) / 2, j - vws[i][1]] + vws[i][0]);
                    }
                }
            }

            int q = ReadInt();
            for (int i = 0; i < q; i++)
            {
                int[] vl = ReadInts();
                int v = vl[0] - 1;
                int l = vl[1];

                WriteLine(DFS(v, l, half, dp, vws));
            }
        }

        static int DFS(int now,int l,int half,int[,] dp,int[][]vws)
        {
            if (now < half)
            {
                return dp[now, l];
            }

            int parent = (now - 1) / 2;

            int res = DFS(parent, l, half, dp, vws);
            if (vws[now][1] <= l)
            {
                res = Max(res, DFS(parent, l - vws[now][1], half, dp, vws) + vws[now][0]);
            }

            return res;
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
