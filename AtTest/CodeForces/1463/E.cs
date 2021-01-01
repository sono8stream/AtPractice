using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1463
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] ps = ReadInts();

            var uf = new UnionFind(n);
            int[] childs = new int[n];
            for(int i = 0; i < n; i++)
            {
                childs[i] = -1;
            }
            for (int i = 0; i < k; i++)
            {
                int[] lr = ReadInts();
                int l = lr[0] - 1;
                int r = lr[1] - 1;
                if (uf.IsSame(l, r))
                {
                    WriteLine(0);
                    return;
                }
                else
                {
                    uf.Unite(l, r);
                    childs[l] = r;
                }
            }
            int[] ranks = new int[n];
            for(int i = 0; i < n; i++)
            {
                if (i != uf.GetRoot(i))
                {
                    continue;
                }

                int tmp = i;
                int rank = 0;
                while (tmp != -1)
                {
                    ranks[tmp] = rank;
                    tmp = childs[tmp];
                    rank++;
                }
            }

            List<int>[] graph = new List<int>[n];
            int[] revCnt = new int[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            int root = 0;
            for(int i = 0; i < n; i++)
            {
                int p = ps[i] - 1;
                if (p == -1)
                {
                    root = i;
                    continue;
                }

                if (uf.IsSame(p, i))
                {
                    if (ranks[p] > ranks[i])
                    {
                        WriteLine(0);
                        return;
                    }
                    continue;
                }

                graph[uf.Root(p)].Add(uf.Root(i));
                revCnt[uf.Root(i)]++;
            }

            if (uf.GetRoot(root) != root)
            {
                WriteLine(0);
                return;
            }

            var que = new Queue<int>();
            que.Enqueue(uf.Root(root));
            List<int> res = new List<int>();
            {
                int tmp = root;
                while (tmp != -1)
                {
                    res.Add(tmp);
                    tmp = childs[tmp];
                }
            }
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];

                    revCnt[to]--;
                    if (revCnt[to] == 0)
                    {
                        int tmp = uf.GetRoot(to);
                        while (tmp != -1)
                        {
                            res.Add(tmp);
                            tmp = childs[tmp];
                        }
                        que.Enqueue(to);
                    }
                }
            }

            if (res.Count == n)
            {
                for(int i = 0; i < n; i++)
                {
                    Write(res[i] + 1);
                    if (i + 1 < n)
                    {
                        Write(" ");
                    }
                }
                WriteLine();
            }
            else
            {
                WriteLine(0);
            }
        }

        class UnionFind
        {
            int[] tree;
            int[] size;
            int[] root;

            public UnionFind(int length)
            {
                tree = new int[length];
                size = new int[length];
                root = new int[length];
                for (int i = 0; i < length; i++)
                {
                    tree[i] = i;
                    size[i] = 1;
                    root[i] = i;
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

                int rtTmp = rx;
                if (size[rx] < size[ry])
                {
                    int temp = rx;
                    rx = ry;
                    ry = temp;
                }

                tree[ry] = rx;
                size[rx] += size[ry];
                root[rx] = rtTmp;
            }

            public int GetSize(int x)
            {
                return size[Root(x)];
            }

            public int GetRoot(int x)
            {
                return root[Root(x)];
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
