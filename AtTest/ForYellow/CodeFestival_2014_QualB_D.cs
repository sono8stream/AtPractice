using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFestival_2014_QualB_D
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
            int[] hs = new int[n];
            int[][] sorted = new int[n][];
            for(int i = 0; i < n; i++)
            {
                hs[i] = ReadInt();
                sorted[i] = new int[2] { i, hs[i] };
            }
            Array.Sort(sorted, (a, b) => a[1] - b[1]);

            UnionFind unionFind = new UnionFind(n);
            int[] res = new int[n];

            for (int i = 0; i < n;)
            {
                List<int> indexes = new List<int>();
                do
                {
                    int index = sorted[i][0];
                    if (index > 0 && hs[index] >= hs[index - 1])
                    {
                        unionFind.Unite(index - 1, index);
                    }
                    if (index + 1 < n && hs[index] >= hs[index + 1])
                    {
                        unionFind.Unite(index, index + 1);
                    }
                    indexes.Add(index);
                    i++;
                } while (i < n && sorted[i][1] == sorted[i - 1][1]);

                for (int j = 0; j < indexes.Count; j++)
                {
                    res[indexes[j]] = unionFind.GetSize(indexes[j]) - 1;
                }
            }

            for(int i = 0; i < n; i++)
            {
                WriteLine(res[i]);
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
