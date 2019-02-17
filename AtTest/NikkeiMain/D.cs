using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.NikkeiMain
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[][] tlrs = new int[m][];
            for (int i = 0; i < m; i++)
            {
                tlrs[i] = ReadInts();
            }
            long res = 0;
            UnionFind unionFind = new UnionFind(n);
            for (int i = m - 1; i >= 0; i--)
            {
                long t = tlrs[i][0];
                int l = tlrs[i][1] - 1;
                int r = tlrs[i][2] - 1;
                for (int j = l; j <= r; j++)
                {
                    if (unionFind.size[j] > 0)
                    {
                        if (j > 0 && unionFind.size[j - 1] > 0)
                        {
                            unionFind.Unite(j - 1, j);
                        }
                        int root = unionFind.Root(j);
                        j = root + unionFind.size[root] - 1;
                    }
                    else
                    {
                        unionFind.size[j] = 1;
                        res += t;

                        if (j > 0 && unionFind.size[j - 1] > 0)
                        {
                            unionFind.Unite(j - 1, j);
                        }
                    }
                }
            }
            Console.WriteLine(res);
        }

        class UnionFind
        {
            int[] tree;
            public int[] size;

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
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
