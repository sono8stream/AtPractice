using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class BipartiteGraph
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] rc = ReadInts();
            int r = rc[0];
            int c = rc[1];
            bool[,] ccs = new bool[r, c];
            int dotCnt = 0;
            for (int i = 0; i < r; i++)
            {
                string s = Read();
                for (int j = 0; j < c; j++)
                {
                    if (s[j] == '.')
                    {
                        ccs[i, j] = true;
                        dotCnt++;
                    }
                }
            }
            var graph = new List<Edge>[r * c + 2];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }
            for (int i = 1; i <= r * c; i++)
            {
                int rr = (i - 1) / c;
                int cc = (i - 1) % c;
                if (!ccs[rr, cc]) continue;

                if ((rr + cc) % 2 == 0)
                {
                    AddEdge(ref graph, 0, i);
                    if (rr - 1 >= 0) AddEdge(ref graph, i, i - c);
                    if (cc - 1 >= 0) AddEdge(ref graph, i, i - 1);
                    if (cc + 1 < c) AddEdge(ref graph, i, i + 1);
                    if (rr + 1 < r) AddEdge(ref graph, i, i + c);
                }
                else
                {
                    AddEdge(ref graph, i, graph.Length - 1);
                }
            }

            int[] levels;
            int res = 0;
            do
            {
                levels = BFS(graph, 0);
                int[] iterator = new int[r * c + 2];
                int flow = 0;
                do
                {
                    flow = DFS(ref iterator, ref graph, levels,
                        0, r * c + 1, int.MaxValue);
                    res += flow;
                } while (flow > 0);
            } while (levels[r * c + 1] > 0);
            Console.WriteLine(Math.Max(dotCnt - res, res));
        }

        //calc min distance
        static int[] BFS(List<Edge>[] graph, int start)
        {
            int[] levels = new int[graph.Length];
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = -1;
            }
            levels[start] = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int index = queue.Dequeue();
                for (int i = 0; i < graph[index].Count; i++)
                {
                    Edge edge = graph[index][i];
                    if (edge.capacity > 0 && levels[edge.to] < 0)
                    {
                        levels[graph[index][i].to] = levels[index] + 1;
                        queue.Enqueue(graph[index][i].to);
                    }
                }
            }
            return levels;
        }

        static int DFS(ref int[] iterator, ref List<Edge>[] graph,
            int[] levels, int now, int goal, int flow)
        {
            if (now == goal) return flow;

            for (; iterator[now] < graph[now].Count; iterator[now]++)
            {
                Edge edge = graph[now][iterator[now]];
                if (edge.capacity > 0 && levels[now] < levels[edge.to])
                {
                    int cnt = DFS(ref iterator, ref graph, levels,
                        edge.to, goal, Math.Min(flow, edge.capacity));
                    if (cnt > 0)
                    {
                        edge.capacity -= cnt;
                        graph[edge.to][edge.reverse].capacity += cnt;
                        return cnt;
                    }
                }
            }
            return 0;
        }

        class Edge
        {
            public int to;
            public int capacity;
            public int reverse;
            public Edge(int to,int capacity,int reverse)
            {
                this.to = to;
                this.capacity = capacity;
                this.reverse = reverse;
            }
        }

        static void AddEdge(ref List<Edge>[] graph,
            int i, int j, int capacity = 1)
        {
            graph[i].Add(new Edge(j, capacity, graph[j].Count));
            graph[j].Add(new Edge(i, 0, graph[i].Count - 1));
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
