using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_152
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
            int n = ReadInt();
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            int m = ReadInt();
            int[][] uvs = new int[m][];
            for (int i = 0; i < m; i++) uvs[i] = ReadInts();

            int[,] dists = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dists[i, j] = int.MaxValue / 4;
                }
            }
            for(int i = 0; i < n; i++)
            {
                dists[i, i] = 0;
                for(int j = 0; j < graph[i].Count; j++)
                {
                    dists[i, graph[i][j]] = 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        dists[j, k] = Min(dists[j, k], dists[j, i] + dists[i, k]);
                    }
                }
            }

            long[] pows = new long[56];
            pows[0] = 1;
            for (int i = 1; i < 56; i++)
            {
                pows[i] = pows[i - 1] * 2;
            }
            long all = pows[n - 1];
            long exc = 1;
            for(int i = 0; i < m; i++)
            {
                int u = uvs[i][0] - 1;
                int v = uvs[i][1] - 1;
                exc += pows[n - 1 - dists[u, v]] - 1;
            }
            WriteLine(all - exc);
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
