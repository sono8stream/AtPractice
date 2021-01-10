using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_111
{
    class B
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
            int length = 400000;
            List<int>[] graph = new List<int>[length];
            for(int i = 0; i < length; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < n; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            int res = 0;
            bool[] visited = new bool[length];
            for(int i = 0; i < length; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                int edges = graph[i].Count;
                int vertices = 1;
                var que = new Queue<int>();
                visited[i] = true;
                que.Enqueue(i);
                while (que.Count > 0)
                {
                    int now = que.Dequeue();
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (visited[to])
                        {
                            continue;
                        }

                        visited[to] = true;
                        que.Enqueue(to);
                        vertices++;
                        edges += graph[to].Count;
                    }
                }
                if (edges / 2 == vertices - 1)
                {
                    res += vertices - 1;
                }
                else
                {
                    res += vertices;
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
