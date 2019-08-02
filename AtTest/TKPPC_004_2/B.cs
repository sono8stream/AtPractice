using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_2
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
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            int[] cs = ReadInts();
            HashSet<int> cSet = new HashSet<int>();
            for (int i = 0; i < m; i++) cSet.Add(cs[i] - 1);

            bool[] visits = new bool[n];
            List<int> indexes = new List<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                indexes.Add(now);
                visits[now] = true;
                for(int i = 0; i < graph[now].Count; i++)
                {
                    if (visits[graph[now][i]]) continue;
                    queue.Enqueue(graph[now][i]);
                }
            }

            int[] cnts = new int[n];
            for(int i = n - 1; i >= 0; i--)
            {
                int now = indexes[i];
                int childCnt = 0;
                int sum = cSet.Contains(now) ? 1 : 0;
                visits[now] = false;
                for(int j = 0; j < graph[now].Count; j++)
                {
                    if (visits[graph[now][j]]) continue;

                    if (cnts[graph[now][j]] > 0)
                    {
                        childCnt++;
                        sum += cnts[graph[now][j]];
                    }
                }
                cnts[now] = sum;

                if (childCnt < 2) continue;
                if (childCnt == 2 && cnts[now] == m) continue;

                WriteLine("trumpet");
                return;
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
