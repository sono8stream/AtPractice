using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day2
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            var graph = new List<Edge>[n * (k + 1)];
            for (int i = 0; i < graph.Length; i++) graph[i] = new List<Edge>();

            for(int i = 0; i < m; i++)
            {
                int[] abc = ReadInts();
                int a = abc[0] - 1;
                int b = abc[1] - 1;
                int c = abc[2];

                for(int j = 0; j <= k; j++)
                {
                    graph[a + j * n].Add(new Edge(b + j * n, c));
                    graph[b + j * n].Add(new Edge(a + j * n, c));
                }
            }

            for(int i = 0; i < n; i++)
            {
                int[] xy = ReadInts();
                int x = xy[0];
                int y = xy[1];
                for(int j = 0; j <= k; j++)
                {
                    int next = i + Min(n * (j + x), n * k);
                    graph[i + n * j].Add(new Edge(next, y));
                }
            }

            long maxDist = 0;
            long[] distances = Dijkstra(0, graph, out maxDist);
            if (distances[n * (k + 1) - 1] == long.MaxValue)
            {
                WriteLine(-1);
            }
            else
            {
                WriteLine(distances[n * (k + 1) - 1]);
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
