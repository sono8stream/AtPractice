using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._600_Div2
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];

            UnionFind unionFind = new UnionFind(n);
            for(int i = 0; i < m; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0]-1;
                int v = uv[1]-1;
                unionFind.Unite(u, v);
            }

            int res = 0;
            int last = -1;
            for(int i = 0; i < n; i++)
            {
                int root = unionFind.Root(i);
                if (i == root)
                {
                    if (root < last)
                    {
                        res++;
                        unionFind.Unite(root, last);
                    }
                    last = unionFind.GetMax(root);
                }
                else
                {
                    continue;
                }
            }

            WriteLine(res);
        }

        class UnionFind
        {
            int[] tree;
            int[] size;
            int[] max;

            public UnionFind(int length)
            {
                tree = new int[length];
                size = new int[length];
                max = new int[length];
                
                for (int i = 0; i < length; i++)
                {
                    tree[i] = i;
                    size[i] = 1;
                    max[i] = i;
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
                max[rx] = Max(max[rx], max[ry]);
            }

            public int GetSize(int x)
            {
                return size[Root(x)];
            }

            public int GetMax(int x)
            {
                return max[Root(x)];
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
