using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC200420
{
    class D
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            while (true)
            {
                int[] hw = ReadInts();
                int h = hw[0];
                int w = hw[1];
                if (h == 0)
                {
                    break;
                }

                bool[,] grid = new bool[h, w];
                for(int i = 0; i < h; i++)
                {
                    for(int j = 0; j < w; j++)
                    {
                        grid[i, j] = true;
                    }
                }
                int n = ReadInt();
                for (int i = 0; i < n; i++)
                {
                    int[] yx = ReadInts();
                    int y = yx[0] - 1;
                    int x = yx[1] - 1;
                    grid[y, x] = false;
                }

                long[,] dp = new long[h, w];
                dp[0, 0] = 1;
                for(int i = 1; i < h; i++)
                {
                    if (!grid[i, 0])
                    {
                        break;
                    }
                    dp[i, 0] = 1;
                }
                for(int i = 1; i < w; i++)
                {
                    if (!grid[0, i])
                    {
                        break;
                    }
                    dp[0, i] = 1;
                }
                for(int i = 1; i < h; i++)
                {
                    for(int j = 1; j < w; j++)
                    {
                        if (!grid[i, j])
                        {
                            continue;
                        }

                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }

                WriteLine(dp[h - 1, w - 1]);
            }
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
