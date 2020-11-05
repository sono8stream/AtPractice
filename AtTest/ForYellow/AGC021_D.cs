using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class AGC021_D
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
            string s = Read();
            int n = s.Length;
            int k = ReadInt();

            // 左からi，右からj，l回操作後の共通部分列の長さ
            int[,,] dp = new int[n + 2, n + 2, k + 2];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; i + j <= n; j++)
                {
                    for (int l = 0; l <= k; l++)
                    {
                        int val = Max(dp[i - 1, j, l], dp[i, j - 1, l]);
                        if (s[i-1] == s[n - j])
                        {
                            val = Max(val, dp[i - 1, j - 1, l] + 1);
                        }
                        if (l > 0)
                        {
                            val = Max(val, dp[i - 1, j - 1, l - 1] + 1);
                        }
                        dp[i, j, l] = val;
                    }
                }
            }

            /// Tをiまで，T'をn-iまで見ると，反転させて残りも同じ取り方ができる
            /// 境界にある文字だけ残して後で処理するのが最良の場合もある
            int res = 0;
            for (int i = 0; i <= k; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    res = Max(res, dp[j, n - j, i] * 2);
                    if (j < n)
                    {
                        res = Max(res, dp[j, n - j - 1, i] * 2 + 1);
                    }
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
