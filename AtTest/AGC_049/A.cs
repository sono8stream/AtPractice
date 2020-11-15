using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_049
{
    class A
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
            bool[,] graph = new bool[n, n];
            for (int i= 0; i < n; i++)
            {
                string row = Read();
                for(int j = 0; j < n; j++)
                {
                    if (row[j] == '1')
                    {
                        graph[i, j] = true;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                bool[] visited = new bool[n];
                Queue<int> que = new Queue<int>();
                que.Enqueue(i);
                while (que.Count > 0)
                {
                    int now = que.Dequeue();

                    if (visited[now])
                    {
                        continue;
                    }
                    visited[now] = true;
                    graph[i, now] = true;

                    for(int j = 0; j < n; j++)
                    {
                        if (graph[now, j]&&!visited[j])
                        {
                            que.Enqueue(j);
                        }
                    }
                }
            }

            double res = 0;
            for(int i = 0; i < n; i++)
            {
                int cnt = 0;
                for(int j = 0; j < n; j++)
                {
                    if (graph[j, i])
                    {
                        cnt++;
                    }
                }
                res += 1.0 / cnt;
            }

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
