using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2017B_C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            long n = nm[0];
            int m = nm[1];

            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            Queue<int[]> pos = new Queue<int[]>();
            pos.Enqueue(new int[2] { 0, 0 });
            int[] dist = new int[n];
            for (int i = 0; i < n; i++) dist[i] = int.MaxValue;
            while (pos.Count > 0)
            {
                int[] val = pos.Dequeue();
                if (dist[val[0]] == int.MaxValue)
                {
                    dist[val[0]] = val[1];
                }
                else
                {
                    if (val[1] == dist[val[0]]) continue;
                    else
                    {
                        WriteLine(n * (n - 1) / 2 - m);
                        return;
                    }
                }

                for(int i = 0; i < graph[val[0]].Count; i++)
                {
                    pos.Enqueue(new int[2]
                    { graph[val[0]][i], (val[1] + 1)%2 });
                }
            }

            long oddCnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (dist[i] == 1) oddCnt++;
            }

            WriteLine((n - oddCnt) * oddCnt - m);
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
