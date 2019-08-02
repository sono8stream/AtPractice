using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class L
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
            int[] nmkxy = ReadInts();
            int n = nmkxy[0];
            int m = nmkxy[1];
            int k = nmkxy[2];
            int x = nmkxy[3];
            int y = nmkxy[4];
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            char[] pats = ReadChars();
            int[] patInts = new int[n];
            for(int i = 0; i < n; i++)
            {
                switch (pats[i])
                {
                    case 'G':
                        patInts[i] = 0;
                        break;
                    case 'C':
                        patInts[i] = 1;
                        break;
                    case 'P':
                        patInts[i] = 2;
                        break;
                }
            }

            int[] ds = ReadInts();
            for (int i = 0; i < k; i++) ds[i]--;

            int[] dists = new int[n];
            for (int i = 0; i < n; i++) dists[i] = int.MaxValue;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[2] { 0, 0 });
            while (queue.Count > 0)
            {
                int[] val = queue.Dequeue();
                int index = val[0];
                int dist = val[1];

                if (dists[index] <= dist) continue;

                dists[index] = dist;
                for (int i = 0; i < graph[index].Count; i++)
                {
                    if (dists[graph[index][i]] <= dist + 1) continue;

                    queue.Enqueue(new int[2] { graph[index][i], dist + 1 });
                }
            }

            int[,] dp = new int[k, n];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dists[j] > i+1) continue;

                    int max = 0;
                    if (i > 0) {
                        max = dp[i - 1, j];
                        for (int itr = 0; itr < graph[j].Count; itr++)
                        {

                            max = Max(max, dp[i - 1, graph[j][itr]]);
                        }
                    }
                    int me = patInts[j];
                    switch ((3 + me - patInts[ds[i]]) % 3)
                    {
                        case 0:
                            dp[i, j] = max + y;
                            break;
                        case 1:
                            dp[i, j] = max;
                            break;
                        case 2:
                            dp[i, j] = max + x;
                            break;
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < n; i++) res = Max(res, dp[k - 1, i]);
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
