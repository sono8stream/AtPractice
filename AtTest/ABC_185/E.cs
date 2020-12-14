using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_185
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
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();

            int[,] dp = new int[n + 1, m + 1];
            for (int i = 1; i <= n; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 1; j <= m; j++)
            {
                dp[0, j] = j;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    dp[i, j] = dp[i - 1, j] + 1;
                    dp[i, j] = Min(dp[i, j], dp[i, j - 1] + 1);
                    if (aArray[i - 1] == bArray[j - 1])
                    {
                        dp[i, j] = Min(dp[i, j], dp[i - 1, j - 1]);
                    }
                    else
                    {
                        dp[i, j] = Min(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                }
            }

            WriteLine(dp[n, m]);
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
