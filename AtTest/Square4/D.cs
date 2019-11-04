using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Square4
{
    class D
    {
        static int n;
        static List<int>[] graph;
        static double[] dp;
        static double[] res;

        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            n = ReadInt();
            graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            dp = new double[n];
            res = new double[n];
            for(int i = 0; i < n - 1; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0] - 1;
                int v = uv[1] - 1;
                graph[u].Add(v);
                graph[v].Add(u);
            }
            DFS1(-1, 0);
            DFS2(-1, 0, 0);
            for(int i = 0; i < n; i++)
            {
                WriteLine(res[i]);
            }
        }

        static double DFS1(int from,int to)
        {
            if (to != 0 && graph[to].Count == 1)
            {
                dp[to] = 0;
            }
            else
            {
                double val = 0;
                for(int i = 0; i < graph[to].Count; i++)
                {
                    int next = graph[to][i];
                    if (from == next) continue;

                    val += DFS1(to, next) + 1;
                }
                if (to == 0) val /= graph[to].Count;
                else val /= graph[to].Count - 1;
                dp[to] = val;
            }
            return dp[to];
        }

        static void DFS2(int from, int to, double pValue)
        {
            if (to == 0)
            {
                res[to] = dp[to];
            }
            else
            {
                res[to] = (dp[to] * (graph[to].Count - 1) + pValue + 1) / graph[to].Count;
            }

            for (int i = 0; i < graph[to].Count; i++)
            {
                int next = graph[to][i];
                if (from == next) continue;

                double pNext;
                if (to == 0 && graph[to].Count == 1) pNext = 0;
                else pNext = (res[to] * graph[to].Count - dp[next] - 1) / (graph[to].Count - 1);
                DFS2(to, next, pNext);
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
