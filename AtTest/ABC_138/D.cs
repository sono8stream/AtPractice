using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_138
{
    class D
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            List<int>[] graph = new List<int>[n];
            int[] parents = new int[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                graph[ab[0] - 1].Add(ab[1] - 1);
                graph[ab[1] - 1].Add(ab[0] - 1);
            }
            parents[0] = -1;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (parents[now] == to) continue;
                    parents[to] = now;
                    queue.Enqueue(to);
                }
            }
            long[] cnts = new long[n];
            for(int i = 0; i < q; i++)
            {
                int[] px = ReadInts();
                cnts[px[0] - 1] += px[1];
            }

            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (parents[now] == to) continue;
                    cnts[to] += cnts[now];
                    queue.Enqueue(to);
                }
            }

            for(int i = 0; i < n; i++)
            {
                Write(cnts[i]);
                if (i < n - 1) Write(' ');
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
