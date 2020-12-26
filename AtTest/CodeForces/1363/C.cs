using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1363
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nx = ReadInts();
                int n = nx[0];
                int x = nx[1]-1;
                List<int>[] graph = new List<int>[n];
                for(int j = 0; j < n; j++)
                {
                    graph[j] = new List<int>();
                }
                for(int j = 0; j < n - 1; j++)
                {
                    int[] uv = ReadInts();
                    int u = uv[0] - 1;
                    int v = uv[1] - 1;
                    graph[u].Add(v);
                    graph[v].Add(u);
                }

                if (n == 1)
                {
                    WriteLine("Ayush");
                    continue;
                }

                int[] childs = new int[n];
                int[] pars = new int[n];
                var que = new Queue<int[]>();
                que.Enqueue(new int[2] { x, -1 });
                var stk = new Stack<int>();
                while (que.Count > 0)
                {
                    int[] val = que.Dequeue();
                    int now = val[0];
                    int par = val[1];
                    stk.Push(now);
                    pars[now] = par;
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (to == par)
                        {
                            continue;
                        }

                        que.Enqueue(new int[2] { to, now });
                    }
                }

                while (stk.Count > 0)
                {
                    int now = stk.Pop();
                    int child = 0;
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (to == pars[now])
                        {
                            continue;
                        }
                        child += childs[to] + 1;
                    }
                    childs[now] = child;
                }

                if (graph[x].Count == 1)
                {
                    WriteLine("Ayush");
                }
                else
                {
                    int sum = childs[x] - 2;
                    if (sum % 2 == 0)
                    {
                        WriteLine("Ashish");
                    }
                    else
                    {
                        WriteLine("Ayush");
                    }
                }

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
