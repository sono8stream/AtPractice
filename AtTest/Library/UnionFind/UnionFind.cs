﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.UnionFind
{
    class UnionFind
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
