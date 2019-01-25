using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nw = ReadInts();
            int n = nw[0];
            int w = nw[1];
            int[][] wvs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                wvs[i] = ReadInts();
            }
            long[] dp = new long[w+1];
            for(int i = 0; i < n; i++)
            {
                long[] newDp = new long[w+1];
                for(int j = 0; j <= w; j++)
                {
                    if (j - wvs[i][0] < 0) newDp[j] = dp[j];
                    else newDp[j] = Math.Max(
                        dp[j], dp[j - wvs[i][0]] + wvs[i][1]);
                }
                dp = newDp;
            }
            Console.WriteLine(dp[w]);
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
