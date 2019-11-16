using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_145
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
            long[] hTmps = ReadLongs();
            long[] hs = new long[n + 1];
            for (int i = 0; i < n; i++) hs[i + 1] = hTmps[i];
            long[,,] dp = new long[n + 1, k + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    for (int l = 0; l <= n; l++)
                    {
                        if (i == 0 && j == 0 && l == 0) continue;
                        dp[i, j, l] = long.MaxValue / 4;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    for (int l = 0; l <= n; l++)
                    {
                        if (dp[i, j, l] == long.MaxValue / 4) continue;
                        if (hs[l] == hs[i + 1])// no change
                        {
                            dp[i + 1, j, i + 1] = Min(dp[i + 1, j, i + 1], dp[i, j, l]);
                            dp[i + 1, j, l] = Min(dp[i + 1, j, l], dp[i, j, l]);
                        }
                        else if (hs[l] > hs[i + 1])
                        {
                            dp[i + 1, j, i + 1] 
                                = Min(dp[i + 1, j, i + 1], dp[i, j, l]);
                            if (j < k)
                            {
                                dp[i + 1, j + 1, l] 
                                    = Min(dp[i + 1, j + 1, l], dp[i, j, l]);
                            }
                        }
                        else
                        {
                            long delta = hs[i + 1] - hs[l];
                            dp[i + 1, j, i + 1]
                                = Min(dp[i + 1, j, i + 1], dp[i, j, l] + delta);
                            if (j < k)
                            {
                                dp[i + 1, j + 1, l]
                                    = Min(dp[i + 1, j + 1, l], dp[i, j, l]);
                            }
                        }
                    }
                }
            }
            long res = long.MaxValue / 4;
            for(int i = 0; i <= k; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    res = Min(res, dp[n, i, j]);
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
