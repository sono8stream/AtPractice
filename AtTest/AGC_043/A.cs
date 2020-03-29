using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_043
{
    class A
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

            int[,] costs = new int[h, w];
            if (grid[0, 0])
            {
                costs[0, 0] = 0;
            }
            else
            {
                costs[0, 0] = 1;
            }

            for(int i = 1; i < h; i++)
            {
                if (grid[i - 1, 0] && !grid[i, 0])
                {
                    costs[i, 0] = costs[i - 1, 0] + 1;
                }
                else
                {
                    costs[i, 0] = costs[i - 1, 0];
                }
            }

            for (int i = 1; i < w; i++)
            {
                if (grid[0, i - 1] && !grid[0, i])
                {
                    costs[0, i] = costs[0, i - 1] + 1;
                }
                else
                {
                    costs[0, i] = costs[0, i - 1];
                }
            }

            for(int i = 1; i < h; i++)
            {
                for(int j = 1; j < w; j++)
                {
                    if(grid[i-1, j] && !grid[i, j])
                    {
                        costs[i, j] = costs[i - 1, j] + 1;
                    }
                    else
                    {
                        costs[i, j] = costs[i - 1, j];
                    }

                    if (grid[i, j - 1] && !grid[i, j])
                    {
                        costs[i, j] = Min(costs[i, j], costs[i, j - 1] + 1);
                    }
                    else
                    {
                        costs[i, j] = Min(costs[i, j], costs[i, j - 1]);
                    }
                }
            }

            WriteLine(costs[h - 1, w - 1]);
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
