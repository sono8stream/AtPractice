using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class AGC014_D
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
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            int[] parents = new int[n];
            var que = new Queue<int>();
            var stk = new Stack<int>();
            que.Enqueue(0);
            stk.Push(0);
            parents[0] = -1;
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                foreach (int to in graph[now])
                {
                    if (to == parents[now])
                    {
                        continue;
                    }

                    parents[to] = now;
                    que.Enqueue(to);
                    stk.Push(to);
                }
            }

            while (stk.Count > 0)
            {
                int now = stk.Pop();
                if (graph[now].Count == 0)
                {
                    continue;
                }

                if (parents[now] == -1 || graph[parents[now]].Count == 0)
                {
                    WriteLine("First");
                    return;
                }

                graph[parents[now]].Clear();
            }

            WriteLine("Second");
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
