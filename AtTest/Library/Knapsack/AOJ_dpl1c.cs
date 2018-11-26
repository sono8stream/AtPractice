using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.Knapsack
{
    class AOJ_dpl1c
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nw = ReadInts();
            var vws = new int[nw[0]][];
            for(int i = 0; i < nw[0]; i++)
            {
                vws[i] = ReadInts();
            }
            var dp = new int[nw[0], nw[1] + 1];
            for(int i = 0; i < nw[0]; i++)
            {
                for(int j = 1; j < nw[1] + 1; j++)
                {
                    if (i == 0)
                    {
                        if (j-vws[i][1] >= 0)
                        {
                            dp[i, j] = dp[i, j - vws[i][1]] + vws[i][0];
                        }
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                        if (j - vws[i][1] >= 0
                            && dp[i, j - vws[i][1]] + vws[i][0]>dp[i,j])
                        {
                            dp[i, j] = dp[i, j - vws[i][1]] + vws[i][0];
                        }
                    }
                }
            }
            Console.WriteLine(dp[nw[0] - 1, nw[1]]);
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
