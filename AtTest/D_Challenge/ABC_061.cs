using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_061
    {
        static Node[] nodes;
        static long[] distances;

        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            nodes = new Node[nm[0]];
            for(int i =0; i < nm[0]; i++)
            {
                nodes[i] = new Node(nm[0]);
            }
            for(int i = 0; i < nm[1]; i++)
            {
                long[] abc = ReadLongs();
                nodes[abc[0] - 1].edges.Add(new Edge((int)abc[1] - 1, abc[2]));
            }
            Console.WriteLine("text");
        }

        static bool DetectLoop()
        {

            return true;
        }

        static void DFS(int index, long distance,int cnt,int n)
        {
            if (distances[index] > distance) return;
            distances[index] = distance;

            if (cnt >= n) return;

            for (int i = 0; i < nodes[index].edges.Count; i++)
            {
                Edge edge = nodes[index].edges[i];
                DFS(edge.toIndex, distance + edge.distance, cnt + 1, n);
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }

        class Node
        {
            public List<Edge> edges;
            public Node(int length)
            {
                edges = new List<Edge>();
            }
        }

        class Edge
        {
            public int toIndex;
            public long distance;

            public Edge(int toIndex, long distance)
            {
                this.toIndex = toIndex;
                this.distance = distance;
            }
        }
    }
}
