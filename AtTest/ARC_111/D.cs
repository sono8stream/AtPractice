﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_111
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
            List<int[]>[] graph = new List<int[]>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0]-1;
                int b = ab[1]-1;
                graph[a].Add(new int[2] { b, i });
                graph[b].Add(new int[2] { a, i });
            }

            var uf = new UnionFind(n);
            int[][] cs = new int[n][];
            {
                int[] cTmp = ReadInts();
                for(int i = 0; i < n; i++)
                {
                    cs[i] = new int[2] { cTmp[i], i };
                }
            }
            Array.Sort(cs, (a, b) => a[0] - b[0]);

            var fixedGraph = new List<int>[n];
            var res = new int[m];
            for(int i = 0; i < n; i++)
            {
                int idx = cs[i][1];
                int cost = cs[i][0];

                var hashSet = new HashSet<int>();

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
