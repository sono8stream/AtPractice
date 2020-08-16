using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_173
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
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0] - 1;
                int v = uv[1] - 1;
                graph[u].Add(v);
                graph[v].Add(u);
            }

            Queue<int> que = new Queue<int>();
            que.Enqueue(0);
            int[] parents = new int[n];
            parents[0] = -1;
            while (que.Count > 0)
            {
                int now = que.Dequeue();

                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (to == parents[now])
                    {
                        continue;
                    }

                    parents[to] = now;
                    que.Enqueue(to);
                }
            }

            long res = n;
            for(long i = 1; i < n; i++)
            {
                if (i < parents[i])
                {
                    res += (i + 1) * (parents[i] - i);
                }
                else
                {
                    res += (i - parents[i]) * (n - i);
                }
            }

            WriteLine(res);
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
