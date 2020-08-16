using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_164
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
            int[] nms = ReadInts();
            int n = nms[0];
            int m = nms[1];
            int maxCoins = 3000;
            int s = Min(nms[2], maxCoins - 1);

            List<Edge>[] graph = new List<Edge>[n * maxCoins];
            for(int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] uvab = ReadInts();
                int u = uvab[0] - 1;
                int v = uvab[1] - 1;
                int a = uvab[2];
                int b = uvab[3];

                for(int j = a; j < maxCoins; j++)
                {
                    int from = u * maxCoins + j;
                    int to = v * maxCoins + j - a;
                    graph[from].Add(new Edge(to,b));
                }
                for (int j = a; j < maxCoins; j++)
                {
                    int from = v * maxCoins + j;
                    int to = u * maxCoins + j - a;
                    graph[from].Add(new Edge(to, b));
                }
            }

            for(int i = 0; i < n; i++)
            {
                int[] cd = ReadInts();
                int c = cd[0];
                int d = cd[1];
                for(int j = 0; j+c < maxCoins; j++)
                {
                    int from = i * maxCoins + j;
                    int to = from + c;
                    graph[from].Add(new Edge(to, d));
                }
            }

            long maxDist = 0;
            long[] dists = Dijkstra(s, graph,out maxDist);
            for(int i = 1; i < n; i++)
            {
                long min = long.MaxValue;
                for(int j = 0; j < maxCoins; j++)
                {
                    min = Min(min, dists[i * maxCoins + j]);
                }
                WriteLine(min);
            }
        }

        static long[] Dijkstra(int startIndex,
            List<Edge>[] graph, out long maxDistance)
        {
            var pQueue = new PriorityQueue<int>();
            var visitFlags = new bool[graph.Length];
            var distances = new long[graph.Length];
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
                KeyValuePair<long, int> pair = pQueue.Dequeue();
                long distance = pair.Key;
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

                    long nextDistance = distance + graph[index][i].distance;
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
            public long distance;

            public Edge(int toIndex, long distance)
            {
                this.toIndex = toIndex;
                this.distance = distance;
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;
            private int count;

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                count = 0;
            }

            private void Add(KeyValuePair<long, T> pair)
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
                KeyValuePair<long, T> tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(long key, T value)
            {
                Add(new KeyValuePair<long, T>(key, value));
                int c = count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<long, T> Dequeue()
            {
                KeyValuePair<long, T> pair = list[0];
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
