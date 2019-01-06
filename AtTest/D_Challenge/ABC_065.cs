using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_065
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var xys = new int[n][];
            var nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                int[] xy = ReadInts();
                xys[i] = new int[3] { xy[0], xy[1], i };
                nodes[i] = new Node();
            }
            Array.Sort(xys, (a, b) => a[0] - b[0]);
            for (int i = 0; i < n - 1; i++)
            {
                long distance = Math.Abs(xys[i][0] - xys[i + 1][0]);
                nodes[xys[i][2]].edges.Add(new Edge(xys[i + 1][2], distance));
                nodes[xys[i + 1][2]].edges.Add(new Edge(xys[i][2], distance));
            }
            Array.Sort(xys, (a, b) => a[1] - b[1]);
            for (int i = 0; i < n - 1; i++)
            {
                long distance = Math.Abs(xys[i][1] - xys[i + 1][1]);
                nodes[xys[i][2]].edges.Add(new Edge(xys[i + 1][2], distance));
                nodes[xys[i + 1][2]].edges.Add(new Edge(xys[i][2], distance));
            }

            var pQueue = new PriorityQueue<int>();
            pQueue.Enqueue(0, 0);
            var checks= new bool[n];
            long sum = 0;
            while (pQueue.Exist())
            {
                var pair = pQueue.Dequeue();
                if (checks[pair.Value]) continue;

                checks[pair.Value] = true;
                sum += pair.Key;

                Node nowNode = nodes[pair.Value];
                for(int i = 0; i < nowNode.edges.Count; i++)
                {
                    Edge edge = nowNode.edges[i];
                    if (checks[edge.toIndex]) continue;

                    pQueue.Enqueue(edge.distance, edge.toIndex);
                }
            }
            Console.WriteLine(sum);
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
