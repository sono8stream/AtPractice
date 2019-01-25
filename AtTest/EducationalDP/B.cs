using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class B
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
            int[] hs = ReadInts();
            long[] dp = new long[n];
            dp[0] = 0;
            for (int i = 1; i < n; i++)
            {
                long val = long.MaxValue;
                for(int j = Math.Max(i - k, 0); j < i; j++)
                {
                    val = Math.Min(val, dp[j] + Math.Abs(hs[i] - hs[j]));
                }
                dp[i] = val;
            }
            Console.WriteLine(dp[n - 1]);
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
