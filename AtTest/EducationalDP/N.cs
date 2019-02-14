using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class N
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            long[,] dp = new long[n, n];
            for(int i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    long minCost = long.MaxValue;
                    long sum = 0;
                    for (int k = i; k + 1 <= j; k++)
                    {
                        minCost = Math.Min(minCost,
                            dp[i, k] + dp[k + 1, j]);
                        sum += array[k];
                    }
                    sum += array[j];
                    dp[i, j] = minCost + sum;
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
