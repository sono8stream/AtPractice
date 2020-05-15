using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2014_QualA_C
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

            string[] ps = new string[n];
            for(int i = 0; i < n; i++)
            {
                ps[i] = Read();
            }

            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                for(int j = i + 1; j < n; j++)
                {
                    bool ok = true;
                    for(int k = 0; k < m; k++)
                    {
                        if (ps[i][k] == '*'
                            || ps[j][k] == '*'
                            || ps[i][k] == ps[j][k])
                        {
                            continue;
                        }

                        ok = false;
                        break;
                    }

                    if (!ok)
                    {
                        graph[i].Add(j);
                        graph[j].Add(i);
                    }
                }
            }

            int[] ranks = new int[n];
            for(int i = 0; i < n; i++)
            {
                ranks[i] = 100;
            }
            ranks[0] = 0;
            int pat = 1;
            for (int i = 0; i < n; i++)
            {
                if (ranks[i] < 100)
                {
                    continue;
                }

                Queue<int> que = new Queue<int>();
                que.Enqueue(i);
                while (que.Count > 0)
                {
                    int idx = que.Dequeue();
                    if (ranks[idx] < 100)
                    {
                        continue;
                    }

                    bool[] joined = new bool[pat];
                    for (int j = 0; j < graph[idx].Count; j++)
                    {
                        int to = graph[idx][j];
                        if (ranks[to] < 100)
                        {
                            joined[ranks[to]] = false;
                        }
                        else
                        {
                            que.Enqueue(to);
                        }
                    }
                    int rank = pat;
                    for(int j = 0; j < pat; j++)
                    {
                        if (joined[j])
                        {
                            rank = j;
                            break;
                        }
                    }

                    ranks[idx] = rank;
                }
            }

            WriteLine(ranks.Max() + 1);
        }

        static void DFS(int now,bool[,] addables,ref int[] state,int pat,ref int res)
        {
            if (now == state.Length)
            {
                res = Min(res, pat);
                return;
            }

            for(int i = 0; i < pat; i++)
            {
                bool ok = true;
                for (int j = 0; j < now; j++)
                {
                    if (state[j] == i)
                    {
                        if (addables[j, now])
                        {
                            continue;
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    state[now] = i;
                    DFS(now + 1, addables, ref state, pat, ref res);
                }
            }

            state[now] = pat;
            DFS(now + 1, addables, ref state, pat + 1, ref res);
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
