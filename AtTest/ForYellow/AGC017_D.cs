using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class AGC017_D
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
            for(int i = 0; i < n - 1; i++)
            {
                int[] xy = ReadInts();
                int x = xy[0] - 1;
                int y = xy[1] - 1;

                graph[x].Add(y);
                graph[y].Add(x);
            }

            if (DFS(graph, 0, -1) > 0)
            {
                WriteLine("Alice");
            }
            else
            {
                WriteLine("Bob");
            }
        }

        static int DFS(List<int>[] graph,int now,int parent)
        {
            if (parent >= 0 && graph[now].Count == 1)
            {
                return 0;
            }

            int val = 0;
            for(int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];
                if (to == parent)
                {
                    continue;
                }

                val ^= DFS(graph, to, now) + 1;
            }

            return val;
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
