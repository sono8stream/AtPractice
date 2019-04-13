using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC7
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s = Read();
            int[] cs = ReadInts();
            var rCnts = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                rCnts[i] = new List<int>();
                rCnts[i].Add(1);
                if (i > 0)
                {
                    if (s[i] == s[i - 1]) rCnts[i].Add(2);
                    for(int j = 0; j < rCnts[i - 1].Count; j++)
                    {
                        int prev = i - 1 - rCnts[i - 1][j];
                        if (prev >= 0 && s[i] == s[prev])
                        {
                            rCnts[i].Add(rCnts[i - 1][j] + 2);
                        }
                    }
                }
            }
            var dp = new int[n];
            for(int i = 0; i < n; i++)
            {
                dp[i] = int.MaxValue;
                for(int j = 0; j < rCnts[i].Count; j++)
                {
                    int next = cs[rCnts[i][j] - 1];
                    if (i - rCnts[i][j] >= 0) next += dp[i - rCnts[i][j]];
                    dp[i] = Min(dp[i], next);
                }
            }
            WriteLine(dp[n - 1]);
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
