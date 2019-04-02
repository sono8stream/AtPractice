using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class yuki710
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }
            int length = 100000 + 1000;
            int inf = int.MaxValue / 4;
            int[] dp = new int[length];
            for (int i = 0; i < length; i++) dp[i] = inf;
            dp[0] = 0;
            for (int i = 0; i < n; i++)
            {
                int[] next = new int[length];
                for (int j = 0; j < length; j++) next[j] = inf;
                for (int j = 0; j < length; j++)
                {
                    if (dp[j] == inf) continue;

                    next[j] = Min(next[j], dp[j] + abs[i][1]);
                    int nextIndex = j + abs[i][0];
                    if (nextIndex < length)
                    {
                        next[nextIndex] = Min(next[nextIndex], dp[j]);
                    }
                }
                dp = next;
            }
            int min = int.MaxValue;
            for(int i = 0; i < length; i++)
            {
                min = Min(min, Max(i, dp[i]));
                //if (i <= 10) WriteLine(dp[i]);
            }
            WriteLine(min);
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
