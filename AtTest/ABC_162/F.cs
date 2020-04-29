using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_162
{
    class F
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
            long[] array = ReadLongs();
            long[,] dp = new long[n, 3];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    dp[i, j] = long.MinValue;
                }
            }
            if (n % 2 == 0)
            {
                dp[0, 1] = array[0];
                dp[1, 0] = array[1];
            }
            else
            {
                dp[0, 2] = array[0];
                dp[1, 1] = array[1];
                dp[2, 0] = array[2];
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (dp[i, j] == long.MinValue)
                    {
                        continue;
                    }

                    for(int k = 0; k <= j; k++)
                    {
                        int to = i + 2 + k;
                        if (to >= n)
                        {
                            continue;
                        }

                        dp[to, j - k] = Max(dp[to, j], dp[i, j] + array[to]);
                    }
                }
            }

            long res = long.MinValue;
            if (n % 2 == 0)
            {
                res = Max(dp[n - 1, 0], dp[n - 2, 1]);
            }
            else
            {
                res = Max(dp[n - 1, 0], Max(dp[n - 2, 1], dp[n - 3, 2]));
            }
            WriteLine(res);
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
