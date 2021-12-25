using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_222
{
    class D
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
            int[] arrayA = ReadInts();
            int[] arrayB = ReadInts();
            int mask = 998244353;

            int[,] dp = new int[n, 3005];
            for(int i = arrayA[0]; i <= 3000; i++)
            {
                if (i <= arrayB[0])
                {
                    dp[0, i] = 1;
                }
                if (i > 0)
                {
                    dp[0, i] += dp[0, i - 1];
                    dp[0, i] %= mask;
                }
            }

            for(int i = 1; i < n; i++)
            {
                for(int j = arrayA[i]; j <= 3000; j++)
                {
                    if (j <= arrayB[i])
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    if (j > 0)
                    {
                        dp[i, j] += dp[i, j - 1];
                        dp[i, j] %= mask;
                    }
                }
            }

            WriteLine(dp[n - 1, arrayB[n - 1]]);
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
