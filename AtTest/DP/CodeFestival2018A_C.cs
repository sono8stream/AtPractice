using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class CodeFestival2018A_C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            long k = nk[1];
            long[] array = ReadLongs();

            int[] cnts = new int[n];
            int[] cntSums = new int[n];
            for (int i = 0; i < n; i++)
            {
                long val = array[i];
                int cnt = 0;
                while (val > 0)
                {
                    cnt++;
                    val /= 2;
                }
                cnts[i] = cnt;
                cntSums[i] = cnt;
                if (i > 0) cntSums[i] += cntSums[i - 1];
            }
            if (n == 1)
            {
                WriteLine(1);
                return;
            }

            long mask = 1000000000 + 7;
            long max = cntSums[n - 1];
            //WriteLine(max);
            var dp = new long[max + 1, 2];// not 0 or 0
            for (int i = 0; i < cnts[0]; i++)
            {
                dp[i, 0] = 1;
            }
            dp[cnts[0], 1] = 1;
            for (int i = 1; i < n; i++)
            {
                var next = new long[max + 1, 2];
                for (int j = 0; j <= max; j++)
                {
                    for (int l = j; l >= Max(0, j - cnts[i] + 1); l--)
                    {
                        next[j, 0] += dp[l, 0];
                        next[j, 1] += dp[l, 1];
                    }
                    if (j - cnts[i] >= 0)
                    {
                        next[j, 1] += dp[j - cnts[i], 0];
                        next[j, 1] += dp[j - cnts[i], 1];
                    }
                    next[j, 0] %= mask;
                    next[j, 1] %= mask;
                }
                dp = next;
            }
            long res = 0;
            for (int i = 0; i <= Min(max, k); i++)
            {
                res += dp[i, 1];
            }
            if (k <= max)
            {
                res += dp[k, 0];
            }
            res %= mask;
            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
