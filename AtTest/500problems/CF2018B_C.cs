using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2018B_C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            bool[,] grid = new bool[n + 2, n + 2];
            int cnt = 0;
            for (int i = 0; i < n + 2; i++)
            {
                int first = (2 * i + 4) % 5;
                for (int j = first; j < n + 2; j += 5)
                {
                    int y = i;
                    if (i == 0) y++;
                    if (i == n + 1) y--;
                    int x = j;
                    if (j == 0) x++;
                    if (j == n + 1) x--;
                    grid[y, x] = true;
                    cnt++;
                }
            }
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    Write(grid[i, j] ? 'X' : '.');
                }
                WriteLine();
            }
            //WriteLine(cnt);
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
