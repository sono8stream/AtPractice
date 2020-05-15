using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC032_C
    {
        static StreamWriter sw;
        static void ain(string[] args)
        {
            sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] abs = new int[n][];
            for (int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
                abs[i] = new int[3] { abs[i][0], abs[i][1], i };
            }
            Array.Sort(abs, (a, b) => b[1] - a[1]);

            const int MAX = 1000010;
            int[] dp = new int[MAX];
            int tmp = 0;
            for (int i = MAX - 1; i >= 0; i--)
            {
                if (i < MAX - 1)
                {
                    dp[i] = Max(dp[i], dp[i + 1]);
                }

                while (tmp < n && abs[tmp][1] == i)
                {
                    int to = abs[tmp][0];
                    dp[to] = Max(dp[to], dp[i] + 1);
                    tmp++;
                }
            }

            int[] nums = new int[dp[0]];
            Array.Sort(abs, (a, b) => a[2] - b[2]);
            var vals = new List<int>[dp[0]];
            for (int i = 0; i < dp[0]; i++){
                vals[i] = new List<int>();
            }
            for (int i = 0; i < n; i++)
            {
                int from = dp[0] - dp[abs[i][0]];
                int to = dp[0] - dp[abs[i][1]];
                if (from + 1 == to)
                {
                    vals[from].Add(i);
                }
            }

            WriteLine(dp[0]);
            tmp = 0;
            for (int i = 0; i < dp[0]; i++)
            {
                for(int j = 0;j < vals[i].Count; j++)
                {
                    int idx = vals[i][j];
                    if (tmp <= abs[idx][0])
                    {
                        tmp = abs[idx][1];
                        Write(idx + 1);
                    }
                }
                if (i + 1 < dp[0])
                {
                    Write(" ");
                }
            }
            WriteLine();
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
