﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_087
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var lrds = new int[nm[1]][];
            for (int i = 0; i < nm[1]; i++)
            {
                lrds[i] = ReadInts();
            }
            var unionFind = new int[nm[0]];
            var rank = new int[nm[0]];
            var diff = new int[nm[0]];
            for (int i = 0; i < nm[0]; i++)
            {
                unionFind[i] = i;
            }
            for (int i = 0; i < nm[1]; i++)
            {
                int x = lrds[i][0] - 1;
                int y = lrds[i][1] - 1;
                if (IsSame(ref unionFind, ref diff,x,y))
                {
                    int weight = Weight(ref unionFind, ref diff, y)
                        - Weight(ref unionFind, ref diff, x);
                    if (weight != lrds[i][2])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    Unite(ref unionFind, ref diff, ref rank,
                        lrds[i][0] - 1, lrds[i][1] - 1, lrds[i][2]);
                }
            }

            Console.WriteLine("Yes");
        }

        static int Root(ref int[] tree,ref int[] wTree, int x)
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

        static int Weight(ref int[] tree,ref int[] wTree, int x)
        {
            Root(ref tree, ref wTree, x);
            return wTree[x];
        }

        static bool IsSame(ref int[] tree,ref int[] wTree,int x,int y)
        {
            return Root(ref tree, ref wTree, x)
                == Root(ref tree, ref wTree, y);
        }

        static void Unite(ref int[] tree, ref int[] wTree,ref int[] rank,
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