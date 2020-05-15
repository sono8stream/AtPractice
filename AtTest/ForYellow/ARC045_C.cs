using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC045_C
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
            int[] nx = ReadInts();
            int n = nx[0];
            int x = nx[1];
            List<int[]>[] graph = new List<int[]>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] xyc = ReadInts();
                int xx = xyc[0] - 1;
                int yy = xyc[1] - 1;
                int cc = xyc[2];
                graph[xx].Add(new int[2] { yy, cc });
                graph[yy].Add(new int[2] { xx, cc });
            }

            int[] vals = new int[n];
            for(int i = 0; i < n; i++)
            {
                vals[i] = -1;
            }
            Queue<int[]> que = new Queue<int[]>();
            que.Enqueue(new int[2] { 0, 0 });
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int idx = val[0];
                int v = val[1];
                vals[idx] = v;

                for(int i = 0; i < graph[idx].Count; i++)
                {
                    int to = graph[idx][i][0];
                    if (vals[to] >= 0)
                    {
                        continue;
                    }

                    int next = v ^ graph[idx][i][1];
                    que.Enqueue(new int[2] { to, next });
                }
            }

            var dict = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(vals[i]))
                {
                    dict[vals[i]]++;
                }
                else
                {
                    dict.Add(vals[i], 1);
                }
            }

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                int other = vals[i] ^ x;
                if (vals[i] == other)
                {
                    res += dict[other] - 1;
                }
                else if (dict.ContainsKey(other))
                {
                    res += dict[other];
                }
            }
            WriteLine(res / 2);
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
