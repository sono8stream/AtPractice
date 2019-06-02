using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_034
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s = Read();
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                graph[ab[0] - 1].Add(ab[1] - 1);
                graph[ab[1] - 1].Add(ab[0] - 1);
            }

            long points = 0;
            for(int i = 0; i < n; i++)
            {
                if (s[i] == '1') points++;
            }
            if (points == 1)
            {
                WriteLine(0);
                return;
            }

            long res = long.MaxValue;
            for(int i = 0; i < n; i++)
            {
                Queue<int[]> queue = new Queue<int[]>();
                long[][] dists = new long[n][];
                for (int j = 0; j < dists.Length; j++)
                {
                    dists[j] = new long[2] { -1, 0 };
                }
                dists[i][0] = 0;
                for(int j = 0; j < graph[i].Count; j++)
                {
                    queue.Enqueue(new int[3] { graph[i][j], j+1, 1 });
                }
                while (queue.Count>0)
                {
                    int[] val = queue.Dequeue();
                    if (dists[val[0]][0] >= 0) continue;

                    dists[val[0]][0] = val[2];
                    dists[val[0]][1] = val[1];

                    for(int j = 0; j < graph[val[0]].Count; j++)
                    {
                        int next = graph[val[0]][j];
                        if (dists[next][0] >= 0) continue;

                        queue.Enqueue(new int[3] { next, val[1], val[2] + 1 });
                    }
                }

                var dict = new Dictionary<long, long>();
                long sum = 0;
                for(int j = 0; j < n; j++)
                {
                    if (s[j] == '0') continue;

                    if (!dict.ContainsKey(dists[j][1]))
                    {
                        dict.Add(dists[j][1], 0);
                    }
                    dict[dists[j][1]] += dists[j][0];
                    sum += dists[j][0];
                }
                if (sum % 2 > 0) continue;

                bool ok = true;
                foreach(long key in dict.Keys)
                {
                    if (dict[key] < sum / 2) continue;

                    ok = false;
                    break;
                }
                if (ok) res = Min(res, sum / 2);
            }

            if (res == long.MaxValue)
            {
                WriteLine(-1);
            }
            else
            {
                WriteLine(res);
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
