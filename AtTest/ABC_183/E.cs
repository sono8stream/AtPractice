using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_183
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
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            bool[,] grid = new bool[h, w];
            for(int i = 0; i < h; i++)
            {
                string row = Read();
                for(int j = 0; j < w; j++)
                {
                    grid[i, j] = row[j] == '.';
                }
            }

            long mask = 1000000000 + 7;
            long[,] dp = new long[h, w];
            long[,] hSums = new long[h, w];
            long[,] vSums = new long[h, w];
            long[,] xSums = new long[h, w];
            dp[0, 0] = 1;
            hSums[0, 0] = 1;
            vSums[0, 0] = 1;
            xSums[0, 0] = 1;
            for (int i = 1; i < h; i++)
            {
                if (grid[i, 0])
                {
                    dp[i, 0] = vSums[i - 1, 0];
                    vSums[i, 0] = vSums[i - 1, 0] + dp[i, 0];
                    vSums[i, 0] %= mask;
                    hSums[i, 0] = dp[i, 0];
                    xSums[i, 0] = dp[i, 0];
                }
            }
            for (int i = 1; i < w; i++)
            {
                if (grid[0, i])
                {
                    dp[0, i] = hSums[0, i - 1];
                    hSums[0, i] = hSums[0, i-1] + dp[0, i];
                    hSums[0, i] %= mask;
                    vSums[ 0,i] = dp[ 0,i];
                    xSums[0,i] = dp[0,i];
                }
            }

            for(int i = 1; i < h; i++)
            {
                for(int j = 1; j < w; j++)
                {
                    if (grid[i, j])
                    {
                        dp[i, j] = hSums[i, j - 1] + vSums[i - 1, j] + xSums[i - 1, j - 1];
                        dp[i, j] %= mask;
                        hSums[i, j] = hSums[i, j - 1] + dp[i, j];
                        hSums[i, j] %= mask;
                        vSums[i, j] = vSums[i - 1, j] + dp[i, j];
                        vSums[i, j] %= mask;
                        xSums[i, j] = xSums[i - 1, j - 1] + dp[i, j];
                        xSums[i, j] %= mask;
                    }
                }
            }

            WriteLine(dp[h - 1, w - 1]);
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
