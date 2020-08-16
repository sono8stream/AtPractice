using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2014_QualB_C
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
            int n = ReadInt();
            bool[,] grid = new bool[n, n];
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = 0; j < n; j++)
                {
                    grid[i, j] = s[j] == '#';
                }
            }

            bool[,] res = new bool[n, n];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int now = 0;
                    if (i > 0 && res[i - 1, j])
                    {
                        now++;
                    }
                    if (j > 0 && res[i, j - 1])
                    {
                        now++;
                    }
                    if (j < n - 1 && res[i, j + 1])
                    {
                        now++;
                    }
                    if (grid[i, j])
                    {
                        now++;
                    }

                    if (now % 2 == 1)
                    {
                        res[i + 1, j] = true;
                    }
                    else
                    {
                        res[i + 1, j] = false;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Write(res[i, j] ? '#' : '.');
                }
                WriteLine();
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
