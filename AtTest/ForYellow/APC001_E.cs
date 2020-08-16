using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class APC001_E
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
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0];
                int b = ab[1];
                graph[a].Add(b);
                graph[b].Add(a);
            }

            int[] leaves = new int[n];
            DFS(graph, 0, -1, leaves);

            int res = 0;
            DFS2(graph, 0, ref res, 0, leaves);
            WriteLine(res);
        }

        static void DFS(List<int>[] graph, int now, int parent, int[] leaves)
        {
            var sorted = new List<int>();
            if (parent >= 0 && graph[now].Count == 1)
            {
                leaves[now] = 1;
            }
            else
            {
                for (int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (to == parent)
                    {
                        continue;
                    }

                    DFS(graph, to, now, leaves);
                    leaves[now] += leaves[to];
                    sorted.Add(to);
                }
            }
            graph[now] = sorted.OrderBy(a => leaves[a]).ToList();
        }

        static void DFS2(List<int>[] graph, int now, ref int res, int cnt, int[] leaves)
        {
            if (graph[now].Count == 0)
            {
                res++;
                return;
            }

            bool ignored = false;
            int nodes = graph[now].Count;
            if (now != 0)
            {
                nodes++;
            }
            for (int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];

                if (i == 0 && leaves[to] == 1 && graph[now].Count > 1
                    && graph[now].Count - 1 + cnt == nodes - 1)
                {
                    ignored = true;
                    continue;
                }

                int nextCnt = 0;
                if (cnt == 1 || (ignored && graph[now].Count > 2)
                    || (!ignored && graph[now].Count > 1))
                {
                    nextCnt = 1;
                }
                else
                {
                    nextCnt = 0;
                }
                DFS2(graph, to, ref res, nextCnt, leaves);
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
