using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_033
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            if (n == 1)
            {
                WriteLine("First");
                return;
            }
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();

            for(int i = 0; i < n-1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;

                graph[a].Add(b);
                graph[b].Add(a);
            }
            int u = 0;
            bool[] used = new bool[n];
            for(int i = 0; i < n; i++)
            {
                if (graph[i].Count > 1) continue;

                var minQueue = new Queue<int[]>();
                minQueue.Enqueue(new int[2] { i, 1 });
                while (minQueue.Count > 0)
                {
                    int[] val = minQueue.Dequeue();

                    used[val[0]] = true;
                    u = val[0];
                    for(int j = 0; j < graph[val[0]].Count; j++)
                    {
                        if (used[graph[val[0]][j]]) continue;

                        minQueue.Enqueue(new int[2]
                        { graph[val[0]][j], val[1] + 1 });
                    }
                }
                break;
            }

            int length = 0;
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[2] { u, 1 });
            for (int i = 0; i < n; i++) used[i] = false;
            while (queue.Count > 0)
            {
                int[] val = queue.Dequeue();

                used[val[0]] = true;
                length = Max(length, val[1]);
                u = val[0];
                for (int j = 0; j < graph[val[0]].Count; j++)
                {
                    if (used[graph[val[0]][j]]) continue;

                    queue.Enqueue(new int[2]
                    { graph[val[0]][j], val[1] + 1 });
                }
            }

            if ((length-2) % 3 == 0)
            {
                WriteLine("Second");
            }
            else
            {
                WriteLine("First");
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
