using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.SoundHound2018
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nmst = ReadInts();
            int n = nmst[0];
            int m = nmst[1];
            int s = nmst[2]-1;
            int t = nmst[3]-1;
            int[][] uvabs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                uvabs[i] = ReadInts();
            }
            Node[] nodes = new Node[n];
            for(int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }
            for(int i = 0; i < m; i++)
            {
                int u = uvabs[i][0] - 1;
                int v = uvabs[i][1] - 1;
                int a = uvabs[i][2];
                nodes[u].edges.Add(new Edge(v, a));
                nodes[v].edges.Add(new Edge(u, a));
            }
            long[] startDistances = Dijkstra(s, nodes);
            nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }
            for (int i = 0; i < m; i++)
            {
                int u = uvabs[i][0] - 1;
                int v = uvabs[i][1] - 1;
                int b = uvabs[i][3];
                nodes[u].edges.Add(new Edge(v, b));
                nodes[v].edges.Add(new Edge(u, b));
            }
            long[] goalDistances = Dijkstra(t, nodes);
            long[] spends = new long[n];
            spends[0] = startDistances[n - 1] + goalDistances[n - 1];
            for(int i = 1; i < n; i++)
            {
                spends[i] = Math.Min(spends[i - 1],
                    startDistances[n - 1 - i] + goalDistances[n - 1 - i]);
            }
            Array.Reverse(spends);
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(Math.Pow(10, 15) - spends[i]);
            }
        }

        //最大距離を帰す
        static long[] Dijkstra(int startIndex,Node[] nodes)
        {
            Node startNode = nodes[startIndex];
            var pQueue = new PriorityQueue<int>();
            var visitFlags = new bool[nodes.Length];
            var distances = new long[nodes.Length];

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
                Node nowNode = nodes[index];
                visitFlags[index] = true;

                //Update priority queue
                for (int i = 0; i < nowNode.edges.Count; i++)
                {
                    int nextIndex = nowNode.edges[i].toIndex;
                    if (visitFlags[nextIndex]) continue;

                    long nextDistance = distance + nowNode.edges[i].distance;
                    if (nextDistance < distances[nextIndex])
                    {
                        distances[nextIndex] = nextDistance;
                        pQueue.Enqueue(nextDistance, nextIndex);
                    }
                }
            }
            return distances;
        }

        class Node
        {
            public List<Edge> edges;
            public Node()
            {
                edges = new List<Edge>();
            }
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

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
