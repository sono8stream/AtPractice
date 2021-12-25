using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_222
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            int[] array = ReadInts();

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < n - 1; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0];
                int v = uv[1];
                graph[u - 1].Add(v - 1);
                graph[v - 1].Add(u - 1);
            }

            int[] parents = new int[n];
            for (int i = 0; i < n; i++)
            {
                parents[i] = -10;
            }
            parents[0] = -1;

            Queue<int> que = new Queue<int>();
            que.Enqueue(0);
            while (que.Count > 0)
            {
                int id = que.Dequeue();
                for (int i = 0; i < graph[id].Count; i++)
                {
                    int to = graph[id][i];
                    if (parents[to] != -10)
                    {
                        continue;
                    }

                    parents[to] = id;
                    que.Enqueue(to);
                }
            }

            Dictionary<int, int> costs = new Dictionary<int, int>();
            for (int i = 0; i + 1 < m; i++)
            {
                HashSet<int> roots = new HashSet<int>();
                int now = array[i] - 1;
                while (now != -1)
                {
                    roots.Add(now);
                    now = parents[now];
                }

                now = array[i + 1] - 1;
                int root = 0;
                while (now != -1)
                {
                    if (roots.Contains(now))
                    {
                        root = now;
                        break;
                    }
                    else
                    {
                        now = parents[now];
                    }
                }

                now = array[i] - 1;
                while (now != root)
                {
                    int key = parents[now] * 1000 + now;
                    if (costs.ContainsKey(key))
                    {
                        costs[key]++;
                    }
                    else
                    {
                        costs.Add(key, 1);
                    }
                    now = parents[now];
                }

                now = array[i + 1] - 1;
                while (now != root)
                {
                    int key = parents[now] * 1000 + now;
                    if (costs.ContainsKey(key))
                    {
                        costs[key]++;
                    }
                    else
                    {
                        costs.Add(key, 1);
                    }
                    now = parents[now];
                }
            }

            int mask = 998244353;
            Dictionary<int, int> dp = new Dictionary<int, int>();
            dp.Add(0, 1);
            foreach (int key in costs.Keys)
            {
                Dictionary<int, int> next = new Dictionary<int, int>();
                foreach (int key2 in dp.Keys)
                {
                    if (next.ContainsKey(key2))
                    {
                        next[key2] += dp[key2];
                        next[key2] %= mask;
                    }
                    else
                    {
                        next.Add(key2, dp[key2]);
                    }

                    if (next.ContainsKey(key2 + costs[key]))
                    {
                        next[key2 + costs[key]] += dp[key2];
                        next[key2 + costs[key]] %= mask;
                    }
                    else
                    {
                        next.Add(key2 + costs[key], dp[key2]);
                    }
                }

                dp = next;
            }


            int allCosts = 0;
            foreach (int key in costs.Keys)
            {
                allCosts += costs[key];
            }

            int res = 0;
            if ((k + allCosts) % 2 == 0 && dp.ContainsKey((k + allCosts) / 2))
            {
                res = dp[(k + allCosts) / 2];
            }

            for (int i = 0; i < n - 1 - costs.Count; i++)
            {
                res *= 2;
                res %= mask;
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
