using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.yukicoder
{
    class _812
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            List<Edge>[] graph = new List<Edge>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<Edge>();
            for(int i = 0; i < m; i++)
            {
                int[] pq = ReadInts();
                int a = pq[0] - 1;
                int b = pq[1] - 1;
                graph[a].Add(new Edge(b));
                graph[b].Add(new Edge(a));
            }
            int q = ReadInt();
            long[][] vals = new long[q][];
            for(int i = 0; i < q; i++)
            {
                long dist = 0;
                long[] distances = Dijkstra(
                        ReadInt() - 1, graph, out dist);

                vals[i] = new long[2];
                long div = 1;
                while (dist > div)
                {
                    vals[i][1]++;
                    div *= 2;
                }
                for (int j = 0; j < n; j++)
                {
                    if (distances[j] < long.MaxValue) vals[i][0]++;
                }
                vals[i][0]--;
            }
            for (int i = 0; i < q; i++)
            {
                WriteLine(vals[i][0] + " " + vals[i][1]);
            }
        }

        static long[] Dijkstra(int startIndex,
            List<Edge>[] graph, out long maxDistance)
        {
            List<Edge> startNode = graph[startIndex];
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
                List<Edge> nowNode = graph[index];
                visitFlags[index] = true;
                maxDistance = Math.Max(maxDistance, distance);

                //Update priority queue
                for (int i = 0; i < nowNode.Count; i++)
                {
                    int nextIndex = nowNode[i].toIndex;
                    if (visitFlags[nextIndex]) continue;

                    long nextDistance = distance + nowNode[i].distance;
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

            public Edge(int toIndex, long distance = 1)
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
