using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_222
{
    class F
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

            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
            }
            for (int i = 0; i < n - 1; i++)
            {
                int[] abc = ReadInts();
                graph[abc[0] - 1].Add(new int[2] { abc[1] - 1, abc[2] });
                graph[abc[1] - 1].Add(new int[2] { abc[0] - 1, abc[2] });
            }

            int[] ds = ReadInts();

            int[] dfsPath = GetDFSPath(graph, 0);
            int[] parents = GetParents(graph, 0);

            long[,] dp = new long[n, 2];

            for (int i = n - 1; i >= 0; i--)
            {
                int now = dfsPath[i];
                dp[now, 0] = ds[now];
                dp[now, 1] = 0;
                for (int j = 0; j < graph[now].Count; j++)
                {
                    int to = graph[now][j][0];
                    long next = graph[now][j][1] + dp[to, 0];
                    if (next >= dp[now, 0])
                    {
                        dp[now, 1] = dp[now, 0];
                        dp[now, 0] = next;
                    }
                    else if (next >= dp[now, 1])
                    {
                        dp[now, 1] = next;
                    }

                    if (dp[to, 1] > 0)
                    {
                        long next2 = graph[now][j][1] + dp[to, 1];
                        if (next2 >= dp[now, 0])
                        {
                            dp[now, 1] = dp[now, 0];
                            dp[now, 0] = next2;
                        }
                        else if (next2 >= dp[now, 1])
                        {
                            dp[now, 1] = next2;
                        }
                    }
                }
            }

            long[] res = new long[n];
            for(int i = 0; i < n; i++)
            {
                int now = dfsPath[i];
                if (parents[now] == -1)
                {
                    res[now] = dp[now, 0];
                }
                else
                {
                }
            }

            for(int i = 0; i < n; i++)
            {
                WriteLine(res[i]);
            }
        }

        static int[] GetParents(List<int[]>[] graph, int startIndex)
        {
            int length = graph.Length;
            int[] parents = new int[length];

            Stack<int> stk = new Stack<int>();
            stk.Push(startIndex);
            bool[] visited = new bool[length];
            visited[startIndex] = true;
            parents[startIndex] = -1;

            int i = 0;
            while (stk.Count > 0)
            {
                int now = stk.Pop();

                for (int j = 0; j < graph[now].Count; j++)
                {
                    int to = graph[now][j][0];
                    if (visited[to])
                    {
                        continue;
                    }

                    stk.Push(to);
                    visited[to] = true;
                    parents[to] = now;
                }
            }

            return parents;
        }

        static int[] GetDFSPath(List<int[]>[] graph,int startIndex)
        {
            int length = graph.Length;
            int[] path = new int[length];

            Stack<int> stk = new Stack<int>();
            stk.Push(startIndex);
            bool[] visited = new bool[length];
            visited[startIndex] = true;

            int i = 0;
            while (stk.Count > 0)
            {
                int now = stk.Pop();
                path[i] = now;
                i++;

                for(int j = 0; j < graph[now].Count; j++)
                {
                    int to = graph[now][j][0];
                    if (visited[to])
                    {
                        continue;
                    }

                    stk.Push(to);
                    visited[to] = true;
                }
            }

            return path;
        }

        static int[] GetBFSPath(List<int[]>[] graph, int startIndex)
        {
            int length = graph.Length;
            int[] path = new int[length];

            Queue<int> que = new Queue<int>();
            que.Enqueue(startIndex);
            bool[] visited = new bool[length];
            visited[startIndex] = true;

            int i = 0;
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                path[i] = now;
                i++;

                for (int j = 0; j < graph[now].Count; j++)
                {
                    int to = graph[now][j][0];
                    if (visited[to])
                    {
                        continue;
                    }

                    que.Enqueue(to);
                    visited[to] = true;
                }
            }

            return path;
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
