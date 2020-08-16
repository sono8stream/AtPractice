using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Nomura_2020
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
            int n = ReadInt();
            int[] ps = ReadInts();
            UnionFind unionFind = new UnionFind(n);
            long unknown = 0;
            for(int i = 0; i < n; i++)
            {
                if (ps[i] == -1)
                {
                    unknown++;
                    continue;
                }

                int to = ps[i] - 1;
                unionFind.Unite(i, to);
            }

            long mask = 1000000000 + 7;
            long res = 0;
            long fixCnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (unionFind.Root(i) == i)
                {
                    fixCnt += unionFind.GetSize(i) - 1;
                }
            }
            for(int i = 0; i < unknown; i++)
            {
                fixCnt *= (n - 1);
                fixCnt %= mask;
            }
            res += fixCnt;

            for(int i = 0; i < n; i++)
            {
                if (ps[i] != -1)
                {
                    continue;
                }

                long cnt = 0;

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
