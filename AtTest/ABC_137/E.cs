using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_137
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
            int[] nmp = ReadInts();
            int n = nmp[0];
            int m = nmp[1];
            int p = nmp[2];

            List<Edge>[] graph = new List<Edge>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<Edge>();
            for(int i = 0; i < m; i++)
            {
                int[] abc = ReadInts();
                int a = abc[0] - 1;
                int b = abc[1] - 1;
                int c = abc[2];
                graph[a].Add(new Edge(b, p - c));
            }

            long[] distances = new long[n];
            for (int i = 0; i < n; i++) distances[i] = long.MaxValue / 2;
            distances[0] = 0;

            for(int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    for(int k =0; k < graph[j].Count; k++)
                    {
                        if(distances[j]+graph[j][k].distance
                            < distances[graph[j][k].to])
                        {
                            distances[graph[j][k].to]
                                = distances[j] + graph[j][k].distance;
                        }
                    }
                }
            }

            bool[] isLoop = new bool[n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < graph[i].Count; j++)
                {
                    if(distances[i]+graph[i][j].distance
                        < distances[graph[i][j].to])
                    {
                        isLoop[i] = true;
                    }
                }
            }

            List<int>[] reverse = new List<int>[n];
            for (int i = 0; i < n; i++) reverse[i] = new List<int>();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < graph[i].Count; j++)
                {
                    reverse[graph[i][j].to].Add(i);
                }
            }
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n - 1);
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                if (visited[now]) continue;

                visited[now] = true;

                for(int i = 0; i < reverse[now].Count; i++)
                {
                    if (visited[reverse[now][i]]) continue;

                    queue.Enqueue(reverse[now][i]);
                }
            }

            bool[] visited2 = new bool[n];
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                if (visited2[now]) continue;

                visited2[now] = true;

                for(int i = 0; i < graph[now].Count; i++)
                {
                    if (visited2[graph[now][i].to]) continue;

                    queue.Enqueue(graph[now][i].to);
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (visited[i] && visited2[i] && isLoop[i])
                {
                    WriteLine(-1);
                    return;
                }
            }

            WriteLine(Max(0, -distances[n - 1]));
        }

        class Edge
        {
            public int to;
            public long distance;

            public Edge(int to,long distance)
            {
                this.to = to;
                this.distance = distance;
            }
        }

        static long BellmanFord(int n, int[,] edges, int start, int goal)
        {
            int m = edges.GetLength(0);
            var distances = new long[n];
            for (int i = 0; i < n; i++)
            {
                distances[i] = long.MaxValue;
            }
            distances[start] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int v = 0; v < m; v++)
                {
                    int a = edges[v, 0];
                    int b = edges[v, 1];
                    long c = edges[v, 2];
                    if (distances[a] != long.MaxValue
                        && distances[b] > distances[a] + c)
                    {
                        distances[b] = distances[a] + c;
                    }
                }
            }

            //negative check
            var negative = new bool[n];
            for (int i = 0; i < n; i++)
            {
                for (int v = 0; v < m; v++)
                {
                    int a = edges[v, 0];
                    int b = edges[v, 1];
                    long c = edges[v, 2];
                    if (distances[a] != long.MaxValue
                        && distances[b] > distances[a] + c)
                    {
                        distances[b] = distances[a] + c;
                        negative[b] = true;
                    }
                    if (negative[a]) negative[b] = true;
                }
            }

            return negative[goal] ? long.MinValue : distances[goal];
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
