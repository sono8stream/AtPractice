using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Nikkei2019
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            Node[] nodes = new Node[n];
            for(int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }
            for(int i = 0; i < n - 1 + m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                nodes[a].outEdges.Add(b, true);
                nodes[b].inEdges.Add(a, true);
            }
            int[] parents = new int[n];
            int rootIndex = 0;
            for(int i = 0; i < n; i++)
            {
                if (nodes[i].inEdges.Count == 0)
                {
                    rootIndex = i;
                    break;
                }
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(rootIndex);
            parents[rootIndex] = 0;
            var visitedDict = new Dictionary<int,bool>();
            while (queue.Count > 0)
            {
                int index = queue.Dequeue();
                visitedDict.Add(index, true);
                foreach(int key in nodes[index].outEdges.Keys)
                {
                    nodes[key].inEdges.Remove(index);
                    if (nodes[key].inEdges.Count == 0)
                    {
                        parents[key] = index + 1;
                        queue.Enqueue(key);
                    }
                }
            }
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(parents[i]);
            }
        }

        class Node
        {
            public Dictionary<int, bool> inEdges;
            public Dictionary<int, bool> outEdges;
            public Node()
            {
                inEdges = new Dictionary<int, bool>();
                outEdges = new Dictionary<int, bool>();
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
