using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_182
{
    class E
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
            int[] hwnm = ReadInts();
            int h = hwnm[0];
            int w = hwnm[1];
            int n = hwnm[2];
            int m = hwnm[3];

            int[,] grid = new int[h, w];
            for(int i = 0; i < n; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                grid[a, b] = 1;
            }
            for(int i = 0; i < m; i++)
            {
                int[] cd = ReadInts();
                int c = cd[0] - 1;
                int d = cd[1] - 1;
                grid[c, d] = 2;
            }

            for(int i = 0; i < h; i++)
            {
                bool bright = false;
                for(int j = 0; j < w; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        if (bright)
                        {
                            grid[i, j] = 3;
                        }
                    }
                    else if (grid[i, j] == 1)
                    {
                        bright = true;
                    }
                    else if (grid[i, j] == 2)
                    {
                        bright = false;
                    }
                }
                bright = false;
                for (int j = w-1; j >=0; j--)
                {
                    if (grid[i, j] == 0)
                    {
                        if (bright)
                        {
                            grid[i, j] = 3;
                        }
                    }
                    else if (grid[i, j] == 1)
                    {
                        bright = true;
                    }
                    else if (grid[i, j] == 2)
                    {
                        bright = false;
                    }
                }
            }
            for (int j = 0; j<w; j++)
            {
                bool bright = false;
                for (int i=0; i <h; i++)
                {
                    if (grid[i, j] == 0)
                    {
                        if (bright)
                        {
                            grid[i, j] = 3;
                        }
                    }
                    else if (grid[i, j] == 1)
                    {
                        bright = true;
                    }
                    else if (grid[i, j] == 2)
                    {
                        bright = false;
                    }
                }
                bright = false;
                for (int i = h-1; i >=0; i--)
                {
                    if (grid[i, j] == 0)
                    {
                        if (bright)
                        {
                            grid[i, j] = 3;
                        }
                    }
                    else if (grid[i, j] == 1)
                    {
                        bright = true;
                    }
                    else if (grid[i, j] == 2)
                    {
                        bright = false;
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (grid[i, j] == 1 || grid[i, j] == 3) { 
                        res++;
                    }
                }
            }

            WriteLine(res);
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
