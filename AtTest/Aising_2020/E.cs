using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Aising_2020
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[][] array = new int[n][];
                for(int j = 0; j < n; j++)
                {
                    array[j] = ReadInts();
                }
                Array.Sort(array, (a, b) => a[0] - b[0]);

                long res = 0;
                bool[] used = new bool[n];
                PriorityQueue<int> que = new PriorityQueue<int>();
                int idx = 0;
                for(int j = 1; j <= n; j++)
                {
                    while (idx < n && array[idx][0] == j)
                    {
                        if (array[idx][1] - array[idx][2] > 0)
                        {
                            que.Enqueue(array[idx][1] - array[idx][2], idx);
                        }
                        idx++;
                    }

                    while (que.Count > j)
                    {
                        que.Dequeue();
                    }
                }
                while (que.Count > 0)
                {
                    var pair = que.Dequeue();
                    res += pair.Key;
                    used[pair.Value] = true;
                }

                idx = n - 1;
                for(int j = n; j >= 1; j--)
                {
                    while (idx >= 0 && array[idx][0] == j)
                    {
                        if (!used[idx]
                            && array[idx][2] - array[idx][1] > 0)
                        {
                            que.Enqueue(array[idx][2] - array[idx][1], idx);
                        }
                        idx--;
                    }

                    while (que.Count > n - j)
                    {
                        que.Dequeue();
                    }
                }
                while (que.Count > 0)
                {
                    var pair = que.Dequeue();
                    res+=pair.Key;
                    used[pair.Value] = true;
                }

                for (int j = 0; j < n; j++)
                {
                    res += Min(array[j][1], array[j][2]);
                }

                WriteLine(res);
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
