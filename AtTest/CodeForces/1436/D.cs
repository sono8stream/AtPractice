using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1436
{
    class D
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
            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            int[] roots = ReadInts();
            for (int i = 0; i < n - 1; i++)
            {
                int rt = roots[i] - 1;
                graph[rt].Add(i + 1);
            }
            long[] cs = ReadLongs();

            Queue<int> que = new Queue<int>();
            que.Enqueue(0);
            Stack<int> stk = new Stack<int>();
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                stk.Push(now);
                for(int i = 0; i < graph[now].Count; i++)
                {
                    que.Enqueue(graph[now][i]);
                }
                if (graph[now].Count == 1)
                {

                }
            }

            long[][] dp = new long[n][];
            while (stk.Count > 0)
            {
                int now = stk.Pop();

                if (graph[now].Count == 0)
                {
                        dp[now] = new long[3] { cs[now], cs[now], 1 };
                }
                else
                {
                    long max = 0;
                    long sum = 0;
                    long cnt = 0;
                    for(int i = 0; i < graph[now].Count; i++)
                    {
                        int to = graph[now][i];
                        max = Max(max, dp[to][0]);
                        sum += dp[to][1];
                        cnt += dp[to][2];
                    }
                    sum += cs[now];
                    if (sum > max * cnt)
                    {
                        max = sum / cnt;
                        if (sum % cnt > 0)
                        {
                            max++;
                        }
                    }
                    dp[now] = new long[3] { max, sum, cnt };
                }
            }

            WriteLine(dp[0][0]);
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
