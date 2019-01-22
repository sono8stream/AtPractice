using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CF2016Final_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            var edges = new Queue<int>[m];
            for(int i = 0; i < m; i++)
            {
                edges[i] = new Queue<int>();
            }
            for (int i = 0; i < n; i++)
            {
                int[] kls = ReadInts();
                for (int j = 0; j < kls[0]; j++)
                {
                    edges[kls[j + 1] - 1].Enqueue(i);
                }
            }
            var parents = new int[n];
            var ranks = new int[n];
            for (int i = 0; i < n; i++) parents[i] = i;
            for (int i = 0; i < m; i++)
            {
                if (edges[i].Count <= 1) continue;
                int parent = edges[i].Dequeue();
                while (edges[i].Count > 0)
                {
                    int index = edges[i].Dequeue();
                    Unite(ref parents, ref ranks, parent, index);
                }
            }
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(parents[i]);
                if (parents[i] != i) cnt++;
            }
            Console.WriteLine(cnt == n - 1 ? "YES" : "NO");
        }

        static int Root(ref int[] tree, int x)
        {
            int rx = x;
            while (tree[rx] != rx)
            {
                rx = tree[rx];
            }
            tree[x] = rx;
            return rx;
        }

        static bool IsSame(ref int[] tree, int x, int y)
        {
            return Root(ref tree, x)
                == Root(ref tree, y);
        }

        static void Unite(ref int[] tree, ref int[] rank,
            int x, int y)
        {
            int rx = Root(ref tree, x);
            int ry = Root(ref tree, y);
            if (rx == ry) return;
            if (rank[rx] < rank[ry])
            {
                int temp = rx;
                rx = ry;
                ry = temp;
            }
            if (rank[rx] == rank[ry])
            {
                rank[rx]++;
            }
            tree[ry] = rx;
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
