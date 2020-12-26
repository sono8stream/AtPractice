using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1363
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
            int n = ReadInt();
            int[][] abcs = new int[n][];
            List<int>[] graph = new List<int>[n];
            int ones = 0;
            int targetOnes = 0;
            for (int i = 0; i < n; i++)
            {
                abcs[i] = ReadInts();
                graph[i] = new List<int>();
                if (abcs[i][1] == 1)
                {
                    ones++;
                }

                if (abcs[i][2] == 1)
                {
                    targetOnes++;
                }
            }

            for(int i = 0; i < n - 1; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0] - 1;
                int v = uv[1] - 1;
                graph[u].Add(v);
                graph[v].Add(u);
            }

            if (ones != targetOnes)
            {
                WriteLine(-1);
                return;
            }

            long[] costs = new long[n];
            int[] pars = new int[n];
            var que = new Queue<int[]>();
            que.Enqueue(new int[3] { 0, -1, int.MaxValue });
            var stk = new Stack<int>();
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                pars[now] = val[1];
                costs[now] = Min(val[2], abcs[now][0]);
                stk.Push(now);

                for (int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (to == pars[now])
                    {
                        continue;
                    }

                    que.Enqueue(new int[3] { to, now, (int)costs[now] });
                }
            }

            long res = 0;
            int[] zeroCnts = new int[n];
            int[] oneCnts = new int[n];
            while (stk.Count > 0)
            {
                int now = stk.Pop();
                if (abcs[now][1] != abcs[now][2])
                {
                    if (abcs[now][1] == 0)
                    {
                        zeroCnts[now]++;
                    }
                    else
                    {
                        oneCnts[now]++;
                    }
                }

                int min = Min(zeroCnts[now], oneCnts[now]);
                res += costs[now] * min * 2;
                if (pars[now] >= 0)
                {
                    zeroCnts[pars[now]] += zeroCnts[now] - min;
                    oneCnts[pars[now]] += oneCnts[now] - min;
                }
            }

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
