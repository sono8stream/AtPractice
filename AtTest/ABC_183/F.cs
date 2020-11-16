using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_183
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[] cs = ReadInts();
            int[][] queries = new int[q][];
            for(int i = 0; i < q; i++)
            {
                queries[i] = ReadInts();
            }

            UnionFind unionFind = new UnionFind(n);
            for(int i = 0; i < n; i++)
            {
                unionFind.cnts[i].Add(cs[i], 1);
            }
            for (int i = 0; i < q; i++)
            {
                if (queries[i][0] == 1)
                {
                    unionFind.Unite(queries[i][1] - 1, queries[i][2] - 1);
                }
                else
                {
                    int rt = unionFind.Root(queries[i][1] - 1);
                    int c = queries[i][2];
                    if (unionFind.cnts[rt].ContainsKey(c))
                    {
                        WriteLine(unionFind.cnts[rt][c]);
                    }
                    else
                    {
                        WriteLine(0);
                    }
                }
            }
        }

        class UnionFind
        {
            int[] tree;
            public Dictionary<int, int>[] cnts;

            public UnionFind(int length)
            {
                tree = new int[length];
                cnts = new Dictionary<int, int>[length];
                for (int i = 0; i < length; i++)
                {
                    tree[i] = i;
                    cnts[i] = new Dictionary<int, int>();
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

                if (cnts[rx].Count > cnts[ry].Count)
                {
                    foreach(var key in cnts[ry].Keys)
                    {
                        if (cnts[rx].ContainsKey(key))
                        {
                            cnts[rx][key] += cnts[ry][key];
                        }
                        else
                        {
                            cnts[rx].Add(key, cnts[ry][key]);
                        }
                    }
                }
                else
                {
                    foreach (var key in cnts[rx].Keys)
                    {
                        if (cnts[ry].ContainsKey(key))
                        {
                            cnts[ry][key] += cnts[rx][key];
                        }
                        else
                        {
                            cnts[ry].Add(key, cnts[rx][key]);
                        }
                    }
                    cnts[rx] = cnts[ry];
                }
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
