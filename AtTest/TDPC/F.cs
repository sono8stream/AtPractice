using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class F
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long mask = 1000000000 + 7;
            long[] dp = new long[n];
            dp[k - 1] = 1;
            long[] all = new long[n];
            all[0] = 1;
            for (int i = 1; i < n-1; i++)
            {
                all[i] = all[i - 1] * 2;
                all[i] %= mask;
            }
            all[n - 1] = all[n - 2];
            for (int i = k; i < n; i++)
            {
                dp[i] = i == n - 1 ? dp[i - 1] : dp[i - 1] * 2;
                dp[i] %= mask;
                if (i > k)
                {
                    dp[i] += all[i - k - 1] - dp[i - k - 1];
                    dp[i] %= mask;
                    while (dp[i] < 0) dp[i] += mask;
                }
            }
            long res = all[n - 1] - dp[n - 1];
            while (res < 0) res += mask;
            Console.WriteLine(res);
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
