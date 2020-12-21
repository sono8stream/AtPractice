using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1364
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];

            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] uv = ReadInts();
                int u = uv[0] - 1;
                int v = uv[1] - 1;
                graph[u].Add(v);
                graph[v].Add(u);
            }

            int[] states = new int[n];
            states[0] = 1;
            var que = new Queue<int>();
            que.Enqueue(0);
            int[] pars = new int[n];
            pars[0] = -1;
            int target = k / 2;
            if (k % 2 == 1)
            {
                target++;
            }
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                for(int i = 0; i < graph[now].Count; i++)
                {
                    int to = graph[now][i];
                    if (pars[now] == to)
                    {
                        continue;
                    }
                    if (states[to] > 0)
                    {
                        // 閉路検出
                        int left = now;
                        int right = to;
                        List<int> lefts = new List<int>();
                        List<int> rights = new List<int>();
                        while (states[right] > states[left])
                        {
                            rights.Add(right);
                            right = pars[right];
                        }
                        while (left != right)
                        {
                            lefts.Add(left);
                            left = pars[left];
                            rights.Add(right);
                            right = pars[right];
                        }
                        lefts.Add(left);
                        for(int j = rights.Count - 1; j >= 0; j--)
                        {
                            lefts.Add(rights[j]);
                        }

                        if (lefts.Count <= k)
                        {
                            WriteLine(2);
                            WriteLine(lefts.Count);
                            for (int j = 0; j < lefts.Count; j++)
                            {
                                Write(lefts[j] + 1);
                                if (j + 1 < lefts.Count)
                                {
                                    Write(" ");
                                }
                                else
                                {
                                    WriteLine();
                                }
                            }
                        }
                        else
                        {
                            WriteLine(1);
                            for (int j = 0; j < target; j++)
                            {
                                Write(lefts[j * 2] + 1);
                                if (j + 1 < target)
                                {
                                    Write(" ");
                                }
                                else
                                {
                                    WriteLine();
                                }
                            }
                        }
                        return;
                    }
                    else
                    {
                        states[to] = states[now] + 1;
                        pars[to] = now;
                        que.Enqueue(to);
                    }
                }
            }

            List<int> odds = new List<int>();
            List<int> evens = new List<int>();
            for(int i = 0; i < n; i++)
            {
                if (states[i] % 2 == 1)
                {
                    odds.Add(i);
                }
                else
                {
                    evens.Add(i);
                }
            }
            if (odds.Count < evens.Count)
            {
                odds = evens;
            }

            WriteLine(1);
            for(int i = 0; i < target; i++)
            {
                Write(odds[i] + 1);
                if (i + 1 < target)
                {
                    Write(" ");
                }
                else
                {
                    WriteLine();
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
