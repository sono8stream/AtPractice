using AtTest.EducationalDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2015_QualA_C
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
            int[] mn = ReadInts();
            int m = mn[0];
            int n = mn[1];
            bool[,] aGrid = new bool[m, n];
            bool[,] bGrid = new bool[m, n];
            for(int i = 0; i < m; i++)
            {
                int[] row = ReadInts();
                for(int j = 0; j < n; j++)
                {
                    aGrid[i, j] = row[j] == 1;
                }
            }
            for (int i = 0; i < m; i++)
            {
                int[] row = ReadInts();
                for (int j = 0; j < n; j++)
                {
                    bGrid[i, j] = row[j] == 1;
                }
            }

            bool[,] diffs = new bool[m, n];
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    diffs[i, j] = aGrid[i, j] != bGrid[i, j];
                }
            }

            int res = 0;
            bool[,] used = new bool[m, n];
            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (!diffs[i, j] || used[i, j])
                    {
                        continue;
                    }

                    Queue<int[]> que = new Queue<int[]>();
                    que.Enqueue(new int[2] { i, j });
                    while (que.Count > 0)
                    {
                        int[] pos = que.Dequeue();
                        int y = pos[0];
                        int x = pos[1];
                        if (used[y, x])
                        {
                            continue;
                        }

                        used[y, x] = true;
                    }
                }
            }
        }

        static int[] BFS(HashSet<int>[] graph, int start)
        {
            int[] levels = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                levels[i] = -1;
            }

            levels[start] = 0;
            Queue<int> que = new Queue<int>();
            que.Enqueue(start);
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                foreach (int to in graph[now])
                {
                    if (levels[to] >= 0)
                    {
                        continue;
                    }

                    levels[to] = levels[now] + 1;
                    que.Enqueue(to);
                }
            }
            return levels;
        }

        static int DFS(HashSet<int>[] graph, int[] levels, int now, int goal)
        {
            if (now == goal)
            {
                return 1;
            }

            foreach (int to in graph[now])
            {
                if (levels[now] < levels[to])
                {
                    int cnt = DFS(graph, levels, to, goal);
                    if (cnt > 0)
                    {
                        graph[now].Remove(to);
                        graph[to].Add(now);
                        return cnt;
                    }
                }
            }
            return 0;
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
