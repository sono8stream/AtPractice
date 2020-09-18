using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.Graph
{
    class GraphUtil
    {
        class Graph
        {
            int n;
            List<Edge>[] edges;

            public Graph(int n)
            {
                this.n = n;
                edges = new List<Edge>[n];
                for (int i = 0; i < n; i++)
                {
                    edges[i] = new List<Edge>();
                }
            }

            public static Graph ReadAndInitialize(bool isWeighted)
            {
                int[] nm = ReadInts();

                int n = nm[0];
                Graph g = new Graph(n);

                int m = nm[1];
                for (int i = 0; i < m; i++)
                {
                    long[] uvx = ReadLongs();
                    int u = (int)uvx[0] - 1;
                    int v = (int)uvx[1] - 1;

                    long x = isWeighted ? uvx[1] : 1;
                    g.edges[u].Add(new Edge(v, x));
                    g.edges[v].Add(new Edge(u, x));
                }

                return g;
            }

            public List<Edge> Edges(int from)
            {
                return edges[from];
            }
        }

        class Edge
        {
            int to;
            long weight;

            public Edge(int to, long weight)
            {
                this.to = to;
                this.weight = weight;
            }
        }

        public static string Read() { return ReadLine(); }
        public static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        public static int ReadInt() { return int.Parse(Read()); }
        public static long ReadLong() { return long.Parse(Read()); }
        public static double ReadDouble() { return double.Parse(Read()); }
        public static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        public static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        public static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }

    }
}