using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _019
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] rck = ReadInts();
            int r = rck[0];
            int c = rck[1];
            int k = rck[2];
            char[,] grid = new char[r, c];
            int[] start = new int[2] { 0, 0 };
            int[] goal = new int[2] { 0, 0 };
            for(int i = 0; i < r; i++)
            {
                char[] str = Read().ToCharArray();
                for(int j = 0; j < c; j++)
                {
                    grid[i, j] = str[j];
                    if (str[j] == 'S')
                    {
                        start = new int[2] { i, j };
                    }
                    if (str[j] == 'G')
                    {
                        goal = new int[2] { i, j };
                    }
                }
            }

            int[,,] dists = new int[r, c, k + 1];
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    for(int l = 0; l <= k; l++)
                    {
                        dists[i, j, l] = -1;
                    }
                }
            }

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(start);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
