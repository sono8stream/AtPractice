using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_10
{
    class C
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
            int[][] kshs = new int[n][];
            for (int i = 0; i < n; i++) kshs[i] = ReadInts();

            double[] dp = new double[m + 1];
            for(int i = 0; i < n; i++)
            {
                double[] heights = new double[m + 1];
                int hI = 1;
                for (int j = 0; j < kshs[i][0]; j++)
                {
                    int limit = kshs[i][1 + j * 2] * kshs[i][2 + j * 2];
                    for (int k = 0; k < limit&&hI<=m; k++)
                    {
                        heights[hI] = heights[hI - 1];
                        heights[hI] += 1.0 / kshs[i][1 + j * 2];
                        hI++;
                    }
                }
                for (; hI <= m; hI++) heights[hI] = heights[hI - 1];

                double[] next = new double[m + 1];
                for (int j = 0; j <= m; j++)
                {
                    for (int k = 0; k + j <= m; k++)
                    {
                        next[k + j] = Max(next[k + j], dp[k] + heights[j]);
                    }
                }

                dp = next;
            }
            WriteLine(dp[m]);
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
