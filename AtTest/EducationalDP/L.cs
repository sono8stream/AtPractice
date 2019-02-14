using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class L
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            long[,] dp = new long[n, n];
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j < n; j++)
                {
                    bool first = (n - (i - j)) % 2 == 1;
                    long right = i == n - 1 ? 0 : dp[i + 1, j];
                    long left = j == 0 ? 0 : dp[i, j - 1];
                    if (first)
                    {
                        dp[i, j] = Math.Max(right + array[i],
                            left + array[j]);
                    }
                    else
                    {
                        dp[i, j] = Math.Min(right - array[i],
                            left - array[j]);
                    }
                }
            }
            Console.WriteLine(dp[0, n - 1]);
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
