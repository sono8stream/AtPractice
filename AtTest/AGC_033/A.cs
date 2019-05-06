using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_033
{
    class A
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
            var queue = new Queue<int[]>();
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j=0;j<w;j++)
                {
                    if (s[j] == '#') queue.Enqueue(new int[3] { i, j, 0 });
                }
            }
            int max = 0;
            while (queue.Count > 0)
            {
                int[] pos = queue.Dequeue();
                if (grid[pos[0], pos[1]] == true) continue;

                grid[pos[0], pos[1]] = true;
                max = Max(max, pos[2]);
                if (pos[0] > 0)
                {
                    queue.Enqueue(new int[3]
                    { pos[0] - 1, pos[1], pos[2] + 1 });
                }
                if (pos[1] > 0)
                {
                    queue.Enqueue(new int[3]
                    { pos[0], pos[1]-1, pos[2] + 1 });
                }
                if (pos[0]+1 <h)
                {
                    queue.Enqueue(new int[3]
                    { pos[0] +1, pos[1], pos[2] + 1 });
                }
                if (pos[1]+1<w)
                {
                    queue.Enqueue(new int[3]
                    { pos[0], pos[1]+1, pos[2] + 1 });
                }
            }
            WriteLine(max);
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
