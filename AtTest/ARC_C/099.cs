using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _099
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
            HashSet<int>[] graph = new HashSet<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<int>();
                for(int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    graph[i].Add(j);
                }
            }
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Remove(b);
                graph[b].Remove(a);
            }

            List<int> blocks = new List<int>();
            int[] states = new int[n];
            for(int i = 0; i < n; i++)
            {
                if (states[i]>0)
                {
                    continue;
                }

                Queue<int[]> que = new Queue<int[]>();
                que.Enqueue(new int[2] { i, 1 });
                int score = 0;
                while (que.Count > 0)
                {
                    int[] val = que.Dequeue();
                    int index = val[0];
                    int state = val[1];

                    if (states[index] > 0)
                    {
                        if (states[index] % 2 == state%2)
                        {
                            continue;
                        }
                        else
                        {
                            WriteLine(-1);
                            return;
                        }
                    }

                    states[index] = state;
                    score += state % 2 == 0 ? 1 : -1;
                    foreach(int to in graph[index])
                    {
                        que.Enqueue(new int[2] { to,state + 1 });
                    }
                }
                blocks.Add(score);
            }
            HashSet<int> vals = new HashSet<int>();
            vals.Add(0);
            for(int i = 0; i < blocks.Count; i++)
            {
                HashSet<int> next = new HashSet<int>();
                foreach(int val in vals)
                {
                    next.Add(val + blocks[i]);
                    next.Add(val - blocks[i]);
                }
                vals = next;
            }
            int min = int.MaxValue;
            foreach (int val in vals)
            {
                int a = (n + val) / 2;
                int b = (n - val) / 2;
                int tmp = (a * (a - 1) + b * (b - 1)) / 2;
                min = Min(min, tmp);
            }
            WriteLine(min);
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
