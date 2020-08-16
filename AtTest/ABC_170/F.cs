using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_170
{
    class F
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
            int[] hwk = ReadInts();
            int h = hwk[0];
            int w = hwk[1];
            int k = hwk[2];
            int[] xys = ReadInts();
            int y1 = xys[0] - 1;
            int x1 = xys[1] - 1;
            int y2 = xys[2] - 1;
            int x2 = xys[3] - 1;

            bool[,] grid = new bool[h, w];
            for (int i = 0; i < h; i++)
            {
                string line = Read();
                for (int j = 0; j < w; j++)
                {
                    grid[i, j] = line[j] == '.';
                }
            }

            Queue<int> que = new Queue<int>();
            int[,] dists = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    dists[i, j] = int.MaxValue / 2;
                }
            }
            dists[y1, x1] = 0;
            que.Enqueue(y1 * w + x1);
            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            while (que.Count > 0)
            {
                int val = que.Dequeue();
                int nextDist = dists[val / w, val % w] + 1;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j <= k; j++)
                    {
                        int toX = val % w + dx[i] * j;
                        int toY = val / w + dy[i] * j;

                        if (toX >= 0 && toX < w && toY >= 0 && toY < h
                            && grid[toY, toX] && nextDist <= dists[toY, toX])
                        {
                            if (nextDist < dists[toY, toX])
                            {
                                dists[toY, toX] = nextDist;
                                que.Enqueue(toY * w + toX);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (dists[y2, x2] == int.MaxValue / 2)
            {
                WriteLine(-1);
            }
            else
            {
                WriteLine(dists[y2, x2]);
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
