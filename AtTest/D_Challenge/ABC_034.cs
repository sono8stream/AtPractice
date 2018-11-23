using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_034
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            var ws = new long[n];
            var ps = new int[n];
            for (int i = 0; i < n; i++)
            {
                long[] wp = ReadLongs();
                ws[i] = wp[0];
                ps[i] = (int)wp[1];
            }

            var dp = new long[n, k][];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    dp[i,j] = new long[2] { 0, 0 };
                }
            }
            dp[0, 0] = new long[2] { ws[0], ws[0] * ps[0] };
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < Math.Min(i + 1, k); j++)
                {
                    long v = ws[i] * ps[i];
                    long all = ws[i];
                    if (j > 0)
                    {
                        v += dp[i - 1, j - 1][1];
                        all += dp[i - 1, j - 1][0];
                    }
                    if (dp[i - 1, j][0] == 0
                        || v * dp[i - 1, j][0] > dp[i - 1, j][1] * all)
                    {
                        dp[i, j] = new long[2] { all, v };
                    }
                    else
                    {
                        dp[i, j] = new long[2] {
                            dp[i-1,j][0], dp[i-1,j][1] };
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(dp[i,j][0] + ":" + dp[i,j][1]+" ");
                }
                Console.WriteLine();
            }
            long[] res = dp[n - 1, k - 1];
            Console.WriteLine(1.0 * res[1] / res[0]);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
