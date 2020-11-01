using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ACL_001
{
    class C
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[,] grid = new int[n, m];
            int pieceCnt = 0;
            for (int i = 0; i < n; i++)
            {
                string row = Read();
                for (int j = 0; j < m; j++)
                {
                    switch (row[j])
                    {
                        case '#':
                            grid[i, j] = -1;
                            break;
                        case '.':
                            grid[i, j] = 0;
                            break;
                        case 'o':
                            grid[i, j] = 1;
                            pieceCnt++;
                            break;
                    }
                }
            }

            List<Edge>[] graph = new List<Edge>[n * m * 2 + 2];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            HashSet<int>[,] pieces = new HashSet<int>[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == -1)
                    {
                        continue;
                    }

                    int now = i * m + j;
                    pieces[i, j] = new HashSet<int>();
                    if (grid[i, j] == 1)
                    {
                        pieces[i, j].Add(now);
                        AddEdge(graph, 0, now + 1, 1, 0);
                    }
                    AddEdge(graph, n * m + now + 1, graph.Length - 1, 1, 0);

                    if (i > 0 && grid[i - 1, j] >= 0)
                    {
                        foreach (int piece in pieces[i - 1, j])
                        {
                            pieces[i, j].Add(piece);
                        }
                    }
                    if (j > 0 && grid[i, j - 1] >= 0)
                    {
                        foreach (int piece in pieces[i, j - 1])
                        {
                            pieces[i, j].Add(piece);
                        }
                    }

                    foreach (int piece in pieces[i, j])
                    {
                        int cost = i - (piece / m) + j - (piece % m);
                        AddEdge(graph, piece + 1, n * m + now + 1, 1, -cost);
                    }
                }
            }

            int res = -(int)MinCostFlow(graph, 0, graph.Length - 1, pieceCnt);

            WriteLine(res);
        }

        static long MinCostFlow(List<Edge>[] graph, int start, int goal,int flow)
        {
            long[] dists = new long[graph.Length];
            int[] prevV = new int[graph.Length];
            int[] prevE = new int[graph.Length];

           long res = 0;
            while (flow > 0)
            {
                for(int i = 0; i < dists.Length; i++)
                {
                    dists[i] = long.MaxValue;
                }
                dists[start] = 0;
                while (true)
                {
                    // 最短経路を探す，負の経路を取りうるのでDijkstraは使えない
                    bool update = false;
                    for (int i = 0; i < dists.Length; i++)
                    {
                        if (dists[i] == long.MaxValue)
                        {
                            continue;
                        }

                        for (int j = 0; j < graph[i].Count; j++)
                        {
                            Edge edge = graph[i][j];
                            int to = edge.to;
                            if (edge.capacity > 0 && dists[to] > dists[i] + edge.cost)
                            {
                                dists[to] = dists[i] + edge.cost;
                                prevV[to] = i;
                                prevE[to] = j;
                                update = true;
                            }
                        }
                    }
                    if (!update)
                    {
                        break;
                    }
                }

                if (dists[goal] == long.MaxValue)
                {
                    // 到達不可，指定した分だけ流せないので0を返す
                    return 0;
                }

                // 最短経路に流せるだけ流す
                int tmpFlow = flow;
                for(int i = goal; i != start; i = prevV[i])
                {
                    tmpFlow = Min(tmpFlow, graph[prevV[i]][prevE[i]].capacity);
                }
                tmpFlow = Min(tmpFlow, flow);
                flow -= tmpFlow;

                res += dists[goal] * tmpFlow;
                for(int i = goal; i != start; i = prevV[i])
                {
                    Edge edge = graph[prevV[i]][prevE[i]];
                    Edge rev = graph[i][edge.reverse];
                    edge.capacity -= tmpFlow;
                    rev.capacity += tmpFlow;
                }
            }

            return res;
        }

        class Edge
        {
            public int to;
            public int capacity;
            public int cost;
            public int reverse;
            public Edge(int to, int capacity,int cost, int reverse)
            {
                this.to = to;
                this.capacity = capacity;
                this.cost = cost;
                this.reverse = reverse;
            }
        }

        static void AddEdge(List<Edge>[] graph,
            int i, int j, int capacity = 1, int cost = 0)
        {
            graph[i].Add(new Edge(j, capacity, cost, graph[j].Count));
            graph[j].Add(new Edge(i, 0, -cost, graph[i].Count - 1));
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
