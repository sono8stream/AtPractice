using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_142
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
            int[][] abs = new int[m][];
            int[][] cs = new int[m][];
            for (int i = 0; i < m; i++)
            {
                abs[i] = ReadInts();
                cs[i] = ReadInts();
            }
            int[][] vals = new int[m][];
            for(int i = 0; i < m; i++)
            {
                int val = 0;
                for(int j = 0; j < abs[i][1]; j++)
                {
                    val += 1 << (cs[i][j] - 1);
                }
                vals[i] = new int[2] { abs[i][0], val };
            }
            int allPat = 1 << n;
            long[] dp = new long[allPat];
            for (int i = 0; i < allPat; i++) dp[i] = long.MaxValue / 4;
            dp[0] = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < allPat; j++)
                {
                    int next = j | vals[i][1];
                    dp[next] = Min(dp[next], dp[j] + vals[i][0]);
                }
            }
            if (dp[allPat - 1] == long.MaxValue / 4) WriteLine(-1);
            else WriteLine(dp[allPat - 1]);
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
