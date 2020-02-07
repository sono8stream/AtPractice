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

            long[] pows = new long[56];
            pows[0] = 1;
            for (int i = 1; i < 56; i++)
            {
                pows[i] = pows[i - 1] * 2;
            }

            List<int>[] graph = new List<int>[n];
            var pathDict = new Dictionary<int, long>();
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
                pathDict.Add(Max(a, b) * 100 + Min(a, b), pows[i]);
            }

            int m = ReadInt();
            long[] paths = new long[m];
            for (int i = 0; i < m; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0] - 1;
                int v = uv[1] - 1;
                int[] costs = new int[n];
                for (int j = 0; j < n; j++) costs[j] = int.MaxValue / 2;
                Queue<int[]> que = new Queue<int[]>();
                que.Enqueue(new int[2] { u, 0 });
                while (que.Count > 0)
                {
                    int[] val = que.Dequeue();
                    int now = val[0];
                    int cost = val[1];
                    if (cost >= costs[now]) continue;

                    costs[now] = cost;
                    for (int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (costs[to] > cost + 1)
                        {
                            que.Enqueue(new int[2] { to, cost + 1 });
                        }
                    }
                }
                int tmp = v;
                while (tmp != u)
                {
                    for (int j = 0; j < graph[tmp].Count; j++)
                    {
                        int to = graph[tmp][j];
                        if (costs[to] < costs[tmp])
                        {
                            paths[i] += pathDict[Max(tmp, to) * 100 + Min(tmp, to)];
                            tmp = to;
                            break;
                        }
                    }
                }
            }

            long res = 0;
            int all = 1 << m;
            for (int i = 0; i < all; i++)
            {
                int select = 0;
                long pat = 0;
                for (int j = 0; j < m; j++)
                {
                    if ((i & (1 << j)) == 0) continue;

                    select++;
                    pat |= paths[j];
                }
                int cnt = 0;
                for(int j = 0; j < n - 1; j++)
                {
                    if ((pat & pows[j]) > 0)
                    {
                        cnt++;
                    }
                }

                if (select % 2 == 0)
                {
                    res += pows[n - 1 - cnt];
                }
                else
                {
                    res -= pows[n - 1 - cnt];
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
