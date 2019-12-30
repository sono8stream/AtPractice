using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1139
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
            int[] nk = ReadInts();
            long n = nk[0];
            long k = nk[1];
            long mask = 1000000000 + 7;
            UnionFind unionFind = new UnionFind((int)n);
            for(int i = 0; i < n-1; i++)
            {
                int[] uvx = ReadInts();
                int u = uvx[0]-1;
                int v= uvx[1]-1;
                int x = uvx[2];
                if (x == 1) continue;
                unionFind.Unite(u, v);
            }
            long rem = 0;
            for(int i = 0; i < n; i++)
            {
                if (unionFind.Root(i) != i) continue;

                long tmp = 1;
                for(int j = 0; j < k; j++)
                {
                    tmp *= unionFind.GetSize(i);
                    tmp %= mask;
                }
                rem += tmp;
                rem %= mask;
            }
            long res = 1;
            for(int i = 0; i < k; i++)
            {
                res *= n;
                res %= mask;
            }
            res -= rem;
            res += mask;
            res %= mask;
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
