using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class M
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
            int[] array = ReadInts();
            long[,] dp = new long[100, k+1];
            long mask = 1000000000 + 7;
            for (int i = 0; i <= Math.Min(array[0], k); i++) dp[0, i] = 1;
            for (int i = 1; i < n; i++)
            {
                long[] sums = new long[k+1];
                sums[0] = dp[i - 1, 0];
                for (int j = 1; j <= k; j++)
                {
                    sums[j] = sums[j - 1] + dp[i - 1, j];
                }
                for (int j = 0; j <= k; j++)
                {
                    int index = j - array[i] - 1;
                    dp[i, j] = sums[j];
                    if (index >= 0) dp[i, j] -= sums[index];
                    dp[i, j] %= mask;
                }
            }
            Console.WriteLine(dp[n - 1, k]);
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
