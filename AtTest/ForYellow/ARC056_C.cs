using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC056_C
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];

            int[,] ws = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = ReadInts();
                for (int j = 0; j < n; j++)
                {
                    ws[i, j] = row[j];
                }
            }

            int all = 1 << n;
            int[] sums = new int[all];
            for (int i = 1; i < all; i++)
            {
                int top = 0;
                int topVal = 1;
                while (topVal * 2 <= i)
                {
                    topVal *= 2;
                    top++;
                }

                int tmp = 0;
                for (int j = 0; j < top; j++)
                {
                    if (((1 << j) & i) > 0)
                    {
                        tmp += ws[top, j];
                    }
                }
                sums[i] = sums[i - topVal] + tmp;
            }

            int[] dp = new int[all];
            for (int i = 1; i < all; i++)
            {
                int val = int.MinValue;
                int top = 0;
                int topVal = 1;
                while (topVal * 2 <= i)
                {
                    top++;
                    topVal *= 2;
                }


                for (int j = i - topVal; ; j = (j - 1) & i)
                {
                    int minus = sums[i] - sums[i - j - topVal] - sums[j + topVal];
                    val = Max(val, dp[i - j - topVal] + k - minus);

                    if (j == 0)
                    {
                        break;
                    }
                }
                dp[i] = val;
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
