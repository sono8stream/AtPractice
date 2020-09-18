using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_176
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
            int[] cs = ReadInts();
            cs[0]--;
            cs[1]--;
            int[] ds = ReadInts();
            ds[0]--;
            ds[1]--;

            bool[,] grid = new bool[h, w];
            int[,] nos = new int[h,w];
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    grid[i, j] = s[j] == '.';
                    nos[i, j] = -1;
                }
            }

            List<HashSet<int>> graph = new List<HashSet<int>>();
            int startNo = 0;
            int goalNo = 0;
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if(!grid[i,j]|| nos[i, j] >= 0)
                    {
                        continue;
                    }

                    int no = graph.Count;
                    graph.Add(new HashSet<int>());
                    Queue<int[]> queTmp = new Queue<int[]>();
                    queTmp.Enqueue(new int[2] { i, j });
                    nos[i, j] = no;
                    while (queTmp.Count > 0)
                    {
                        int[] pos = queTmp.Dequeue();
                        int y = pos[0];
                        int x = pos[1];

                        if (y == cs[0] && x == cs[1])
                        {
                            startNo = no;
                        }
                        if (y == ds[0] && x == ds[1])
                        {
                            goalNo = no;
                        }

                        for (int ii = Max(0, y - 2); ii <= Min(h - 1, y + 2); ii++)
                        {
                            for (int jj = Max(0, x - 2); jj <= Min(w - 1, x + 2); jj++)
                            {
                                if (!grid[ii, jj])
                                {
                                    continue;
                                }

                                int delta = Abs(ii - y) + Abs(jj - x);
                                if (delta > 1&&nos[ii,jj]>=0)
                                {
                                    graph[no].Add(nos[ii, jj]);
                                    graph[nos[ii, jj]].Add(no);
                                }
                                if (delta == 1 && nos[ii, jj] < 0)
                                {
                                    nos[ii, jj] = no;
                                    queTmp.Enqueue(new int[2] { ii, jj });
                                }
                            }
                        }
                    }
                }
            }

            int[] dists = new int[graph.Count];
            for(int i = 0; i < graph.Count; i++)
            {
                dists[i] = int.MaxValue / 2;
            }
            Queue<int> que = new Queue<int>();
            que.Enqueue(startNo);
            dists[startNo] = 0;
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                foreach(int val in graph[now])
                {
                    if (dists[val] <= dists[now] + 1)
                    {
                        continue;
                    }

                    dists[val] = dists[now] + 1;
                    que.Enqueue(val);
                }
            }

            WriteLine(dists[goalNo] == int.MaxValue / 2 ? -1 : dists[goalNo]);
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
