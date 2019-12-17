using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CF_0837
{
    class B
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
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = 0; j < m; j++)
                {
                    grid[i, j] = s[j];
                }
            }
            if (!(n % 3 == 0 || m % 3 == 0))
            {
                WriteLine("NO");
                return;
            }

            if (n % 3 == 0)
            {
                bool can = true;
                char c1 = grid[0, 0];
                char c2 = grid[n/3, 0];
                char c3 = grid[n / 3 * 2, 0];
                if (c1 == c2 || c2 == c3 || c3 == c1)
                {

                }
                else
                {
                    for (int i = 0; i < n / 3; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            can &= grid[i, j] == c1;
                        }
                    }
                    for (int i = n / 3; i < n / 3 * 2; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            can &= grid[i, j] == c2;
                        }
                    }
                    for (int i = n / 3 * 2; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            can &= grid[i, j] == c3;
                        }
                    }
                    if (can)
                    {
                        WriteLine("YES");
                        return;
                    }
                }
            }
            if (m % 3 == 0)
            {
                bool can = true;
                char c1 = grid[0, 0];
                char c2 = grid[0, m/3];
                char c3 = grid[0, m/3*2];
                if (c1 == c2 || c2 == c3 || c3 == c1)
                {

                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m/3; j++)
                        {
                            can &= grid[i, j] == c1;
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = m/3; j < m / 3*2; j++)
                        {
                            can &= grid[i, j] == c2;
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = m/3*2; j < m; j++)
                        {
                            can &= grid[i, j] == c3;
                        }
                    }
                    if (can)
                    {
                        WriteLine("YES");
                        return;
                    }
                }
            }
            WriteLine( "NO");
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
