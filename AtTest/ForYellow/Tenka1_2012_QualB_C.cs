using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2012_QualB_C
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
            int[][] ses = new int[n][];
            for (int i = 0; i < n; i++)
            {
                string[] times = Read().Split();
                int start = int.Parse(times[0].Substring(0, 2)) * 60
                    + int.Parse(times[0].Substring(3, 2));
                int end = int.Parse(times[1].Substring(0, 2)) * 60
                    + int.Parse(times[1].Substring(3, 2));
                ses[i] = new int[2] { start, end };
            }

            Array.Sort(ses, (a, b) => a[1] - b[1]);

            int all = 1 << n;
            bool[] ok = new bool[all];
            for (int i = 0; i < all; i++)
            {
                int start = 0;
                int end = 48 * 60;
                bool okTmp = true;
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        if (start <= ses[j][0] && end >= ses[j][1])
                        {
                            start = ses[j][1];
                            end = Min(end, ses[j][0] + 24 * 60);
                        }
                        else
                        {
                            okTmp = false;
                            break;
                        }
                    }
                }
                ok[i] = okTmp;
            }

            int[] dp = new int[all];
            for (int i = 0; i < all; i++)
            {
                dp[i] = int.MaxValue / 2;
            }
            dp[0] = 0;

            for (int i = 1; i < all; i++)
            {
                for (int j = i; j > 0; j = ((j - 1) & i))
                {
                    if (ok[j])
                    {
                        dp[i] = Min(dp[i], dp[i ^ j] + 1);
                    }
                }
            }

            WriteLine(dp[all - 1]);
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
