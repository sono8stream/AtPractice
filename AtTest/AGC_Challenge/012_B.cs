using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_Challenge
{
    class _012_B
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            var graph = new Dictionary<int, int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new Dictionary<int, int>();
            }
            for (int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b, 1);
                graph[b].Add(a, 1);
            }
            int q = ReadInt();
            int[][] vdcs = new int[q][];
            for(int i =0; i < q; i++)
            {
                vdcs[i] = ReadInts();
            }
            for(int i = q - 1; i >= 0; i--)
            {
                int v = vdcs[i][0] - 1;
                int d = vdcs[i][1];
                int c = vdcs[i][2];
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[2] { v, d });
                while (queue.Count > 0)
                {

                }
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
