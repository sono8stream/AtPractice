using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class H
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            bool[,] grid = new bool[h, w];
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    grid[i, j] = s[j] == '.';
                }
            }
            int[,] dp = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                if (!grid[i, 0]) break;
                dp[i, 0] = 1;
            }
            for (int i = 0; i < w; i++)
            {
                if (!grid[0, i]) break;
                dp[0, i] = 1;
            }
            int mask = 1000000000 + 7;
            for(int i = 1; i < h; i++)
            {
                for(int j = 1; j < w; j++)
                {
                    if (!grid[i, j]) continue;
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                    dp[i, j] %= mask;
                }
            }
            Console.WriteLine(dp[h - 1, w - 1]);
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
