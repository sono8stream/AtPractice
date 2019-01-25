using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] abcs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abcs[i] = ReadInts();
            }
            int[,] dp = new int[n, 3];
            dp[0, 0] = abcs[0][0];
            dp[0, 1] = abcs[0][1];
            dp[0, 2] = abcs[0][2];
            for(int i = 1; i < n; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 1], dp[i - 1, 2]) + abcs[i][0];
                dp[i, 1] = Math.Max(dp[i - 1, 2], dp[i - 1, 0]) + abcs[i][1];
                dp[i, 2] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]) + abcs[i][2];
            }
            Console.WriteLine(
                Math.Max(Math.Max(dp[n - 1, 0], dp[n - 1, 1]), dp[n - 1, 2]));
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
