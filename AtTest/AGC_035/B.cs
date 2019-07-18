using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_035
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];

            HashSet<int>[] graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new HashSet<int>();

            for (int i = 0; i < m; i++)
            {
                int[] cd = ReadInts();
                int c = cd[0] - 1;
                int d = cd[1] - 1;
                graph[c].Add(d);
                graph[d].Add(c);
            }

            if (m % 2 == 1)
            {
                WriteLine(-1);
                return;
            }

            List<int> poses = new List<int>();
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[n];
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                if (visited[now]) continue;

                visited[now] = true;
                poses.Add(now);

                foreach(int to in graph[now])
                {
                    queue.Enqueue(to);
                }
            }

            List<int[]> res = new List<int[]>();
            int[] fromCnts = new int[n];
            for(int i = n - 1; i >= 0; i--)
            {
                int now = poses[i];
                if (fromCnts[now] % 2 == 1)
                {
                    int to = graph[now].First();
                    res.Add(new int[2] { now, to });
                    fromCnts[now]++;
                    graph[now].Remove(to);
                    graph[to].Remove(now);
                }

                int remain = (graph[now].Count / 2) * 2;
                for (int j = 0; j < remain; j++)
                {
                    int to = graph[now].First();
                    res.Add(new int[2] { now, to });
                    fromCnts[now]++;
                    graph[now].Remove(to);
                    graph[to].Remove(now);
                    queue.Enqueue(to);
                }

                if (graph[now].Count > 0)
                {
                    int to = graph[now].First();
                    res.Add(new int[2] { to, now });
                    fromCnts[to]++;
                    graph[now].Remove(to);
                    graph[to].Remove(now);
                    queue.Enqueue(to);
                }
            }

            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);
            for (int i = 0; i < res.Count; i++)
            {
                WriteLine((res[i][0] + 1) + " " + (res[i][1] + 1));
            }

            Out.Flush();
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
