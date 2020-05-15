using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFestival2015_QualB_D
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
            long[] ss = new long[n];
            long[] cs = new long[n];
            long[][] poses = new long[n][];
            for(int i = 0; i < n; i++)
            {
                long[] sc = ReadLongs();
                ss[i] = sc[0];
                cs[i] = sc[1];
                poses[i] = new long[2] { i, ss[i] };
            }
            poses = poses.OrderBy(a => a[1]).ToArray();
            int[] indexes = new int[n];
            for(int i = 0; i < n; i++)
            {
                indexes[poses[i][0]] = i;
            }

            UnionFind unionFind = new UnionFind(n);
            long[] res = new long[n];
            for (int i = 0; i < n; i++)
            {
                int root = unionFind.Root(indexes[i]);
                long pos = poses[root][1] + unionFind.GetSize(root) - 1;
                int next = root + unionFind.GetCompressed(root);
                long cnt = cs[i];
                if (pos < poses[i][1])
                {
                    cnt--;
                    pos++;
                    unionFind.SetSize(root, unionFind.GetSize(root) + 1);
                }
                // enter to next territory
                while (next < n && poses[next][1] - pos <= cnt)
                {
                    unionFind.Unite(root, next);
                    unionFind.SetSize(root,
                        unionFind.GetSize(root) + poses[next][1] - pos - 1);
                    cnt -= poses[next][1] - pos - 1;
                    pos = poses[root][1] + unionFind.GetSize(root) - 1;
                    next = root + unionFind.GetCompressed(root);
                }

                unionFind.SetSize(root, unionFind.GetSize(root) + cnt);
                pos += cnt;
                res[i] = pos;
            }

            for(int i = 0; i < n; i++)
            {
                WriteLine(res[i]);
            }
        }

        class UnionFind
        {
            int[] tree;
            long[] size;
            int[] compressed;

            public UnionFind(int length)
            {
                tree = new int[length];
                size = new long[length];
                compressed = new int[length];
                for (int i = 0; i < length; i++)
                {
                    tree[i] = i;
                    size[i] = 0;
                    compressed[i] = 1;
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
                compressed[rx] += compressed[ry];
            }

            public long GetSize(int x)
            {
                return size[Root(x)];
            }

            public void SetSize(int x,long val)
            {
                size[Root(x)] = val;
            }

            public int GetCompressed(int x)
            {
                return compressed[Root(x)];
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
