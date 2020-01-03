using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_148
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
            int[] nuv = ReadInts();
            int n = nuv[0];
            int u = nuv[1]-1;
            int v = nuv[2]-1;
            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            if (graph[u].Count==1&&graph[u][0]==v)
            {
                WriteLine(0);
                return;
            }

            int[] tCosts = new int[n];
            int[] aCosts = new int[n];
            BFS(tCosts, u, graph);
            BFS(aCosts, v, graph);
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                if (graph[i].Count == 1) continue;
                if (aCosts[i] >= tCosts[i]) res = Max(res, aCosts[i]);
            }
            WriteLine(res);
        }

        static void BFS(int[] costs,int start,List<int>[] graph)
        {
            Queue<int[]> queue = new Queue<int[]>();
            for(int i = 0; i < costs.Length; i++)
            {
                costs[i] = int.MaxValue / 4;
            }
            queue.Enqueue(new int[2] { start, 0 });
            while (queue.Count > 0)
            {
                int[] val = queue.Dequeue();
                int i = val[0];
                int cost = val[1];
                if (costs[i] <= cost) continue;

                costs[i] = cost;
                for(int j = 0; j < graph[i].Count; j++)
                {
                    int to = graph[i][j];
                    int next = cost + 1;
                    if (costs[to] <= next) continue;
                    queue.Enqueue(new int[2] { to, next });
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
