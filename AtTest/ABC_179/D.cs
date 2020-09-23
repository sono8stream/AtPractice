using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_179
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
            int[][] lrs = new int[k][];
            for(int i = 0; i < k; i++)
            {
                lrs[i] = ReadInts();
            }

            long[] dp = new long[n];
            long mask = 998244353;
            dp[0] = 1;
            dp[1] -= 1;
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    dp[i] += dp[i - 1];
                    dp[i] %= mask;
                }

                for(int j = 0; j < k; j++)
                {
                    int nI = i + lrs[j][0];
                    if (nI >= n)
                    {
                        continue;
                    }

                    dp[nI] += dp[i];
                    dp[nI] %= mask;

                    nI = i + lrs[j][1] + 1;
                    if (nI >= n)
                    {
                        continue;
                    }

                    dp[nI] += mask - dp[i];
                    dp[nI] %= mask;
                }
            }

            WriteLine(dp[n - 1]);
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
