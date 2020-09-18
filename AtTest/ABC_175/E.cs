using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_175
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
            int[] rck = ReadInts();
            int r = rck[0];
            int c = rck[1];
            int k = rck[2];

            long[,] grids = new long[r + 1, c + 1];
            for (int i = 0; i < k; i++)
            {
                int[] rcv = ReadInts();
                grids[rcv[0] - 1, rcv[1] - 1] = rcv[2];
            }

            long[,,] dists = new long[r + 1, c + 1, 4];
            for (int i = 0; i <= r; i++)
            {
                for (int j = 0; j <= c; j++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        if (i + 1 <= r)
                        {
                            dists[i + 1, j, 0] = Max(dists[i + 1, j, 0], dists[i, j, l]);
                            if (grids[i, j] > 0 && l + 1 <= 3)
                            {
                                dists[i + 1, j, 0]
                                    = Max(dists[i + 1, j, 0], dists[i, j, l] + grids[i, j]);
                            }
                        }
                        if (j + 1 <= c)
                        {
                            dists[i, j + 1, l] = Max(dists[i, j + 1, l], dists[i, j, l]);
                            if (grids[i, j] > 0 && l + 1 <= 3)
                            {
                                dists[i, j + 1, l + 1]
                                    = Max(dists[i, j + 1, l + 1], dists[i, j, l] + grids[i, j]);
                            }
                        }
                    }
                }
            }

            long res = 0;
            for (int i = 0; i < 4; i++)
            {
                res = Max(res, dists[r, c, i]);
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
