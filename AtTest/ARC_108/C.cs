using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_108
{
    class C
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

            List<int[]>[] graph = new List<int[]>[n];
            HashSet<int>[] used = new HashSet<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
                used[i] = new HashSet<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] uvc = ReadInts();
                int u = uvc[0] - 1;
                int v = uvc[1] - 1;
                int c = uvc[2];
                if (used[u].Contains(v))
                {
                    continue;
                }

                graph[u].Add(new int[2] { v, c });
                graph[v].Add(new int[2] { u, c });
                used[u].Add(v);
                used[v].Add(u);
            }

            int[] nums = new int[n];
            Queue<int[]> que = new Queue<int[]>();
            // idx, prev, edge no
            que.Enqueue(new int[3] { 0, -1, -1 });
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                int prev = val[1];
                int edgeNo = val[2];
                if (nums[now] > 0)
                {
                    continue;
                }

                if (prev == -1 || nums[prev] == edgeNo)
                {
                    List<int> cannots = new List<int>();
                    cannots.Add(edgeNo);
                    for(int i = 0; i < graph[now].Count; i++)
                    {
                        if (nums[graph[now][i][0]] == 0)
                        {
                            cannots.Add(graph[now][i][1]);
                        }
                    }
                    cannots.Sort();
                    int num = 1;
                    for(int i = 0; i < cannots.Count; i++)
                    {
                        if (cannots[i] == num)
                        {
                            num++;
                        }
                    }
                    nums[now] = num;
                }
                else
                {
                    nums[now] = edgeNo;
                }

                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i][0];
                    if (nums[to] == 0)
                    {
                        que.Enqueue(new int[3] { to, now, graph[now][i][1] });
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                WriteLine(nums[i]);
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
