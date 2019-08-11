using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_2
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
            int[] nmq = ReadInts();
            int n = nmq[0];
            int m = nmq[1];
            int q = nmq[2];

            var dict = new SortedDictionary<long, List<int[]>>();
            for(int i = 0; i < m; i++)
            {
                long[] abc = ReadLongs();
                int a = (int)abc[0]-1;
                int b = (int)abc[1]-1;
                long c = abc[2];
                if (!dict.ContainsKey(c)) dict.Add(c, new List<int[]>());

                dict[c].Add(new int[2] { a, b });
            }

            long[][] qs = new long[q][];
            for (int i = 0; i < q; i++) qs[i] = new long[3] { ReadInt(), i, -1 };
            Array.Sort(qs, (a, b) => (int)a[0] - (int)b[0]);

            UnionFind unionFind = new UnionFind(n);
            int[] cnts = new int[n+1];
            cnts[1] = n;
            int min = 1;
            long l = 0;
            for(int i = 0; i < q; i++)
            {
                if (min >= qs[i][0])
                {
                    qs[i][2] = l;
                    continue;
                }

                while (dict.Count > 0)
                {
                    l = dict.First().Key;
                    for(int j = 0; j < dict[l].Count; j++)
                    {
                        int a = dict[l][j][0];
                        int b = dict[l][j][1];
                        if (unionFind.IsSame(a, b)) continue;

                        int aSize = unionFind.GetSize(a);
                        int bSize = unionFind.GetSize(b);
                        cnts[aSize] -= aSize;
                        cnts[bSize] -= bSize;
                        unionFind.Unite(a, b);
                        cnts[aSize + bSize] += aSize + bSize;
                    }
                    dict.Remove(l);
                    while (min <= n && cnts[min] == 0) min++;
                    if (min >= qs[i][0])
                    {
                        qs[i][2] = l;
                        break;
                    }
                }
            }

            Array.Sort(qs, (a, b) => (int)a[1] - (int)b[1]);
            for (int i = 0; i < q; i++)
            {
                if (qs[i][2] >= 0) WriteLine(qs[i][2]);
                else WriteLine("trumpet");
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
