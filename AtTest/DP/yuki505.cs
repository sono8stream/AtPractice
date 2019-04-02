using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class yuki505
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            long[,] dp = new long[n, 2];//plus max/minus max
            dp[0, 0] = array[0];
            dp[0, 1] = array[0];
            for(int i = 1; i < n; i++)
            {
                if (array[i] == 0)
                {
                    dp[i, 0] = Max(
                        Max(
                        Max(dp[i - 1, 0] + array[i], dp[i - 1, 0] - array[i]),
                        dp[i - 1, 0] * array[i]),
                        Max(
                        Max(dp[i - 1, 1] + array[i], dp[i - 1, 1] - array[i]),
                        dp[i - 1, 1] * array[i]));
                    dp[i, 1] = Min(
                        Min(
                        Min(dp[i - 1, 0] + array[i], dp[i - 1, 0] - array[i]),
                        dp[i - 1, 0] * array[i]),
                        Min(
                        Min(dp[i - 1, 1] + array[i], dp[i - 1, 1] - array[i]),
                        dp[i - 1, 1] * array[i]));
                }
                else
                {
                    dp[i, 0] = Max(
                        Max(
                        Max(dp[i - 1, 0] + array[i], dp[i - 1, 0] - array[i]),
                        Max(dp[i - 1, 0] * array[i], dp[i - 1, 0] / array[i])),
                        Max(
                        Max(dp[i - 1, 1] + array[i], dp[i - 1, 1] - array[i]),
                        Max(dp[i - 1, 1] * array[i], dp[i - 1, 1] / array[i])));
                    dp[i, 1] = Min(
                        Min(
                        Min(dp[i - 1, 0] + array[i], dp[i - 1, 0] - array[i]),
                        Min(dp[i - 1, 0] * array[i], dp[i - 1, 0] / array[i])),
                        Min(
                        Min(dp[i - 1, 1] + array[i], dp[i - 1, 1] - array[i]),
                        Min(dp[i - 1, 1] * array[i], dp[i - 1, 1] / array[i])));
                }
            }
            WriteLine(dp[n - 1, 0]);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
