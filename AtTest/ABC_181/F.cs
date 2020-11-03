using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_181
{
    class F
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
            int[][] xys = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xys[i] = ReadInts();
            }

            Array.Sort(xys, (a, b) =>
            {
                if (a[0] == b[0])
                {
                    return a[1] - b[1];
                }
                else
                {
                    return a[0] - b[0];
                }
            });

            double[,] dists = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double dx = xys[i][0] - xys[j][0];
                    double dy = xys[i][1] - xys[j][1];
                    dists[i, j] = Sqrt(dx * dx + dy * dy);
                }
            }

            double bottom = 0;
            double top = 200;
            double thres = 0.00001;
            while (bottom + thres < top)
            {
                double mid = (bottom + top) / 2;
                var finder = new UnionFind(n + 2);

                for (int i = 0; i < n; i++)
                {
                    if (100 - xys[i][1] <= mid * 2)
                    {
                        finder.Unite(i, n);
                    }
                    if (xys[i][1] + 100 <= mid * 2)
                    {
                        finder.Unite(i, n + 1);
                    }

                    for (int j = i + 1; j < n; j++)
                    {
                        if (dists[i, j] <= mid * 2)
                        {
                            finder.Unite(i, j);
                        }
                    }
                }

                if (finder.Root(n)==finder.Root(n+1))
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }

            WriteLine(bottom);
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
