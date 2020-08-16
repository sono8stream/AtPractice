using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Nikkei2019_2_qual
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
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];

            if (n == 1)
            {
                if (k == 1)
                {
                    WriteLine("1 2 3");
                }
                else
                {
                    WriteLine(-1);
                }
                return;
            }

            long[,] blocks = new long[3,n];
            for (int i = 0; i < n; i++)
            {
                blocks[0, i] = k + i;
                blocks[1, i] = k + n + i;
                blocks[2, i] = k + 2 * n + i;
            }

            for (int i = 0; i < n; i++)
            {
                long leftMax = blocks[1, n - 1] + blocks[0, n - 1 - i];
                long rightMax = i == 0 ? 0 : blocks[1, i - 1] + blocks[0, n - 1];
                if ((rightMax <= blocks[2, n - 2] && leftMax <= blocks[2, n - 1])
                    || (leftMax <= blocks[2, n - 2] && rightMax <= blocks[2, n - 1]))
                {
                    var que = new PriorityQueue<long>();
                    for(int j = 0; j < n; j++)
                    {
                        que.Enqueue(blocks[0, j] + blocks[1, (j + i) % n], blocks[0, j]);
                    }
                    for(int j = 0; j < n; j++)
                    {
                        var pair = que.Dequeue();
                        WriteLine(pair.Value + " " + (pair.Key - pair.Value) + " " + blocks[2, j]);
                    }
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
