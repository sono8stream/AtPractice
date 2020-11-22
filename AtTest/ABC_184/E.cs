using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_184
{
    class E
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

            char[,] states = new char[h, w];
            var poses = new Dictionary<char, List<int>>();
            int start = -1;
            int goal = -1;
            for (int i = 0; i < h; i++)
            {
                string row = Read();
                for (int j = 0; j < w; j++)
                {
                    states[i, j] = row[j];
                    if (row[j] >= 'a' && row[j] <= 'z')
                    {
                        if (!poses.ContainsKey(row[j]))
                        {
                            poses.Add(row[j], new List<int>());
                        }
                        poses[row[j]].Add(i * w + j);
                    }
                    if (row[j] == 'S')
                    {
                        start = i * w + j;
                    }
                    if (row[j] == 'G')
                    {
                        goal = i * w + j;
                    }
                }
            }

            int nodes = h * w;
            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, 1, 0, -1 };
            var que = new Queue<int[]>();
            que.Enqueue(new int[2] { start, 0 });
            int[] dists = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                dists[i] = int.MaxValue;
            }
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                int dist = val[1];
                if (dists[now] <= dist)
                {
                    continue;
                }
                dists[now] = dist;

                char state = states[now / w, now % w];
                if (poses.ContainsKey(state))
                {
                    foreach (int to in poses[state])
                    {
                        if (dists[to] < dist + 1)
                        {
                            continue;
                        }
                        que.Enqueue(new int[2] { to, dist + 1 });
                    }
                    poses.Remove(state);
                }

                for (int i = 0; i < 4; i++)
                {
                    int yy = now / w + dy[i];
                    int xx = now % w + dx[i];
                    if (yy < 0 || yy >= h || xx < 0 || xx >= w)
                    {
                        continue;
                    }
                    if (states[yy, xx] == '#')
                    {
                        continue;
                    }
                    if (dists[yy * w + xx] < dist + 1)
                    {
                        continue;
                    }

                    que.Enqueue(new int[2] { yy * w + xx, dist + 1 });
                }
            }

            WriteLine(dists[goal] == int.MaxValue ? -1 : dists[goal]);
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
