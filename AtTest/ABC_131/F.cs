using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_131
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] xys = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xys[i] = ReadInts();
            }

            int length = 100000 + 5;
            List<int>[] graph = new List<int>[length * 2];
            for(int i =0; i < length; i++)
            {
                graph[i] = new List<int>();
                graph[i + length] = new List<int>();
            }

            for(int i = 0; i < n; i++)
            {
                graph[xys[i][0]].Add(length + xys[i][1]);
                graph[length + xys[i][1]].Add(xys[i][0]);
            }

            bool[] used = new bool[length * 2];
            long res = 0;
            for(int i = 0; i < length*2; i++)
            {
                if (used[i]) continue;

                Queue<int> que = new Queue<int>();
                long edges = 0;
                long xs = 0;
                long ys = 0;
                que.Enqueue(i);
                while (que.Count > 0)
                {
                    int index = que.Dequeue();
                    if (used[index]) continue;

                    used[index] = true;
                    if (index < length) xs++;
                    else ys++;
                    edges += graph[index].Count;
                    for (int j = 0; j < graph[index].Count; j++)
                    {
                        if (used[graph[index][j]]) continue;

                        que.Enqueue(graph[index][j]);
                    }
                }
                edges /= 2;
                if (xs >= 2 && ys >= 2) res += xs * ys - edges;
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
