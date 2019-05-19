using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_126
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            List<Edge>[] graph = new List<Edge>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<Edge>();
            for (int i = 0; i < n - 1; i++)
            {
                int[] uvw = ReadInts();

                int u = uvw[0] - 1;
                int v = uvw[1] - 1;
                int w = uvw[2];
                graph[u].Add(new Edge(v, w));
                graph[v].Add(new Edge(u, w));
            }

            Queue<int[]> queue=new Queue<int[]>();
            queue.Enqueue(new int[2] { 0, 0 });
            int[] color = new int[n];
            for (int i = 0; i < n; i++) color[i] = -1;
            while (queue.Count > 0)
            {
                int[] val = queue.Dequeue();
                if (color[val[0]] >= 0) continue;

                color[val[0]] = val[1];

                for(int i = 0; i < graph[val[0]].Count; i++)
                {
                    int to = graph[val[0]][i].to;
                    if (color[to] >= 0) continue;

                    int distance = graph[val[0]][i].distance;
                    int colorTmp = val[1];
                    if (distance % 2 > 0)
                    {
                        if (colorTmp == 0) colorTmp = 1;
                        else colorTmp = 0;
                    }

                    queue.Enqueue(new int[2] { to, colorTmp });
                }
            }

            for(int i = 0; i < n; i++)
            {
                WriteLine(color[i]);
            }
        }

        class Edge {
            public int to;
            public int distance;
            public Edge(int to, int distance)
            {
                this.to = to;
                this.distance = distance;
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
