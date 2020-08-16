using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._600_Div2
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[][] xss = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xss[i] = ReadInts();
            }
            Array.Sort(xss, (a, b) => a[0] - a[1] - (b[0] - b[1]));

            int[,] dp = new int[n, m + 100];
            {
                int left = xss[0][0] - xss[0][1];
                int right = xss[0][0] + xss[0][1];
                if (left >= 1)
                {
                    int init = left - 1;
                    for (int j = 0; j <= Min(right + init,m); j++)
                    {
                        dp[0, j] = init;
                    }
                    for(int j = right + init + 1; j <= m; j++)
                    {
                        dp[0, j] = j - right;
                    }
                }
                else
                {
                    for(int j = right + 1; j <= m; j++)
                    {
                        dp[0, j] = j - right;
                    }
                }
            }
            for (int i = 1; i < n; i++)
            {
                int left = xss[i][0] - xss[0][1];
                int right = xss[i][0] + xss[i][1];
                if (left >= 1)
                {
                    int init = left - 1;
                    for (int j = 0; j <= Min(right + init, m); j++)
                    {
                        dp[i, j] = init;
                    }
                    for (int j = right + init + 1; j <= m; j++)
                    {
                        dp[i, j] = j - right;
                    }
                }
                else
                {
                    for (int j = right + 1; j <= m; j++)
                    {
                        dp[i, j] = j - right;
                    }
                }

                if (left >= 1)
                {
                    for (int j = left; j <= Min(right, m); j++)
                    {
                        dp[i, j] = Min(dp[i, j], dp[i - 1, left - 1]);
                    }
                }

                for(int j = 1; right + j <= m; j++)
                {
                    if (left - j >= 1)
                    {
                        dp[i, right + j] = Min(dp[i, right + j], dp[i - 1, left - j] + j);
                    }
                }
            }

            WriteLine(dp[n - 1, m]);
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
