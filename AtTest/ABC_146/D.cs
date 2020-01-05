using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_146
{
    class D
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
            List<int[]>[] graph = new List<int[]>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int[]>();
            for (int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(new int[3] { b, 0, i });
                graph[b].Add(new int[3] { a, 0, i });
            }
            int maxColor = 0;
            int[] colors = new int[n - 1];
            Queue<int[]> que = new Queue<int[]>();
            que.Enqueue(new int[3] { 0, -1, 0 });
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                int prev = val[1];
                int prevC = val[2];
                int nowC = 1;
                for(int i = 0; i < graph[now].Count; i++)
                {
                    if (graph[now][i][0] == prev) continue;
                    if (nowC == prevC) nowC++;
                    graph[now][i][1] = nowC;
                    colors[graph[now][i][2]] = nowC;
                    maxColor = Max(maxColor, nowC);
                    que.Enqueue(new int[3] { graph[now][i][0], now, nowC });
                    nowC++;
                }
            }
            WriteLine(maxColor);
            for (int i = 0; i < n - 1; i++) WriteLine(colors[i]);
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
