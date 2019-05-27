using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_128
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[][] stxs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                stxs[i] = ReadInts();
                stxs[i][0] -= stxs[i][2];
                stxs[i][1] -= stxs[i][2] - 1;
            }
            stxs = stxs.OrderBy(a => a[2]).ToArray();
            int now = 0;

            List<int> ds = new List<int>();
            ds.Add(-1);
            int[] res = new int[q];
            for (int i = 0; i < q; i++)
            {
                ds[i] = ReadInt();
                res[i] = -1;
            }
            ds.Add(int.MaxValue);

            for (int i = 0; i < n; i++)
            {
                if (stxs[i][0] > ds[q] || stxs[i][1] < ds[1]) continue;

                int bottom = 0;
                int top = q + 2;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    if (stxs[i][0] <= ds[mid]) top = mid;
                    else bottom = mid;
                }

                int l = bottom + 1;

                bottom = 0;
                top = q + 2;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    if (stxs[i][1] >= ds[mid]) bottom = mid;
                    else top = mid;
                }

                int r = bottom;

            }

            for (int i = 0; i < q; i++) WriteLine(res[i]);
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
