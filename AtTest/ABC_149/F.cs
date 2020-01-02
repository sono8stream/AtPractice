using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_149
{
    class F
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
            long n=ReadLong();
            List<int>[] edges = new List<int>[n];
            for (int i = 0; i < n; i++) edges[i] = new List<int>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0]-1;
                int b = ab[1]-1;
                edges[a].Add(b);
                edges[b].Add(a);
            }
            long mask = 1000000000 + 7;
            long[] exps = new long[n + 5];
            exps[0] = 1;
            for(int i = 1; i < exps.Length; i++)
            {
                exps[i] = exps[i - 1] * 2;
                exps[i] %= mask;
            }
            int[] childCnts = new int[n];
            int[] parents = new int[n];
            DFS(childCnts, edges, parents, 0, -1);

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                long tmp = 1;
                for(int j = 0; j < edges[i].Count; j++)
                {
                    if (edges[i][j] == parents[i])
                    {
                        tmp += exps[n - childCnts[i]] + mask - 1;
                    }
                    else
                    {
                        tmp += exps[childCnts[edges[i][j]]] + mask - 1;
                    }
                    tmp %= mask;
                }
                tmp = exps[n - 1] - tmp + mask;
                tmp %= mask;
                res += tmp;
            }
            res = Multi(res, Reverse(exps[n], mask - 2, mask), mask);
            WriteLine(res);
        }

        static long Multi(long a, long b,long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        static long Reverse(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = Reverse(a, pow / 2, mask);
                long nextMod = Multi(halfMod, halfMod, mask);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return Multi(nextMod, a, mask);
                }
            }
        }

        static int DFS(int[] childCnts, List<int>[] edges,int[] parents,
            int now, int prev)
        {
            parents[now] = prev;
            if (prev >= 0 && edges[now].Count == 0)
            {
                childCnts[now] = 1;
            }
            else
            {
                int res = 1;
                for (int i = 0; i < edges[now].Count; i++)
                {
                    if (edges[now][i] == prev) continue;

                    res += DFS(childCnts, edges,parents, edges[now][i], now);
                }
                childCnts[now] = res;
            }
            return childCnts[now];
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
