using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.yukicoder
{
    class _807
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
            List<int[]>[] graph = new List<int[]>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int[]>();
            for (int i = 0; i < m; i++)
            {
                int[] abc = ReadInts();
                int a = abc[0] - 1;
                int b = abc[1] - 1;
                int c = abc[2];
                graph[a].Add(new int[2] { b, c });
                graph[b].Add(new int[2] { a, c });
            }
            long[,] dists = new long[n, 2];
            for (int i = 0; i < n; i++)
            {
                dists[i, 0] = long.MaxValue / 8;
                dists[i, 1] = long.MaxValue / 8;
            }
            Queue<long[]> queue = new Queue<long[]>();
            queue.Enqueue(new long[3] { 0, 0, 0 });
            dists[0, 1] = 0;
            while (queue.Count > 0)
            {
                long[] val = queue.Dequeue();
                if (dists[val[0], val[1]] <= val[2]) continue;

                dists[val[0], val[1]] = val[2];

                for (int i = 0; i < graph[val[0]].Count; i++)
                {
                    int[] to = graph[val[0]][i];
                    if (val[2] + to[1] < dists[to[0], val[1]])
                    {
                        queue.Enqueue(
                            new long[3] { to[0], val[1], val[2] + to[1] });
                    }
                    if (val[1] == 0
                        && val[2] < dists[to[0], 1])
                    {
                        queue.Enqueue(
                            new long[3] { to[0], 1, val[2] });
                    }
                }
            }
            WriteLine(0);
            for (int i = 1; i < n; i++)
            {
                WriteLine(dists[i, 0] + dists[i, 1]);
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
