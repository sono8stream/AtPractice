using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1409
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            string s = Read();
            string t = Read();
            char a = t[0];
            char b = t[1];

            // i番目，j回操作，aの個数
            int[,,] dp = new int[n, k + 1, n + 1];
            int aCnt = 0;
            for(int i = 1; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    int remain = k - j + aCnt;
                    for (int l = 0; l <= Min(remain, i); l++)
                    {
                        // 無変換
                        dp[i, j, l] = Max(dp[i, j, l], dp[i - 1, j, l]);

                        // aにする
                        if (s[i] == a)
                        {
                            dp[i, j, l + 1] = Max(dp[i, j, l + 1], dp[i - 1, j, l]);
                        }
                        if (j < k)
                        {
                            dp[i, j + 1, l + 1] = Max(dp[i, j + 1, l + 1], dp[i - 1, j, l]);
                        }

                        // bにする
                        if (s[i] == b)
                        {
                            dp[i, j, l] = Max(dp[i, j, l], l + dp[i - 1, j, l]);
                        }
                        if (j < k)
                        {
                            dp[i, j + 1, l] = Max(dp[i, j + 1, l], l + dp[i - 1, j, l]);
                        }
                    }
                }
                if (s[i] == a)
                {
                    aCnt++;
                }
            }

            long res = 0;
            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j <= Min(aCnt + k, n); j++)
                {
                    res = Max(res, dp[n - 1, i, j]);
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
