using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_187
{
    class E
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
            int[][] edges = new int[n - 1][];
            for (int i = 0; i < n - 1; i++)
            {
                edges[i] = ReadInts();
                edges[i][0]--;
                edges[i][1]--;
                graph[edges[i][0]].Add(edges[i][1]);
                graph[edges[i][1]].Add(edges[i][0]);
            }

            int[] pars = new int[n];
            var que = new Queue<int[]>();
            que.Enqueue(new int[2] { 0, -1 });
            List<int> order = new List<int>();
            while(que.Count>0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                int par = val[1];
                pars[now] = par;
                order.Add(now);

                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (to == par)
                    {
                        continue;
                    }

                    que.Enqueue(new int[2] { to, now });
                }
            }

            int q = ReadInt();
            long[] sums = new long[n];
            for(int i = 0; i < q; i++)
            {
                int[] tex = ReadInts();
                int t = tex[0];
                int e = tex[1] - 1;
                long x = tex[2];
                if (pars[edges[e][0]] == edges[e][1])
                {
                    if (t == 1)
                    {
                        sums[edges[e][0]] += x;
                    }
                    else
                    {
                        sums[edges[e][0]] -= x;
                        sums[0] += x;
                    }
                }
                else
                {
                    if (t == 1)
                    {
                        sums[edges[e][1]] -= x;
                        sums[0] += x;
                    }
                    else
                    {
                        sums[edges[e][1]] += x;
                    }
                }
            }

            for(int i = 1; i < n; i++)
            {
                int now = order[i];
                sums[now] += sums[pars[now]];
            }
            for(int i = 0; i < n; i++)
            {
                WriteLine(sums[i]);
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
