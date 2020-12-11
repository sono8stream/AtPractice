using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1393
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            char[,] grid = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                string row = Read();
                for (int j = 0; j < m; j++)
                {
                    grid[i, j] = row[j];
                }
            }

            int[,] ups = new int[n, m];
            int[,] downs = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ups[i, j] = 1;
                    if (i > 0 && grid[i, j] == grid[i - 1, j])
                    {
                        ups[i, j] += ups[i - 1, j];
                    }
                }
            }
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < m; j++)
                {
                    downs[i, j] = 1;
                    if (i + 1 < n && grid[i, j] == grid[i + 1, j])
                    {
                        downs[i, j] += downs[i + 1, j];
                    }
                }
            }

            int[,] leftDP = new int[n, m];
            int[,] rightDP = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    leftDP[i, j] = 1;
                    if (j > 0 && grid[i, j] == grid[i, j - 1])
                    {
                        int edgeLen = Min(ups[i, j], downs[i, j]);
                        leftDP[i, j] = Min(leftDP[i, j - 1] + 1, edgeLen);
                    }
                }
                for (int j = m - 1; j >= 0; j--)
                {
                    rightDP[i, j] = 1;
                    if (j + 1 < m && grid[i, j] == grid[i, j + 1])
                    {
                        int edgeLen = Min(ups[i, j], downs[i, j]);
                        rightDP[i, j] = Min(rightDP[i, j + 1] + 1, edgeLen);
                    }
                }
            }

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    res += Min(leftDP[i, j], rightDP[i, j]);
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
