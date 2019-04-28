using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class APC001_D
    {
        static void Main(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            long[] array = ReadLongs();
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for (int i = 0; i < m; i++)
            {
                int[] xy = ReadInts();
                int x = xy[0];
                int y = xy[1];
                graph[x].Add(y);
                graph[y].Add(x);
            }
            var queueGroup = new List<PriorityQueue<int>>();
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (visited[i]) continue;

                queueGroup.Add(new PriorityQueue<int>());
                var queue = new Queue<int>();
                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int now = queue.Dequeue();
                    if (visited[now]) continue;

                    visited[now] = true;
                    queueGroup[queueGroup.Count - 1].Enqueue(array[now], now);

                    for (int j = 0; j < graph[now].Count; j++)
                    {
                        if (visited[graph[now][j]]) continue;

                        queue.Enqueue(graph[now][j]);
                    }
                }
            }

            if (queueGroup.Count == 1)
            {
                WriteLine(0);
                return;
            }

            long cost = 0;
            var secondQueue = new PriorityQueue<int>();
            for (int i = 0; i < queueGroup.Count; i++)
            {
                cost +=queueGroup[i].Dequeue().Key;
                while (queueGroup[i].Exist())
                {
                    var pair = queueGroup[i].Dequeue();
                    secondQueue.Enqueue(pair.Key, pair.Value);
                }
            }

            if (secondQueue.Count < queueGroup.Count - 2)
            {
                WriteLine("Impossible");
            }
            else
            {
                for(int i = 0; i < queueGroup.Count - 2; i++)
                {
                    cost += secondQueue.Dequeue().Key;
                }
                WriteLine(cost);
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;
            private int count;
            public int Count { get { return count; } }

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
