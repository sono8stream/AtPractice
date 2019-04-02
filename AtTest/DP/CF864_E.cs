using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class CF864_E
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] tdps = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] tdp = ReadInts();
                tdps[i] = new int[4] { tdp[0], tdp[1], tdp[2], i };
            }
            tdps = tdps.OrderBy(a => a[1]).ToArray();
            int[,] dp = new int[n + 1, 5000];
            for(int i = 0; i <= n; i++)
            {
                for(int j = 0; j < 5000; j++)
                {
                    dp[i, j] = int.MinValue;
                }
            }
            dp[0, 0] = 0;
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5000; j++)
                {
                    if (dp[i, j] >= 0)
                    {
                        dp[i + 1, j] = Max(dp[i, j], dp[i + 1, j]);
                    }
                    int nextTime = j + tdps[i][0];
                    if (nextTime < tdps[i][1])
                    {
                        dp[i + 1, nextTime] = Max(
                            dp[i + 1, nextTime], dp[i, j] + tdps[i][2]);
                    }
                }
            }
            int time = 0;
            for(int i = 0; i < 5000; i++)
            {
                if (dp[n, i] > dp[n, time]) time = i;
            }
            WriteLine(dp[n, time]);
            List<int> choices = new List<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                int prevVal = dp[i + 1, time] - tdps[i][2];
                int prevTime = time - tdps[i][0];
                if (prevTime >= 0 && dp[i, prevTime] == prevVal)
                {
                    choices.Add(tdps[i][3] + 1);
                    time = prevTime;
                }
            }
            WriteLine(choices.Count);
            choices.Reverse();
            choices.ForEach(a => Write(a + " "));
            WriteLine();
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
