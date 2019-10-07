using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_039
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
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = i + 1; j < n; j++)
                {
                    if (s[j] == '1')
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }
            int[] states = new int[n];
            Queue<int[]> queue=new Queue<int[]>();
            queue.Enqueue(new int[2] { 0, 1 });
            while (queue.Count > 0)
            {
                int[] val = queue.Dequeue();
                int index = val[0];
                int state = val[1];
                if (states[index] > 0) continue;

                states[index] = state;
                int next = state == 1 ? 2:1;
                for(int i = 0; i < graph[index].Count; i++)
                {
                    queue.Enqueue(new int[2] { graph[index][i], next });
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < graph[i].Count; j++)
                {
                    if (states[i] == states[graph[i][j]])
                    {
                        WriteLine(-1);
                        return;
                    }
                }
            }

            int res = 0;
            for(int i = 0; i < n; i++)
            {
                Queue<int[]> que = new Queue<int[]>();
                int max = 0;
                que.Enqueue(new int[2] { i, 1 });
                bool[] visited = new bool[n];
                while (que.Count > 0)
                {
                    int[] val = que.Dequeue();
                    int index = val[0];
                    int dist = val[1];
                    if (visited[index]) continue;

                    visited[index] = true;
                    max = Max(max, dist);

                    for(int j = 0; j < graph[index].Count; j++)
                    {
                        que.Enqueue(new int[2] { graph[index][j], dist + 1 });
                    }
                }
                res = Max(res, max);
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
