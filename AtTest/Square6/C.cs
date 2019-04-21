using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Square6
{
    class C
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
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j =0; j < w; j++)
                {
                    grid[i, j] = s[j] == '.';
                }
            }
            bool[,] visited = new bool[h, w];
            Queue<int[]> pos = new Queue<int[]>();
            pos.Enqueue(new int[2] { 0, 0 });
            while (pos.Count > 0)
            {
                int[] now = pos.Dequeue();
                if (visited[now[0], now[1]]) continue;

                visited[now[0], now[1]] = true;
                if (grid[now[0], (now[1]+1)%w])
                {
                    pos.Enqueue(new int[2] { now[0], (now[1]+1)%w });
                }
                if (now[0] + 1 < h && grid[now[0] + 1, now[1]])
                {
                    pos.Enqueue(new int[2] { now[0] + 1, now[1] });
                }
            }
            bool line = false;
            for (int i = 0; i < h; i++)
            {
                int lineCnt = 0;
                for (int j = 0; j < w; j++)
                {
                    if (grid[i, j]) lineCnt++;
                }
                if (lineCnt == w) line = true;
            }

            if (line&&visited[h - 1, w - 1])
            {
                WriteLine("Yay!");
            }
            else
            {
                WriteLine(":(");
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
