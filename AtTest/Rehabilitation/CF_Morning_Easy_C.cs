using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class CF_Morning_Easy_C
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] st = ReadInts();
            int s = st[0]-1;
            int t = st[1]-1;

            List<(long,int)>[] graph = new List<(long,int)>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<(long, int)>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] xyd = ReadInts();
                int x = xyd[0]-1;
                int y = xyd[1]-1;
                int d = xyd[2];
                graph[x].Add((d, y));
                graph[y].Add((d, x));
            }

            long[] sDists = new long[n];
            for(int i = 0; i < n; i++)
            {
                sDists[i] = int.MaxValue;
            }
            var que = new PriorityQueue<int>();
            que.Enqueue(0, s);
            while (que.Count > 0)
            {
                var pair = que.Dequeue();
                long dist = pair.Key;
                int now = pair.Value;
                if (dist >= sDists[now])
                {
                    continue;
                }

                sDists[now] = dist;
                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i].Item2;
                    long nextDist = dist + graph[now][i].Item1;

                    if (nextDist >= sDists[to])
                    {
                        continue;
                    }

                    que.Enqueue(nextDist, to);
                }
            }

            long[] tDists = new long[n];
            for (int i = 0; i < n; i++)
            {
                tDists[i] = int.MaxValue;
            }
            que = new PriorityQueue<int>();
            que.Enqueue(0, t);
            while (que.Count > 0)
            {
                var pair = que.Dequeue();
                long dist = pair.Key;
                int now = pair.Value;
                if (dist >= tDists[now])
                {
                    continue;
                }

                tDists[now] = dist;
                for (int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i].Item2;
                    long nextDist = dist + graph[now][i].Item1;

                    if (nextDist >= tDists[to])
                    {
                        continue;
                    }

                    que.Enqueue(nextDist, to);
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (sDists[i] < int.MaxValue && sDists[i] == tDists[i])
                {
                    WriteLine(i + 1);
                    return;
                }
            }

            WriteLine(-1);
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
