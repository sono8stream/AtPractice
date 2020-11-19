using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1445
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            int[] cs = ReadInts();
            HashSet<int>[] graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<int>();
            }
            for (int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            HashSet<int>[] cannots = new HashSet<int>[k];
            bool[] cans = new bool[k];
            for (int i = 0; i < k; i++)
            {
                cannots[i] = new HashSet<int>();
                cans[i] = true;
            }

            int[] states = new int[n];
            Queue<int[]> que = new Queue<int[]>();
            que.Enqueue(new int[2] { 0, -1 });
            states[0] = 1;
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                int prev = val[1];

                int nowColor = cs[now] - 1;
                int prevColor = prev >= 0 ? cs[prev] - 1 : -1;

                int state = states[now];

                foreach (int to in graph[now])
                {
                    int toColor = cs[to] - 1;
                    if (states[to] == state)
                    {
                        if (toColor == nowColor && toColor == prevColor)
                        {
                            cans[nowColor] = false;
                        }
                        else if (toColor == nowColor || toColor == prevColor)
                        {
                            cannots[nowColor].Add(prevColor);
                            cannots[prevColor].Add(nowColor);
                        }
                        else if (nowColor == prevColor)
                        {
                            cannots[nowColor].Add(toColor);
                            cannots[toColor].Add(nowColor);
                        }
                    }

                    if (states[to] == 0)
                    {
                        states[to] = state == 1 ? 2 : 1;
                        que.Enqueue(new int[2] { to, now });
                    }
                }
            }

            int allCannots = 0;
            for(int i = 0; i < k; i++)
            {
                if (!cans[i])
                {
                    allCannots++;
                }
            }

            long res = 0;
            for(int i = 0; i < k; i++)
            {
                if (!cans[i])
                {
                    continue;
                }

                int cannot = 0;
                foreach(int to in cannots[i])
                {
                    if (cans[to])
                    {
                        cannot++;
                    }
                }
                res += k - cannot - 1 - allCannots;
            }
            WriteLine(res / 2);
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
