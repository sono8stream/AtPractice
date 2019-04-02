using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class AOJshiritori
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt() + 1;
            string[] strs = new string[n];
            strs[0] = "A";
            for (int i = 1; i < n; i++) strs[i] = Read();

            int[] dp = new int[n];
            dp[0] = 0;
            var dict = new Dictionary<char, int>();
            for(int i = 1; i < n; i++)
            {
                dp[i] = dp[i - 1] + 1;
                if (dict.ContainsKey(strs[i][0]))
                {
                    dp[i] = Min(dp[i], dp[dict[strs[i][0]]]);
                    dict[strs[i][0]] = i;
                }
                else
                {
                    dict.Add(strs[i][0], i);
                }
            }
            WriteLine(dp[n-1]);
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
