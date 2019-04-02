using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class CodeFestival2017Final_D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] hps = new int[n][];
            for(int i = 0; i < n; i++)
            {
                hps[i] = ReadInts();
            }
            hps = hps.OrderBy(a => a[0]+a[1]).ToArray();
            int[] dp = new int[n + 1];
            for (int i = 0; i <= n; i++) dp[i] = int.MaxValue;
            dp[0] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (dp[j] == int.MaxValue) continue;

                    if (dp[j] <= hps[i][0])
                    {
                        dp[j + 1] = Min(dp[j + 1], dp[j] + hps[i][1]);
                    }
                }
            }
            for(int i = n; i >= 0; i--)
            {
                if (dp[i] == int.MaxValue) continue;

                WriteLine(i);
                return;
            }
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
