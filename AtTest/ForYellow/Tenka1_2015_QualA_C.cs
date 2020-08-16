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
            for (int i = 0; i < m; i++)
            {
                int[] row = ReadInts();
                for (int j = 0; j < n; j++)
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
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    diffs[i, j] = aGrid[i, j] != bGrid[i, j];
                }
            }

            int[] dx = new int[2] { 1, 0, };
            int[] dy = new int[2] { 0, 1 };
            List<HashSet<int>> graph = new List<HashSet<int>>();
            for (int i = 0; i < m * n + 2; i++)
            {
                graph.Add(new HashSet<int>());
            }
            int diffCnt = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!diffs[i, j])
                    {
                        continue;
                    }

                    diffCnt++;
                    if ((i + j) % 2 == 0)
                    {
                        graph[0].Add(i * n + j + 2);
                    }
                    else
                    {
                        graph[i * n + j + 2].Add(1);
                    }

                    for (int k = 0; k < 2; k++)
                    {
                        int toY = i + dy[k];
                        int toX = j + dx[k];

                        if (0 <= toY && toY < m
                                && 0 <= toX && toX < n
                                && diffs[toY, toX]
                                && aGrid[i, j] != aGrid[toY, toX])
                        {
                            if ((i + j) % 2 == 0)
                            {
                                graph[i * n + j + 2].Add(toY * n + toX + 2);
                            }
                            else
                            {
                                graph[toY * n + toX + 2].Add(i * n + j + 2);
                            }
                        }
                    }
                }
            }

            int matches = MaxFlow(graph, 0, 1);
            int res = matches + (diffCnt - matches * 2);
            WriteLine(res);
        }

        static int MaxFlow(List<HashSet<int>> graph, int start, int goal)
        {
            int res = 0;
            int flow;
            do
            {
                bool[] used = new bool[graph.Count];
                flow = DFS(graph, used, start, goal);
                res += flow;
            } while (flow > 0);

            return res;
        }

        static int DFS(List<HashSet<int>> graph, bool[] used, int now, int goal)
        {
            if (now == goal)
            {
                return 1;
            }

            used[now] = true;

            foreach (int to in graph[now])
            {
                if (used[to])
                {
                    continue;
                }

                int cnt = DFS(graph, used, to, goal);
                if (cnt > 0)
                {
                    graph[now].Remove(to);
                    graph[to].Add(now);
                    return cnt;
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
