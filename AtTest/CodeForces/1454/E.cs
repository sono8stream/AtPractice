using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1454
{
    class E
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
                int n = ReadInt();
                List<int>[] graph = new List<int>[n];
                for(int j = 0; j < n; j++)
                {
                    graph[j] = new List<int>();
                }
                for(int j = 0; j < n; j++)
                {
                    int[] ab = ReadInts();
                    int a = ab[0] - 1;
                    int b = ab[1] - 1;
                    graph[a].Add(b);
                    graph[b].Add(a);
                }

                int[] costs = new int[n];
                for(int j = 0; j < n; j++)
                {
                    costs[j] = int.MaxValue / 10;
                }
                Stack<int[]> stk = new Stack<int[]>();
                stk.Push(new int[3] { 0, 0,-1 });
                int root = -1;
                int rootCost2 = -1;
                while (stk.Count > 0)
                {
                    int[] vals = stk.Pop();
                    int now = vals[0];
                    int cost = vals[1];
                    int par = vals[2];

                    if (costs[now] < int.MaxValue / 10)
                    {
                        root = now;
                        rootCost2 = cost;
                        break;
                    }
                    costs[now] = cost;

                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (to == par)
                        {
                            continue;
                        }

                        stk.Push(new int[3] { to, cost + 1, now });
                    }
                }

                HashSet<int> loops = new HashSet<int>();
                int nowIdx = root;
                while (rootCost2 > costs[root])
                {
                    loops.Add(nowIdx);
                    rootCost2--;
                    for(int j = 0; j < graph[nowIdx].Count; j++)
                    {
                        int to = graph[nowIdx][j];
                        if (rootCost2 == costs[to])
                        {
                            nowIdx = to;
                            break;
                        }
                    }
                }

                long res = 0;
                foreach(int key in loops)
                {
                    long childs = 0;
                    Queue<int[]> que2 = new Queue<int[]>();
                    que2.Enqueue(new int[2] { key, -1 });
                    while (que2.Count > 0)
                    {
                        int[] vals = que2.Dequeue();
                        int now = vals[0];
                        int par = vals[1];

                        childs++;
                        for(int j = 0; j < graph[now].Count; j++)
                        {
                            int to = graph[now][j];
                            if (to == par)
                            {
                                continue;
                            }
                            if (now == key && loops.Contains(to))
                            {
                                continue;
                            }

                            que2.Enqueue(new int[2] { to, now });
                        }
                    }

                    res += childs * (childs - 1);
                    res += childs * (n - childs) * 2;
                }

                WriteLine(res / 2);
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
