using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_15
{
    class D
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
            int[] ts = new int[n];
            for (int i = 0; i < n; i++) ts[i] = ReadInt();
            int[][] abs = new int[m][];
            for(int i = 0; i < m; i++) abs[i] = ReadInts();

            int[,] dp = new int[n, m];
            for(int i = 0; i < m; i++)
            {
                if (abs[i][0] <= ts[0] && ts[0] <= abs[i][1]) dp[0, i] = 0;
                else dp[0, i] = -1;
            }

            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (ts[i] < abs[j][0] || abs[j][1] < ts[i]) dp[i, j] = -1;
                    else
                    {
                        int max = 0;
                        for(int k = 0; k < m; k++)
                        {
                            if (dp[i - 1, k] == -1) continue;

                            max = Max(max, dp[i - 1, k]
                                + Abs(abs[j][2] - abs[k][2]));
                        }
                        dp[i, j] = max;
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < m; i++) res = Max(res, dp[n - 1, i]);
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
