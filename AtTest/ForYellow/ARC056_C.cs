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
            for(int i = 0; i < n; i++)
            {
                int[] row = ReadInts();
                for(int j = 0; j < n; j++)
                {
                    ws[i, j] = row[j];
                }
            }

            int all = 1 << n;
            int[,] minuses = new int[all, n];
            for (int i = 0; i < all; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (((1 << j) & i) > 0)
                    {
                        continue;
                    }

                    for (int l = 0; l < n; l++)
                    {
                        if (((1 << l) & i) > 0)
                        {
                            minuses[i, j] += ws[j, l];
                        }
                    }
                }
            }

            int[] dp = new int[all];
            for(int i = 1; i < all; i++)
            {
                int val = int.MinValue;
                for (int j = i; ; j = (j - 1) & i)
                {
                    int tmp = dp[j];
                    tmp += k;

                    int div = 1;
                    for(int l = 0; l < n; l++)
                    {
                        if ((div & j) > 0)
                        {
                            tmp -= minuses[i - j, l];
                        }
                        div <<= 1;
                    }
                    val = Max(val, tmp);

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
