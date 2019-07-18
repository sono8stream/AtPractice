using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class AGC022_C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            for (int i = 0; i < n; i++)
            {
                if (aArray[i] == bArray[i]) continue;

                if ((aArray[i] % 2 == 0 && bArray[i] >= aArray[i] / 2)
                    || (aArray[i] % 2 == 1 && bArray[i] > aArray[i] / 2))
                {
                    WriteLine(-1);
                    return;
                }
            }

            long res = 0;
            HashSet<int> used = new HashSet<int>();
            while (true)
            {
                long[,] costs = new long[n, 51];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < 51; j++)
                    {
                        costs[i, j] = long.MaxValue;
                    }
                }

                long maxCost = 0;
                for(int i = 0; i < n; i++)
                {
                    PriorityQueue<int> que = new PriorityQueue<int>();
                    que.Enqueue(0, aArray[i]);
                    while (que.Count > 0)
                    {
                        var pair = que.Dequeue();
                        int now = pair.Value;
                        long cost = pair.Key;
                        if (costs[i, now] <= cost) continue;

                        costs[i, now] = cost;
                        for(int j = 1; j <= now; j++)
                        {
                            long nextCost = cost + (long)Pow(2, j);
                            if (used.Contains(j)) nextCost = cost;

                            int to = now % j;
                            if (costs[i, to] <= nextCost) continue;

                            que.Enqueue(nextCost, to);
                        }
                    }

                    maxCost = Max(maxCost, costs[i, bArray[i]]);
                }

                if (maxCost == 0) break;

                int dig = 1;
                while (maxCost >= Pow(2, dig)) dig++;
                dig--;
                res += (long)Pow(2, dig);
                used.Add(dig);
            }

            WriteLine(res);
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
