using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class IndeedNow2015QualA_C
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
            List<int> ss = new List<int>();
            for(int i = 0; i < n; i++)
            {
                int s = ReadInt();
                if (s > 0)
                {
                    ss.Add(s);
                }
            }
            ss.Sort();

            UnionFind unionFind = new UnionFind(ss.Count);
            for(int i = 1; i < ss.Count; i++)
            {
                if (ss[i] == ss[i - 1])
                {
                    unionFind.Unite(i - 1, i);
                }
            }


            int q = ReadInt();
            int[] ks = new int[q];
            for(int i = 0; i < q; i++)
            {
                ks[i] = ReadInt();
            }

            for(int i = 0; i < q; i++)
            {
                if (ks[i] >= ss.Count)
                {
                    WriteLine(0);
                }
                else if (ks[i] == 0)
                {
                    WriteLine(ss[ss.Count - 1] + 1);
                }
                else
                {
                    int root = unionFind.Root(ss.Count - ks[i] - 1);
                    WriteLine(ss[root] + 1);
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
