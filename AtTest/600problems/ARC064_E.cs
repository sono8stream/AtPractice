using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class ARC064_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] xys = ReadInts();
            int xs = xys[0];
            int ys = xys[1];
            int xt = xys[2];
            int yt = xys[3];
            int n = ReadInt();

            int[][] xyrs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xyrs[i] = ReadInts();
            }

            List<Edge>[] graph = new List<Edge>[n + 2];
            for (int i = 0; i < n + 2; i++) graph[i] = new List<Edge>();
            double dist = Sqrt(Pow(xs - xt, 2) + Pow(ys - yt, 2));
            graph[0].Add(new Edge(n + 1, dist));
            graph[n + 1].Add(new Edge(0, dist));

            for (int i = 0; i < n; i++)
            {
                double dist1 = Max(0, Sqrt(
                    Pow(xyrs[i][0] - xs, 2)
                    + Pow(xyrs[i][1] - ys, 2)) - xyrs[i][2]);
                graph[0].Add(new Edge(i + 1, dist1));
                graph[i + 1].Add(new Edge(0, dist1));
                double dist2= Max(0, Sqrt(
                    Pow(xyrs[i][0] - xt, 2)
                    + Pow(xyrs[i][1] - yt, 2)) - xyrs[i][2]);
                graph[n + 1].Add(new Edge(i + 1, dist2));
                graph[i + 1].Add(new Edge(n + 1, dist2));
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j) continue;

                    double distTmp = Max(0, Sqrt(
                    Pow(xyrs[i][0] - xyrs[j][0], 2)
                    + Pow(xyrs[i][1] - xyrs[j][1], 2))
                    - xyrs[i][2] - xyrs[j][2]);
                    graph[i + 1].Add(new Edge(j + 1, distTmp));
                    graph[j + 1].Add(new Edge(i + 1, distTmp));
                }
            }

            double maxDistance = 0;
            double[] distances = Dijkstra(0, graph, out maxDistance);
            WriteLine(distances[n + 1]);
        }

        static double[] Dijkstra(int startIndex,
            List<Edge>[] graph, out double maxDistance)
        {
            var pQueue = new PriorityQueue<int>();
            var visitFlags = new bool[graph.Length];
            var distances = new double[graph.Length];
            maxDistance = 0;

            //Initialize nodes
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = long.MaxValue;
                visitFlags[i] = false;
            }
            pQueue.Enqueue(0, startIndex);
            distances[startIndex] = 0;

            while (pQueue.Exist())
            {
                KeyValuePair<double, int> pair = pQueue.Dequeue();
                double distance = pair.Key;
                int index = pair.Value;

                if (visitFlags[index]) continue;

                //Confirm distances
                visitFlags[index] = true;
                maxDistance = Math.Max(maxDistance, distance);

                //Update priority queue
                for (int i = 0; i < graph[index].Count; i++)
                {
                    int nextIndex = graph[index][i].toIndex;
                    if (visitFlags[nextIndex]) continue;

                    double nextDistance = distance + graph[index][i].distance;
                    if (nextDistance < distances[nextIndex])
                    {
                        distances[nextIndex] = nextDistance;
                        pQueue.Enqueue(nextDistance, nextIndex);
                    }
                }
            }
            return distances;
        }

        class Edge
        {
            public int toIndex;
            public double distance;

            public Edge(int toIndex, double distance)
            {
                this.toIndex = toIndex;
                this.distance = distance;
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<double, T>> list;
            private int count;

            public PriorityQueue()
            {
                list = new List<KeyValuePair<double, T>>();
                count = 0;
            }

            private void Add(KeyValuePair<double, T> pair)
            {
                if (count == list.Count)
                {
                    list.Add(pair);
                }
                else
                {
                    list[count] = pair;
                }
                count++;
            }

            private void Swap(int a, int b)
            {
                KeyValuePair<double, T> tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(double key, T value)
            {
                Add(new KeyValuePair<double, T>(key, value));
                int c = count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<double, T> Dequeue()
            {
                KeyValuePair<double, T> pair = list[0];
                count--;
                if (count == 0) return pair;

                list[0] = list[count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= count) break;

                    int c = (c2 >= count || list[c1].Key < list[c2].Key)
                        ? c1 : c2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    p = c;
                }
                return pair;
            }

            public bool Exist() { return count > 0; }
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
