using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_143
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
            int[] nml = ReadInts();
            int n = nml[0];
            int m = nml[1];
            int l = nml[2];
            long[,] distances = new long[n, n];
            for (int i= 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    distances[i, j] = i == j ? 0 : long.MaxValue / 4;
                }
            }
            for (int i = 0; i < m; i++)
            {
                int[] abc = ReadInts();
                if (abc[2] > l) continue;

                distances[abc[0] - 1, abc[1] - 1] = abc[2];
                distances[abc[1] - 1, abc[0] - 1] = abc[2];
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        distances[j, k] = Min(distances[j, k],
                            distances[j, i] + distances[i, k]);
                    }
                }
            }

            long[,] costs = new long[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    costs[i, j] = distances[i, j] <= l ? 1 : long.MaxValue / 4;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        costs[j, k] = Min(costs[j, k],
                            costs[j, i] + costs[i, k]);
                    }
                }
            }

            int q = ReadInt();
            for (int i = 0; i < q; i++)
            {
                int[] st = ReadInts();
                int s = st[0] - 1;
                int t = st[1] - 1;
                if (costs[s, t] == long.MaxValue / 4)
                {
                    WriteLine(-1);
                }
                else
                {
                    WriteLine(costs[s, t]-1);
                }
            }
        }

        class Edge
        {
            public int to;
            public  long distance;
            public Edge(int to,long distance)
            {
                this.to = to;
                this.distance = distance;
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;

            public int Count { get; private set; }

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                Count = 0;
            }

            private void Add(KeyValuePair<long, T> pair)
            {
                if (Count == list.Count)
                {
                    list.Add(pair);
                }
                else
                {
                    list[Count] = pair;
                }
                Count++;
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
                int c = Count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<long, T> Top()
            {
                return list[0];
            }

            public KeyValuePair<long, T> Dequeue()
            {
                KeyValuePair<long, T> pair = list[0];
                Count--;
                if (Count == 0) return pair;

                list[0] = list[Count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= Count) break;

                    int c = (c2 >= Count || list[c1].Key < list[c2].Key)
                        ? c1 : c2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    p = c;
                }
                return pair;
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
