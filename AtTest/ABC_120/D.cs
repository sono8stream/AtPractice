using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_120
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            long n = nm[0];
            long m = nm[1];
            int[][] edges = new int[m][];
            for(int i = 0; i < m; i++)
            {
                edges[i] = ReadInts();
                edges[i][0]--;
                edges[i][1]--;
            }
            long[] res = new long[m];
            long all = n * (n - 1) / 2;
            res[m - 1] = all;
            UnionFind unionFind = new UnionFind((int)n);
            long first = 0;
            for(int i = (int)m - 2; i >= -1; i--)
            {
                int rootA = unionFind.Root(edges[i+1][0]);
                int rootB = unionFind.Root(edges[i+1][1]);
                //WriteLine(rootA + ":" + rootB);
                if (rootA == rootB)
                {
                    if (i >= 0)
                    {
                        res[i] = res[i + 1];
                    }
                    else
                    {
                        first = res[i + 1];
                    }
                }
                else
                {
                    long befSize1 = unionFind.size[rootA];
                    long befSize2 = unionFind.size[rootB];
                    unionFind.Unite(rootA, rootB);
                    if (i >= 0)
                    {
                        res[i] = res[i + 1] - befSize1 * befSize2;
                    }
                    else
                    {
                        first= res[i + 1] - befSize1 * befSize2;
                    }
                    //WriteLine(befSize1 + " " + befSize2);
                }
            }

            for(int i = 0; i < (int)m; i++)
            {
                WriteLine(res[i] - first);
            }
        }

        class UnionFind
        {
            int[] tree;
            public long[] size;

            public UnionFind(int length)
            {
                tree = new int[length];
                size = new long[length];
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
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
