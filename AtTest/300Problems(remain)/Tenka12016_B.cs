using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Tenka12016_B
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
            for(int i = 1; i < n; i++)
            {
                int p = ReadInt();
                nodes[i].parent = p;
            }
            var bcs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                bcs[i] = ReadInts();
            }
            Array.Sort(bcs, (a, b) => a[1] - b[1]);
            int cnt = 0;
            for(int i = 0; i < m; i++)
            {
                var stack = new Stack<int>();
                int now = bcs[i][0];
                while (now > 0)
                {
                    stack.Push(now);
                    now = nodes[now].parent;
                }
                int distance = 0;
                while (stack.Count > 0)
                {
                    int index = stack.Pop();
                    if (!nodes[index].confirm)
                    {
                        int remain = bcs[i][1] - distance;
                        cnt += remain;
                        nodes[index].distance = remain;
                        nodes[index].confirm = true;
                    }
                    distance += nodes[index].distance;
                }
            }
            Console.WriteLine(cnt);
        }

        class Node
        {
            public int parent;
            public int distance;
            public bool confirm;
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
