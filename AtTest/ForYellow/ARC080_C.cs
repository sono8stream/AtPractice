using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC080_C
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
            int n = ReadInt();
            int[] array = ReadInts();
            var segTreeEven = new SegTree<int>(n, int.MaxValue / 10, Min, int.MaxValue/10);
            var segTreeOdd = new SegTree<int>(n, int.MaxValue / 10, Min, int.MaxValue/10);
            var poses = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    segTreeEven.Update(i, array[i]);
                }
                else
                {
                    segTreeOdd.Update(i, array[i]);
                }
                poses[array[i] - 1] = i;
            }

            var que = new PriorityQueue<int[]>();
            que.Enqueue(segTreeEven.Scan(0, n), new int[2] { 0, n });
            while (que.Count > 0)
            {
                var pair = que.Dequeue();
                int top = (int)pair.Key;
                int topPos = poses[top - 1];
                int last;
                if (pair.Value[0] % 2 == 0)
                {
                    last = segTreeOdd.Scan(topPos + 1, pair.Value[1]);
                }
                else
                {
                    last = segTreeEven.Scan(topPos + 1, pair.Value[1]);
                }
                int lastPos = poses[last - 1];

                Write(top + " " + last + " ");

                if (pair.Value[1] - pair.Value[0] <= 2)
                {
                    continue;
                }

                if (pair.Value[0] % 2 == 0)
                {
                    if (pair.Value[0] < topPos)
                    {
                        que.Enqueue(segTreeEven.Scan(pair.Value[0], topPos),
                            new int[2] { pair.Value[0], topPos });
                    }
                    if (topPos + 1 < lastPos)
                    {
                        que.Enqueue(segTreeOdd.Scan(topPos + 1, lastPos),
                            new int[2] { topPos + 1, lastPos });
                    }
                    if (lastPos + 1 < pair.Value[1])
                    {
                        que.Enqueue(segTreeEven.Scan(lastPos + 1, pair.Value[1]),
                            new int[2] { lastPos + 1, pair.Value[1] });
                    }
                }
                else
                {
                    if (pair.Value[0] < topPos)
                    {
                        que.Enqueue(segTreeOdd.Scan(pair.Value[0], topPos),
                            new int[2] { pair.Value[0], topPos });
                    }
                    if (topPos + 1 < lastPos)
                    {
                        que.Enqueue(segTreeEven.Scan(topPos + 1, lastPos),
                            new int[2] { topPos + 1, lastPos });
                    }
                    if (lastPos + 1 < pair.Value[1])
                    {
                        que.Enqueue(segTreeOdd.Scan(lastPos + 1, pair.Value[1]),
                            new int[2] { lastPos + 1, pair.Value[1] });
                    }
                }
            }
            WriteLine();
        }

        class SegTree<T>
        {
            int totalLength;
            T[] tree;
            Func<T, T, T> integrate;
            T exValue;

            public SegTree(int length, Func<T, T, T> integrate, T exValue)
            {
                this.integrate = integrate;
                this.exValue = exValue;
                totalLength = 1;
                while (totalLength < length) totalLength *= 2;

                tree = new T[2 * totalLength - 1];
                for (int i = 0; i < tree.Length; i++) tree[i] = exValue;
            }

            public SegTree(int length, T initialValue,
                Func<T, T, T> integrate, T exValue)
                : this(length, integrate, exValue)
            {
                for (int i = 0; i < length; i++)
                {
                    tree[i + totalLength - 1] = initialValue;
                }
                UpdateAll();
            }

            public void AssignWithoutUpdate(int i, T value)
            {
                tree[i + totalLength - 1] = value;
            }

            public void Update(int i, T value)
            {
                int now = i + totalLength - 1;
                tree[now] = value;
                while (now > 0)
                {
                    now = (now - 1) / 2;
                    tree[now] = integrate(
                        tree[now * 2 + 1], tree[now * 2 + 2]);
                }
            }

            public void UpdateAll()
            {
                for (int i = totalLength - 2; i >= 0; i--)
                {
                    tree[i] = integrate(tree[i * 2 + 1], tree[i * 2 + 2]);
                }
            }

            public T Look(int i) { return tree[i + totalLength - 1]; }

            //[top,last)
            public T Scan(int top, int last)
            {
                return Query(top, last, 0, 0, totalLength);
            }

            T Query(int top, int last, int i, int left, int right)
            {
                if (right <= top || last <= left) return exValue;
                if (top <= left && right <= last) return tree[i];

                T leftValue = Query(top, last, i * 2 + 1,
                    left, (left + right) / 2);
                T rightValue = Query(top, last, (i + 1) * 2,
                    (left + right) / 2, right);

                return integrate(leftValue, rightValue);
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
