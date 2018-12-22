using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.UnionFind
{
    class WeightedUnionFind
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            for (int i = 0; i < n; i++)
            {

            }
            Console.WriteLine("text");
        }

        static int Root(ref int[] tree, ref int[] wTree, int x)
        {
            int rx = x;
            int weight = wTree[x];
            while (tree[rx] != rx)
            {
                rx = tree[rx];
                weight += wTree[rx];
            }
            tree[x] = rx;
            wTree[x] = weight;
            return rx;
        }

        static int Weight(ref int[] tree, ref int[] wTree, int x)
        {
            Root(ref tree, ref wTree, x);
            return wTree[x];
        }

        static bool IsSame(ref int[] tree, ref int[] wTree, int x, int y)
        {
            return Root(ref tree, ref wTree, x)
                == Root(ref tree, ref wTree, y);
        }

        static void Unite(ref int[] tree, ref int[] wTree, ref int[] rank,
            int x, int y, int diff)
        {
            int rx = Root(ref tree, ref wTree, x);
            int ry = Root(ref tree, ref wTree, y);
            diff += Weight(ref tree, ref wTree, x)
                     - Weight(ref tree, ref wTree, y);
            if (rx == ry) return;
            if (rank[rx] < rank[ry])
            {
                int temp = rx;
                rx = ry;
                ry = temp;
                diff *= -1;
            }
            if (rank[rx] == rank[ry])
            {
                rank[rx]++;
            }
            tree[ry] = rx;
            wTree[ry] = diff;
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
