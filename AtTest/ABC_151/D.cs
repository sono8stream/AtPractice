using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_151
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
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            bool[,] grid = new bool[h, w];
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    grid[i, j] = s[j] == '.';
                }
            }

            int all = h * w;
            /*int res = 0;
            for(int i = 0; i < all; i++)
            {
                for(int j = 0; j < all; j++)
                {
                    if (!grid[i / w, i % w] || !grid[j / w, j % w]) continue;
                    Queue<int[]> que = new Queue<int[]>();
                    que.Enqueue(new int[2] { i, 0 });
                    bool[,] visited = new bool[h, w];
                    while (que.Count > 0)
                    {
                        int[] val = que.Dequeue();
                        int now = val[0];
                        int cost = val[1];
                        if (visited[now / w, now % w]) continue;
                        if (now == j)
                        {
                            res = Max(res, cost);
                            break;
                        }

                        if (now / w > 0 && grid[now / w - 1, now % w]
                            && !visited[now / w - 1, now % w])
                        {
                            que.Enqueue(new int[2] { now - w, cost + 1 });
                        }
                        if (now / w + 1 < h && grid[now / w + 1, now % w]
                            && !visited[now / w + 1, now % w])
                        {
                            que.Enqueue(new int[2] { now + w, cost + 1 });
                        }
                        if (now %w>0 && grid[now / w, now % w-1]
                            && !visited[now / w, now % w-1])
                        {
                            que.Enqueue(new int[2] { now - 1, cost + 1 });
                        }
                        if (now % w+1< w && grid[now / w, now % w + 1]
                            && !visited[now / w, now % w + 1])
                        {
                            que.Enqueue(new int[2] { now + 1, cost + 1 });
                        }
                    }
                }
            }
            WriteLine(res);
            */
            WarshallFloyd warshall = new WarshallFloyd(all);
            for(int i = 0; i < all; i++)
            {
                for(int j = 0; j < all; j++)
                {
                    warshall.costs[i, j] = int.MaxValue;
                    if (i == j) warshall.costs[i, j] = 0;
                    if ((i / w > 0 && i - j == w)
                        || (i / w + 1 < h && j - i == w)
                        || (i % w > 0 && i - j == 1)
                        || (i % w + 1 < w && j - i == 1)) warshall.costs[i, j] = 1;
                }
            }
            warshall.Calculate(grid,w);
            long res = 0;
            for(int i = 0; i < all; i++)
            {
                for(int j = 0; j < all; j++)
                {
                    if (!grid[i / w, i % w] || !grid[j / w, j % w]) continue;
                    if (warshall.costs[i, j] == int.MaxValue) continue;
                    res = Max(res, warshall.costs[i, j]);
                }
            }
            WriteLine(res);
        }

        class WarshallFloyd
        {
            int n;
            public long[,] costs;

            public WarshallFloyd(int n)
            {
                this.n = n;
                costs = new long[n, n];
            }

            public void Calculate(bool[,] grid,int w)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (!grid[i / w, i % w]
                                || !grid[j / w, j % w]
                                || !grid[k / w, k % w]) continue;
                            costs[j, k] = Min(costs[j, k], costs[j, i] + costs[i, k]);
                        }
                    }
                }
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
