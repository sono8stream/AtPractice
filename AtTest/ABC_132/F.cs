using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_132
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];

            List<long> cnts = new List<long>();
            List<long> topCnts = new List<long>();
            long bottom = 1;
            long top = n;
            for (; bottom * bottom <= n; bottom++)
            {
                cnts.Add(1);

                long topNext = n / bottom;
                if (bottom > 1) topCnts.Add(top - topNext);
                top = topNext;
            }
            if (top - bottom + 1 > 0) topCnts.Add(top - bottom + 1);
            topCnts.Reverse();
            cnts.AddRange(topCnts);
            for (int i = 1; i < cnts.Count; i++) cnts[i] += cnts[i - 1];

            long mask = 1000000000 + 7;
            long[] dp = new long[cnts.Count];
            for(int i = 0; i < cnts.Count; i++)
            {
                long val = i == 0 ? cnts[i] : cnts[i] - cnts[i - 1];
                dp[i] = cnts[cnts.Count - i - 1] * val;
                if (i > 0) dp[i] += dp[i - 1];
                dp[i] %= mask;
            }
            for(int i = 0; i < k - 2; i++)
            {
                long[] next = new long[cnts.Count];
                for(int j = 0; j < cnts.Count; j++)
                {
                    long val = j == 0 ? cnts[j] : cnts[j] - cnts[j - 1];
                    next[j] = dp[cnts.Count - j - 1] * val;
                    if (j > 0) next[j] += next[j - 1];
                    next[j] %= mask;
                }
                dp = next;
            }

            WriteLine(dp[cnts.Count - 1]);
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
