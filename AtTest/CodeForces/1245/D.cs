using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1245
{
    class D
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
            int[][] poses = new int[n][];
            for(int i = 0; i < n; i++)
            {
                poses[i] = ReadInts();
            }
            long[] buildCosts = ReadLongs();
            long[] connectCosts = ReadLongs();

            List<long[]>[] graph = new List<long[]>[n + 1];
            for(int i = 0; i <= n; i++)
            {
                graph[i] = new List<long[]>();
            }
            var que = new PriorityQueue<int[]>();
            for(int i = 0; i < n; i++)
            {
                que.Enqueue(buildCosts[i], new int[2] { 0, i + 1 });
                for(int j = i + 1; j < n; j++)
                {
                    long connectCost = connectCosts[i] + connectCosts[j];
                    connectCost *= Abs(poses[i][0] - poses[j][0]) + Abs(poses[i][1] - poses[j][1]);
                    que.Enqueue(connectCost, new int[2] { i + 1, j + 1 });
                }
            }

            long res = 0;
            List<int> buildIds = new List<int>();
            List<int[]> connectIds = new List<int[]>();
            var unionFind = new UnionFind(n + 1);
            while (que.Count > 0)
            {
                var pair = que.Dequeue();
                long cost = pair.Key;
                int left = pair.Value[0];
                int right = pair.Value[1];
                if (unionFind.IsSame(left,right))
                {
                    continue;
                }

                res += cost;
                unionFind.Unite(left, right);
                if (left == 0)
                {
                    buildIds.Add(right);
                }
                else
                {
                    connectIds.Add(new int[2] { left, right });
                }
                if (unionFind.GetSize(left) == n + 1)
                {
                    break;
                }
            }

            WriteLine(res);
            WriteLine(buildIds.Count);
            if (buildIds.Count > 0)
            {
                for(int i = 0; i < buildIds.Count; i++)
                {
                    Write(buildIds[i]);
                    if (i + 1 < buildIds.Count)
                    {
                        Write(" ");
                    }
                }
                WriteLine();
            }
            WriteLine(connectIds.Count);
            if (connectIds.Count > 0)
            {
                for (int i = 0; i < connectIds.Count; i++)
                {
                    WriteLine(connectIds[i][0] + " " + connectIds[i][1]);
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

        class UnionFind
        {
            int[] tree;
            int[] size;

            public UnionFind(int length)
            {
                tree = new int[length];
                size = new int[length];
                for (int i = 0; i < length; i++)
                {
                    tree[i] = i;
                    size[i] = 1;
                }
            }

            public int Root(int x)
            {
                int rx = x;
                while (tree[rx] != rx)
                {
                    rx = tree[rx];
                }
                tree[x] = rx;
                return rx;
            }

            public bool IsSame(int x, int y)
            {
                return Root(x) == Root(y);
            }

            public void Unite(int x, int y)
            {
                int rx = Root(x);
                int ry = Root(y);
                if (rx == ry) return;

                if (rx > ry)
                {
                    int temp = rx;
                    rx = ry;
                    ry = temp;
                }
                tree[ry] = rx;
                size[rx] += size[ry];
            }

            public int GetSize(int x)
            {
                return size[Root(x)];
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
