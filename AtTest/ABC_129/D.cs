using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_129
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];

            int[,] rowCnts = new int[h, w];
            int[,] colCnts = new int[h, w];
            bool[,] grid = new bool[h, w];
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j= 0; j < w; j++)
                {
                    grid[i, j] = s[j] == '.';
                }
            }

            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if (!grid[i, j]) continue;
                    rowCnts[i, j] = 1;
                    if (j > 0) rowCnts[i, j] += rowCnts[i, j - 1];
                }

                for(int j = w - 2; j >= 0; j--)
                {
                    if (grid[i, j] && rowCnts[i, j + 1] > 0)
                    {
                        rowCnts[i, j] = rowCnts[i, j + 1];
                    }
                }
            }
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (!grid[j, i]) continue;
                    colCnts[j, i] = 1;
                    if (j > 0) colCnts[j, i] += colCnts[j - 1, i];
                }

                for (int j = h - 2; j >= 0; j--)
                {
                    if (grid[j, i] && colCnts[j + 1, i] > 0)
                    {
                        colCnts[j, i] = colCnts[j + 1, i];
                    }
                }
            }

            int max = 0;
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if (!grid[i, j]) continue;
                    max = Max(max, rowCnts[i, j] + colCnts[i, j] - 1);
                }
            }
            WriteLine(max);
        }
        class UnionFind
        {
            int[] tree;
            public int[] size;

            public UnionFind(int length)
            {
                tree = new int[length];
                size = new int[length];
                for (int i = 0; i < length; i++)
                {
                    tree[i] = i;
                    size[i] = 1;
                }
            }

            public int Root(int x)
            {
                int rx = x;
                while (tree[rx] != rx)
                {
                    rx = tree[rx];
                }
                tree[x] = rx;
                return rx;
            }

            public bool IsSame(int x, int y)
            {
                return Root(x) == Root(y);
            }

            public void Unite(int x, int y)
            {
                int rx = Root(x);
                int ry = Root(y);
                if (rx == ry) return;

                if (rx > ry)
                {
                    int temp = rx;
                    rx = ry;
                    ry = temp;
                }
                tree[ry] = rx;
                size[rx] += size[ry];
            }

            public int GetSize(int x)
            {
                return size[Root(x)];
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
