using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CSA
{
    class VirusOnATree
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            List<int[]>[] graph = new List<int[]>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int[]>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] val = ReadInts();
                int a = val[0] - 1;
                int b = val[1] - 1;
                int c = val[2];
                graph[a].Add(new int[2] { b, c });
                graph[b].Add(new int[2] { a, c });
            }

            bool[] visited = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue( 0);
            int cnt = 0;
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                if (visited[now]) continue;

                cnt++;
                visited[now] = true;
                if (cnt >= k) break;
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
