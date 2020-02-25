using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_155
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[][] abs = new int[n + 1][];
            abs[0] = new int[2] { 0, 0 };
            for (int i = 0; i < n; i++)
            {
                abs[i+1] = ReadInts();
            }
            Array.Sort(abs, (a, b) => a[0] - b[0]);
            int[][] lrs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                lrs[i] = ReadInts();
            }
            UnionFind unionFind = new UnionFind(n);
            for(int i = 0; i < m; i++)
            {
                if (lrs[i][1] < abs[0][0]
                    || lrs[i][0] > abs[n][0])
                {
                    continue;
                }
                int lOK = 1;
                int lNG = n + 1;
                while (Abs(lOK - lNG) > 1)
                {
                    int mid = (lOK + lNG) / 2;
                    if(lrs[i][0]<= abs[mid][0])
                    {
                        lOK = mid;
                    }
                    else
                    {
                        lNG = mid;
                    }
                }
                int rOK = n;
                int rNG = 0;
                while (Abs(rOK - rNG) > 1)
                {
                    int mid = (rOK + rNG / 2);
                    if (lrs[i][1] >= abs[mid][0])
                    {
                        rOK = mid;
                    }
                    else
                    {
                        rNG = mid;
                    }
                }
                if (lOK == rOK)
                {
                    continue;
                }

                if(abs[lOK][1]!=abs[lOK-1][1]
                    && abs[rOK - 1][1]!=abs[rOK][1])
                {
                    unionFind.Unite(lOK, rOK);
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (Abs(abs[i][1] - abs[i + 1][1]) == unionFind.GetSize(i) % 2)
                {
                    WriteLine(-1);
                    return;
                }
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
