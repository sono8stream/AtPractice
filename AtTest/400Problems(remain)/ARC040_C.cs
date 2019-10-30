using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._400Problems_remain_
{
    class ARC040_C
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
                    grid[i, j] = s[j] == 'o';
                }
            }
            int cnt = 0;
            int right = n - 1;
            for(int i = 0; i < n; i++)
            {
                while (0 <= right && grid[i, right]) right--;
                if (right == -1) right = n - 1;
                else
                {
                    right--;
                    cnt++;
                }
            }
            WriteLine(cnt);
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
