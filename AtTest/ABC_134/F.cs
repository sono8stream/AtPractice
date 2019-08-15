using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_134
{
    class F
    {
        static void Main(string[] args)
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
            long mask = 1000000000 + 7;
            long[,,] dp = new long[n + 5, n + 5, k + 5];
            dp[0, 0, 0] = 1;
            for(int i = 0; i <= n; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    for(int l = 0; l <= k; l++)
                    {
                        if (l + 2 * j >= k + 5) continue;

                        dp[i + 1, j, l + 2 * j] += dp[i, j, l] * (1 + 2 * j);
                        dp[i + 1, j, l + 2 * j] %= mask;

                        dp[i + 1, j + 1, l + 2 * j] += dp[i, j, l];
                        dp[i + 1, j + 1, l + 2 * j] %= mask;

                        if (j > 0)
                        {
                            dp[i + 1, j - 1, l + 2 * j] += dp[i, j, l] * j * j;
                            dp[i + 1, j - 1, l + 2*j] %= mask;
                        }
                    }
                }
            }

            WriteLine(dp[n, 0, k]);
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
