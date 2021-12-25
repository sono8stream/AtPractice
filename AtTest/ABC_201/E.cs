using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_201
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
            List<long[]>[] graph = new List<long[]>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<long[]>();
            }

            for(int i = 0; i < n - 1; i++)
            {
                long[] uvw = ReadLongs();
                graph[uvw[0]-1].Add(new long[2] { uvw[1]-1, uvw[2] });
                graph[uvw[1]-1].Add(new long[2] { uvw[0]-1, uvw[2] });
            }

            long mask = 1000000000 + 7;

            var order = new List<int>();
            var que = new Queue<int>();
            que.Enqueue(0);
            var parents = new int[n];
            while (que.Count > 0)
            {
                int now = que.Dequeue();

                order.Add(now);

                for (int i = 0; i < graph[now].Count; i++)
                {
                    int to = (int)graph[now][i][0];
                    if (parents[now] == to)
                    {
                        continue;
                    }

                    que.Enqueue(to);
                    parents[to] = now;
                }
            }

            int[,] cnts = new int[n, 65];
            long res = 0;
            int[] childs = new int[n];
            // 下から
            for(int i = n - 1; i >= 0; i--)
            {
                int now = order[i];
                for(int j = 0; j < graph[now].Count; j++)
                {
                    int to = (int)graph[now][j][0];
                    if (parents[now] == to)
                    {
                        continue;
                    }

                    long dist = graph[now][j][1];
                    childs[now] += childs[to] + 1;

                    long div = 1;
                    for(int k = 0; k < 65; k++)
                    {
                        if ((dist & div) > 0)
                        {
                            cnts[now, k] += (childs[to] + 1 - cnts[to, k]);
                            res += (childs[to] + 1 - cnts[to, k]) * div;
                            res %= mask;
                        }
                        else
                        {
                            cnts[now, k] += cnts[to, k];
                            res +=  cnts[to, k] * div;
                            res %= mask;
                        }
                        div *= 2;
                    }
                }
            }

            // 上から
            var uppers = new int[n, 65];
            long res2 = 0;
            for (int i = 0; i < n; i++)
            {
                int now = order[i];
                for (int j = 0; j < graph[now].Count; j++)
                {
                    // 下へ伝播させる
                    int to = (int)graph[now][j][0];
                    if (parents[now] == to)
                    {
                        continue;
                    }

                    long dist = graph[now][j][1];
                    long div = 1;
                    for (int k = 0; k < 65; k++)
                    {
                        if ((dist & div) > 0)
                        {
                            uppers[to, k] = uppers[now, k] + cnts[now, k] - (childs[to] + 1 - cnts[to, k]);
                        }
                        else
                        {
                            uppers[to, k] = uppers[now, k] + cnts[now, k] - cnts[to, k];
                        }
                        res2 += uppers[to, k] * div;
                        res2 %= mask;

                        div *= 2;
                    }
                }
            }
            if (res2 % 2 == 0)
            {
                res += res2 / 2;
            }
            else
            {
                res += (res2 + mask) / 2;
            }
            res %= mask;


            /*
            int[,] costs = new int[n, 65];
            long res = 0;
            var childrenCnts = new int[n];
            while (stk.Count > 0)
            {
                int now = stk.Pop();
                int[] cnts = new int[65];
                for (int i = 0; i < graph[now].Count; i++)
                {
                    int to = (int)graph[now][i][0];
                    if (visited[to])
                    {
                        continue;
                    }

                    long div = 1;
                    long dist = graph[now][i][1];
                    int childs = childrenCnts[to] + 1;
                    res += dist;
                    res %= mask;
                    for (int j = 0; j < 65; j++)
                    {
                        if ((dist & div) > 0)
                        {
                            cnts[j] += (childs - costs[to, j]);
                            res += (childs - costs[to, j]) * div;
                        }
                        else
                        {
                            cnts[j] += costs[to, j];
                            res += costs[to, j] * div;
                        }
                        res %= mask;
                        div *= 2;
                    }
                    childrenCnts[now] += childs;
                }

                visited[now] = false;
            }
            */

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
