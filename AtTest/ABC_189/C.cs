using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_189
{
    class C
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
            int[][] vals = new int[n][];
            for(int i = 0; i < n; i++)
            {
                vals[i] = new int[2] { array[i], i };
            }

            Array.Sort(vals, (a, b) => b[0] - a[0]);

            var uf = new UnionFind(n);
            int res = 0;
            bool[] used = new bool[n];
            for(int i = 0; i < n; i++)
            {
                int now = vals[i][0];
                int idx = vals[i][1];
                used[idx] = true;
                if (idx - 1 >= 0 && used[idx - 1])
                {
                    uf.Unite(idx - 1, idx);
                }
                if (idx + 1 < n && used[idx + 1])
                {
                    uf.Unite(idx, idx + 1);
                }

                int size = uf.GetSize(idx);
                res = Max(res, size * now);
            }

            WriteLine(res);
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

                if (GetSize(rx) < GetSize(ry))
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
