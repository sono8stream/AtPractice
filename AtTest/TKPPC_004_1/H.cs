using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class H
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
            long[] nmk = ReadLongs();
            long n = nmk[0];
            long m = nmk[1];
            long k = nmk[2];
            long[] ts = new long[n];
            for (int i = 1; i < n-1; i++)
            {
                ts[i] = ReadLong();
            }

            List<long[]>[] graph = new List<long[]>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<long[]>();
            for (int i = 0; i < m; i++)
            {
                long[] abcd = ReadLongs();
                long a = abcd[0] - 1;
                long b = abcd[1] - 1;
                long c = abcd[2];
                long d = abcd[3];
                graph[a].Add(new long[3] { b, c, d });
                graph[b].Add(new long[3] { a, c, d });
            }

            long[] distances = new long[n];
            for (int i = 0; i < n; i++) distances[i] = long.MaxValue;

            PriorityQueue<int> queue = new PriorityQueue<int>();
            queue.Enqueue(0, 0);
            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                long distance = pair.Key;
                int now = pair.Value;
                if (distances[now] <= distance) continue;

                distances[now] = distance;
                for (int i = 0; i < graph[now].Count; i++)
                {
                    long next = graph[now][i][0];
                    long nextDistance = distance + ts[now];
                    if (nextDistance % graph[now][i][2] > 0)
                    {
                        nextDistance += graph[now][i][2]
                            - (nextDistance % graph[now][i][2]);
                    }
                    nextDistance += graph[now][i][1];

                    if (distances[next] <= nextDistance) continue;
                    queue.Enqueue(nextDistance, (int)next);
                }
            }

            if (distances[n - 1] <= k) WriteLine(distances[n - 1]);
            else WriteLine(-1);
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
