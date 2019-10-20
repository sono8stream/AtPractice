using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.KUPC2019
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
            int[] nmw = ReadInts();
            int n = nmw[0];
            int m = nmw[1];
            int w = nmw[2];

            int[][] wvs = new int[n][];
            int[][] abs = new int[m][];
            for(int i = 0; i < n; i++)
            {
                wvs[i] = ReadInts();
            }
            for(int i = 0; i < m; i++)
            {
                abs[i] = ReadInts();
            }
            UnionFind unionFind = new UnionFind(n);
            for(int i = 0; i < m; i++)
            {
                unionFind.Unite(abs[i][0] - 1, abs[i][1] - 1);
            }
            var dict = new Dictionary<int, long[]>();
            for(int i = 0; i < n; i++)
            {
                int root = unionFind.Root(i);
                if (dict.ContainsKey(root))
                {
                    dict[root][0] += wvs[i][0];
                    dict[root][1] += wvs[i][1];
                }
                else
                {
                    dict.Add(i, new long[2] { wvs[i][0], wvs[i][1] });
                }
            }
            var dp = new Dictionary<long,long>();
            dp.Add(0, 0);
            foreach (int key in dict.Keys)
            {
                var next = new Dictionary<long, long>();
                foreach (int key2 in dp.Keys)
                {
                    if (next.ContainsKey(key2))
                    {
                        next[key2] = Max(dp[key2], next[key2]);
                    }
                    else
                    {
                        next.Add(key2, dp[key2]);
                    }
                    if (dict[key][0] + key2 > w) continue;
                    if (next.ContainsKey(dict[key][0] + key2))
                    {
                        next[dict[key][0] + key2] = Max(dp[key2]
                            + dict[key][1], next[dict[key][0] + key2]);
                    }
                    else
                    {
                        next.Add(dict[key][0] + key2, dp[key2] + dict[key][1]);
                    }
                }
                dp = next;
            }
            long max = 0;
            foreach(int key in dp.Keys)
            {
                max = Max(max, dp[key]);
            }
            WriteLine(max);
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
                    size[i] = 0;
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
