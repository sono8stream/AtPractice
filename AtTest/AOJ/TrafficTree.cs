using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AOJ
{
    class TrafficTree
    {
        static int n;
        static int[] dists;
        static int[] res;
        static List<int>[] graph;

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
            dists = new int[n];
            res = new int[n];
            graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                int[] uv = ReadInts();
                graph[uv[0] - 1].Add(uv[1] - 1);
                graph[uv[1] - 1].Add(uv[0] - 1);
            }
            DFS1(-1,0);
            DFS2(-1, 0, 0);
            for (int i = 0; i < n; i++) WriteLine(res[i]);
        }

        static int DFS1(int from, int to)
        {
            if (to > 0 && graph[to].Count == 1)
            {
                dists[to] = 0;
            }
            else
            {
                int max = 0;
                for (int i = 0; i < graph[to].Count; i++)
                {
                    int next = graph[to][i];
                    if (next == from) continue;
                    max = Max(max, DFS1(to, next));
                }
                dists[to] = max + 1;
            }
            return dists[to];
        }

        static void DFS2(int from,int to, int pValue)
        {
            int maxDist = Max(dists[to], pValue);
            res[to] = 2 * (n - 1) - maxDist;
            int max1 = pValue;
            int max2 = 0;
            for (int i = 0; i < graph[to].Count; i++)
            {
                int next = graph[to][i];
                if (next == from) continue;
                int val = dists[next] + 1;
                if (max1 <= val)
                {
                    max2 = max1;
                    max1 = val;
                }
                else if (max2 <= val)
                {
                    max2 = val;
                }
            }
            for (int i = 0; i < graph[to].Count; i++)
            {
                int next = graph[to][i];
                if (next == from) continue;
                int pNext = max1 == dists[next] + 1 ? max2 : max1;
                pNext++;
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
