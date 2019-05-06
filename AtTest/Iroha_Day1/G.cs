using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day1
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            long[] array = ReadLongs();

            //i番目，j個目
            long[,] dp = new long[n + 1, m+1];
            for(int i = 0; i <= n; i++)
            {
                for(int j = 0; j <= m; j++)
                {
                    dp[i, j] = -1;
                    dp[i, j] = -1;
                }
            }
            dp[0, 0] = 0;
            long res = -1;

            for (int i = 1; i <= n; i++)
            {

                for (int j = 1; j <= m; j++)
                {
                    long max = -1;
                    for (int l = i - 1; l >= Max(0, i - k); l--)
                    {
                        max = Max(max, dp[l, j - 1]);
                    }
                    if (max == -1) continue;

                    dp[i, j] = max + array[i-1];
                    if (j == m && n - i + 1 <= k) res = Max(res, dp[i, j]);
                }
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
