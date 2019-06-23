using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CF1182
{
    class B
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
            bool[,] grid = new bool[h, w];
            int allCnt = 0;
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    if (s[j] == '*')
                    {
                        grid[i, j] = true;
                        allCnt++;
                    }
                }
            }

            for(int i = 1; i < h-1; i++)
            {
                for(int j = 1; j < w-1;j++)
                {
                    if (!grid[i, j]) continue;

                    if (!(grid[i - 1, j] && grid[i + 1, j]
                        && grid[i, j + 1] && grid[i, j - 1])) continue;

                    int cnt = 1;
                    for (int k = 1; j + k < w; k++)
                    {
                        if (!grid[i, j + k]) break;

                        cnt++;
                    }
                    for (int k = 1; j - k >=0; k++)
                    {
                        if (!grid[i, j - k]) break;

                        cnt++;
                    }

                    for (int k = 1; i + k < h; k++)
                    {
                        if (!grid[i+k, j]) break;

                        cnt++;
                    }
                    for (int k = 1; i - k >=0; k++)
                    {
                        if (!grid[i - k, j]) break;

                        cnt++;
                    }

                    if (cnt == allCnt)
                    {
                        WriteLine("YES");
                        return;
                    }
                }
            }

            WriteLine("NO");
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
