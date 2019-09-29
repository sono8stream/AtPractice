using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._1000problems
{
    class AGC002_D
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
            int[][] edges = new int[m][];
            for(int i=0;i<m;i++)
            {
                edges[i] = ReadInts();
                edges[i][0]--;
                edges[i][1]--;
            }
            int q = ReadInt();
            int[][] xyzs = new int[q][];
            for(int i = 0; i < q; i++)
            {
                xyzs[i] = ReadInts();
                xyzs[i][0]--;
                xyzs[i][1]--;
            }
            int[] lows = new int[q];
            int[] highs = new int[q];
            for (int i = 0; i < q; i++)
            {
                lows[i] = -1;
                highs[i] = m - 1;
            }
            while (true)
            {
                int[][] mids = new int[q][];
                for(int i = 0; i < q; i++)
                {
                    mids[i] = new int[2] { (lows[i] + highs[i] + 1) / 2, i };
                }
                Array.Sort(mids, (a, b) => a[0] - b[0]);
                int now = 0;
                UnionFind unionFind = new UnionFind(n);
                for (int i = 0; i < q; i++)
                {
                    while (now <= mids[i][0])
                    {
                        unionFind.Unite(edges[now][0], edges[now][1]);
                        now++;
                    }
                    int myI = mids[i][1];
                    int x = xyzs[myI][0];
                    int y = xyzs[myI][1];
                    int z = xyzs[myI][2];
                    if (unionFind.IsSame(x, y))
                    {
                        if (unionFind.GetSize(x) >= z)
                        {
                            highs[myI] = mids[i][0];
                        }
                        else
                        {
                            lows[myI] = mids[i][0];
                        }
                    }
                    else
                    {
                        if (unionFind.GetSize(x) + unionFind.GetSize(y) >= z)
                        {
                            highs[myI] = mids[i][0];
                        }
                        else
                        {
                            lows[myI] = mids[i][0];
                        }
                    }

                }

                int nots = 0;
                for(int i = 0; i < q; i++) {
                    if (lows[i]+1 != highs[i]) nots++;
                }
                if (nots == 0) break;
            }
            for (int i = 0; i < q; i++)
            {
                WriteLine(highs[i] + 1);
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
