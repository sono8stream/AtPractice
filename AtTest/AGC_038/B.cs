using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_038
{
    class B
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] ps = ReadInts();

            HashSet<long> hashSet = new HashSet<long>();
            PriorityQueue<bool> ascQueue = new PriorityQueue<bool>();
            PriorityQueue<bool> descQueue = new PriorityQueue<bool>();
            int incCnt = 0;
            for(int i = 0; i < k; i++)
            {
                hashSet.Add(ps[i]);
                ascQueue.Enqueue(ps[i], true);
                descQueue.Enqueue(-ps[i], true);
                if (i > 0 && ps[i] > ps[i - 1]) incCnt++;
                else incCnt = 0;
            }
            bool ordered = incCnt == k - 1;
            int res = 1;
            for (int i = 1; i + k <= n; i++)
            {
                if (ps[i + k - 1] > ps[i + k - 2]) incCnt++;
                else incCnt = 0;
                if (ascQueue.Top().Key == ps[i - 1]
                    && -descQueue.Top().Key < ps[i + k - 1]) { }
                else if (ordered && incCnt == k - 1) { }
                else
                {
                    res++;
                }
                hashSet.Remove(ps[i - 1]);
                hashSet.Add(ps[i + k - 1]);
                ascQueue.Enqueue(ps[i + k - 1], true);
                descQueue.Enqueue(-ps[i + k - 1], true);
                while (!hashSet.Contains(ascQueue.Top().Key))
                {
                    ascQueue.Dequeue();
                }
                while (!hashSet.Contains(-descQueue.Top().Key))
                {
                    descQueue.Dequeue();
                }
                if (incCnt == k - 1) ordered = true;
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
