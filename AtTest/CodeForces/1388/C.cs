using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1388
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
            for (int i = 0; i< t; i++)
            {
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                int[] ps = ReadInts();
                int[] hs = ReadInts();
                List<int>[] graph = new List<int>[n];
                for(int j = 0; j < n; j++)
                {
                    graph[j] = new List<int>();
                }
                for(int j = 0; j < n-1; j++)
                {
                    int[] lr = ReadInts();
                    int l = lr[0] - 1;
                    int r = lr[1] - 1;
                    graph[l].Add(r);
                    graph[r].Add(l);
                }

                int[] childs = new int[n];
                DFS(graph,ps, childs, 0, -1);

                Queue<int[]> que = new Queue<int[]>();
                que.Enqueue(new int[4] { 0, -1, m,0 });
                Stack<int> stk = new Stack<int>();
                int[] parents = new int[n];
                while (que.Count > 0)
                {
                    int[] vals = que.Dequeue();
                    int now = vals[0];
                    int par = vals[1];
                    stk.Push(now);
                    parents[now] = par;
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (par == to)
                        {
                            continue;
                        }

                        que.Enqueue(new int[2] { to, now });
                    }
                    /*
                    int pluses = now[2];
                    int minuses = now[3];
                    int score = pluses - minuses;
                    if (score < hs[idx] || score % 2 != hs[idx] % 2)
                    {
                        can = false;
                        break;
                    }

                    pluses -= (score - hs[idx]) / 2;
                    minuses += (score - hs[idx]) / 2;
                    if (minuses >= ps[idx])
                    {
                        minuses -= ps[idx];
                    }
                    else
                    {
                        pluses -= ps[idx] - minuses;
                        minuses = 0;
                    }
                    */

                }

                bool can = true;
                int[][] cnts = new int[n][];
                while (stk.Count > 0)
                {
                    int now = stk.Pop();
                    int pluses = 0;
                    int minuses = ps[now];
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        int to = graph[now][j];
                        if (to == parents[now])
                        {
                            continue;
                        }

                        pluses += cnts[to][0];
                        minuses += cnts[to][1];
                    }

                    int min = pluses - minuses;
                    int max = pluses + minuses;
                    if (hs[now] < min || hs[now] > max || Abs(hs[now]) % 2 != max % 2)
                    {
                        can = false;
                        break;
                    }

                    minuses = (max - hs[now]) / 2;
                    pluses = max - minuses;
                    cnts[now] = new int[2] { pluses, minuses };
                }

                WriteLine(can ? "YES" : "NO");
            }
        }

        static void DFS(List<int>[] graph,int[] ps, int[] childs,int now,int par)
        {
            if (graph[now].Count == 1 && par != -1)
            {
                childs[now] = ps[now];
                return;
            }

            int cnt = ps[now];
            for(int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];
                if (to == par)
                {
                    continue;
                }

                DFS(graph, ps, childs, to, now);
                cnt += childs[to];
            }
            childs[now] = cnt;
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
