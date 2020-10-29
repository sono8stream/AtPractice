using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_106
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();

            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] cd = ReadInts();
                graph[cd[0] - 1].Add(cd[1] - 1);
                graph[cd[1] - 1].Add(cd[0] - 1);
            }

            bool[] visited = new bool[n];
            for(int i = 0; i < n; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                long delta = 0;
                Queue<int> que = new Queue<int>();
                que.Enqueue(i);
                while (que.Count > 0)
                {
                    int now = que.Dequeue();

                    if (visited[now])
                    {
                        continue;
                    }

                    visited[now] = true;
                    delta += aArray[now] - bArray[now];
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (visited[to])
                        {
                            continue;
                        }

                        que.Enqueue(to);
                    }
                }

                if (delta != 0)
                {
                    WriteLine("No");
                    return;
                }
            }

            WriteLine("Yes");
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
