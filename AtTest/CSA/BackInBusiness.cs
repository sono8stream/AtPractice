using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CSA
{
    class BackInBusiness
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
            int[] start = new int[2];
            int[] final = new int[2];
            List<int[]> ps = new List<int[]>();
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for (int j = 0; j < w; j++)
                {
                    if (s[j] == 'S') start = new int[2] { i, j };
                    if (s[j] == 'F') final = new int[2] { i, j };
                    if (s[j] == 'P') ps.Add(new int[2] { i, j });
                }
            }
            var checkGrid = new bool[h, w];
            for (int i = 0; i < ps.Count; i++)
            {
                checkGrid[ps[i][0], ps[i][1]] = true;
            }
            var checkQueue = new Queue<int[]>();
            checkQueue.Enqueue(start);
            while (checkQueue.Count > 0)
            {
                int[] pos = checkQueue.Dequeue();
                if (checkGrid[pos[0], pos[1]]) continue;

                checkGrid[pos[0], pos[1]] = true;
                if (pos[0] > 0)
                {
                    checkQueue.Enqueue(new int[2] { pos[0] - 1, pos[1] });
                }
                if (pos[0] + 1 < h)
                {
                    checkQueue.Enqueue(new int[2] { pos[0] + 1, pos[1] });
                }
                if (pos[1] > 0)
                {
                    checkQueue.Enqueue(new int[2] { pos[0], pos[1] - 1 });
                }
                if (pos[1] + 1 < w)
                {
                    checkQueue.Enqueue(new int[2] { pos[0], pos[1] + 1 });
                }
            }
            if (!checkGrid[final[0], final[1]])
            {
                WriteLine("impossible");
                return;
            }
            int bottom = 0;
            int top = 2050;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                var movableGrid = new bool[h, w];
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        for (int k = 0; k < ps.Count; k++)
                        {
                            if (Abs(i - ps[k][0]) + Abs(j - ps[k][1]) <= mid)
                            {
                                movableGrid[i, j] = true;
                                continue;
                            }
                        }
                    }
                }
                if (movableGrid[start[0], start[1]]
                    || movableGrid[final[0], final[1]])
                {
                    top = mid;
                    continue;
                }
                var queue = new Queue<int[]>();
                queue.Enqueue(start);
                while (queue.Count > 0)
                {
                    int[] pos = queue.Dequeue();
                    if (movableGrid[pos[0], pos[1]]) continue;

                    movableGrid[pos[0], pos[1]] = true;
                    if (pos[0] > 0)
                    {
                        queue.Enqueue(new int[2] { pos[0] - 1, pos[1] });
                    }
                    if (pos[0] + 1 < h)
                    {
                        queue.Enqueue(new int[2] { pos[0] + 1, pos[1] });
                    }
                    if (pos[1] > 0)
                    {
                        queue.Enqueue(new int[2] { pos[0], pos[1] - 1 });
                    }
                    if (pos[1] + 1 < w)
                    {
                        queue.Enqueue(new int[2] { pos[0], pos[1] + 1 });
                    }
                }

                if (movableGrid[final[0], final[1]]) top = mid;
                else bottom = mid;
            }
            WriteLine(bottom + 1);
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
