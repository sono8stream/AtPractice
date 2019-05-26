using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_127
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int q = ReadInt();
            int[][] queries = new int[q][];
            for (int i = 0; i < q; i++) queries[i] = ReadInts();

            var list = new List<long>();
            long bSum = 0;
            var minQueue = new PriorityQueue<bool>();
            var maxQueue = new PriorityQueue<bool>();
            long deltaSum = 0;
            minQueue.Enqueue(-queries[0][1], true);
            bSum += queries[0][2];
            for (int i = 1; i < q; i++)
            {
                if (queries[i][0] == 1)
                {
                    long now = queries[i][1];
                    if (now <= -minQueue.Top().Key)
                    {
                        minQueue.Enqueue(-now, true);
                        deltaSum += -minQueue.Top().Key - now;
                        if ((minQueue.Count + maxQueue.Count) % 2 == 0)
                        {
                            maxQueue.Enqueue(-minQueue.Dequeue().Key, true);
                            long delta = maxQueue.Top().Key + minQueue.Top().Key;
                            deltaSum -= delta * minQueue.Count;
                            deltaSum += delta * maxQueue.Count;
                        }
                    }
                    else {
                        maxQueue.Enqueue(now, true);
                        deltaSum += now + minQueue.Top().Key;
                        if ((minQueue.Count + maxQueue.Count) % 2 == 1)
                        {
                            long delta = maxQueue.Top().Key + minQueue.Top().Key;
                            minQueue.Enqueue(-maxQueue.Dequeue().Key, true);
                            deltaSum -= delta * minQueue.Count;
                            deltaSum += delta * maxQueue.Count;
                        }
                    }
                    bSum += queries[i][2];
                }
                else
                {
                    WriteLine(-minQueue.Top().Key + " " + (deltaSum + bSum));
                }
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

            public KeyValuePair<long,T> Top()
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
