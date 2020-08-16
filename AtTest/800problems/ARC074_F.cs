using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._800problems
{
    class ARC074_F
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
            string[] array = new string[h];
            for (int i = 0; i < h; i++)
            {
                array[i] = Read();
            }

            List<Edge>[] graph = new List<Edge>[h + w + 2];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            int s = 0;
            int t = 0;
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if (array[i][j] == '.') continue;

                    if (array[i][j] == 'S')
                    {
                        s = i * w + j;
                        graph[0].Add(new Edge(i + 2, 100000, graph[i + 2].Count));
                        graph[i + 2].Add(new Edge(0, 0, graph[0].Count - 1));
                        graph[0].Add(new Edge(h + 2 + j, 100000, graph[h + 2 + j].Count));
                        graph[h + 2 + j].Add(new Edge(0, 0, graph[0].Count - 1));
                    }
                    else if (array[i][j] == 'T')
                    {
                        t = i * w + j;
                        graph[1].Add(new Edge(i + 2, 0, graph[i + 2].Count));
                        graph[i + 2].Add(new Edge(1, 100000, graph[1].Count - 1));
                        graph[1].Add(new Edge(h + 2 + j, 0, graph[h + 2 + j].Count));
                        graph[h + 2 + j].Add(new Edge(1, 100000, graph[1].Count - 1));
                    }
                    else
                    {
                        graph[i + 2].Add(new Edge(h + 2 + j, 1, graph[h + 2 + j].Count));
                        graph[h + 2 + j].Add(new Edge(i + 2, 1, graph[i + 2].Count - 1));
                    }
                }
            }

            if (s % w == t % w || s / w == t / w)
            {
                WriteLine(-1);
                return;
            }

            int[] levels;
            int res = 0;
            do
            {
                levels = BFS(graph, 0);
                int[] iterator = new int[h + w + 2];
                int flow = 0;
                do
                {
                    flow = DFS(ref iterator, ref graph, levels,
                        0, 1, 100000);
                    res += flow;
                } while (flow > 0);
            } while (levels[1] > 0);
            WriteLine(res);
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
                        levels[edge.to] = levels[index] + 1;
                        queue.Enqueue(edge.to);
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
                        edge.to, goal, Min(flow, edge.capacity));
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
            public Edge(int to, int capacity, int reverse)
            {
                this.to = to;
                this.capacity = capacity;
                this.reverse = reverse;
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
