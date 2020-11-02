using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_107
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];

            long mask = 998244353;
            /*
            long[,] dp = new long[n + 1, n + 1];
            dp[0, 0] = 1;
            for(int i = 1; i <= n; i++)
            {
                for(int j = n; j > 0; j--)
                {
                    dp[i, j] += dp[i - 1, j - 1];
                    if (j * 2 <= n)
                    {
                        dp[i, j] += dp[i, j * 2];
                    }
                    dp[i, j] %= mask;
                }
            }

            WriteLine(dp[n, k]);
            */

            // 分割回数，最小値の個数
            long[,] dp = new long[n + 1, n + 1];
            dp[0, k] = 1;

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
