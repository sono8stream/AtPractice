using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _100
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
            int n = ReadInt();
            int[] array = ReadInts();
            int all = 1 << n;
            int[,][] dp = new int[all, 2][];
            for (int i = 0; i < all; i++)
            {
                dp[i, 0] = new int[2] { array[i], i };
                dp[i, 1] = new int[2] { 0, -1 };
            }
            for (int i = 0; i < all; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int next = i | (1 << j);
                    if ( next > i)
                    {
                        int[][] vals = new int[4][] { dp[next, 0], dp[next, 1], dp[i, 0], dp[i, 1] };
                        Array.Sort(vals, (a, b) => a[0] - b[0]);
                        dp[next, 0] = vals[3];
                        if (vals[3][1] == vals[2][1])
                        {
                            dp[next, 1] = vals[1];
                        }
                        else
                        {
                            dp[next, 1] = vals[2];
                        }
                    }
                }
            }
            int max = 0;
            for(int i = 1; i < all; i++)
            {
                max = Max(max, dp[i, 0][0] + dp[i, 1][0]);
                WriteLine(max);
            }
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
