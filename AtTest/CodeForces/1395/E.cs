using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1395
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
            List<int[]>[] graph = new List<int[]>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int[]>();
            }

            for(int i = 0; i < m; i++)
            {
                int[] uvw = ReadInts();
                int u = uvw[0] - 1;
                int v = uvw[1] - 1;
                int w = uvw[2];
                graph[u].Add(new int[2] { v, w });
            }

            for(int i = 0; i < n; i++)
            {
                if (graph[i].Count == 0)
                {
                    WriteLine(0);
                    return;
                }
                graph[i] = graph[i].OrderBy(a => a[1]).ToList();
            }

            List<int>[] nodes = new List<int>[k];
            for(int i = 0; i < k; i++)
            {
                nodes[i] = new List<int>();
            }
            for(int i = 0; i < n; i++)
            {
                nodes[graph[i].Count - 1].Add(i);
            }

            bool[,,,] can = new bool[k, k, k, k];
            for(int i = 0; i < k; i++)
            {
                int[] cnts = new int[n];
                for(int j = 1; j < k; j++)
                {
                    for(int ii = 0; ii <= i; ii++)
                    {
                        bool ok = true;
                        for(int iX = 0; iX < nodes[i].Count;iX++)
                        {
                            int now = nodes[i][iX];
                            cnts[graph[now][ii][0]]++;
                            if (cnts[graph[now][ii][0]] > 1)
                            {
                                ok = false;
                            }
                        }
                        if (ok)
                        {
                            for (int jj = 0; jj <= j; jj++)
                            {
                                bool ok2 = true;
                                for (int jX = 0; jX < nodes[j].Count; jX++)
                                {
                                    int now = nodes[j][jX];
                                    cnts[graph[now][jj][0]]++;
                                    if (cnts[graph[now][jj][0]] > 1)
                                    {
                                        ok2 = false;
                                    }
                                }
                                if (ok2)
                                {
                                    can[i, ii, j, jj] = true;
                                }
                                for (int jX = 0; jX < nodes[j].Count; jX++)
                                {
                                    int now = nodes[j][jX];
                                    cnts[graph[now][jj][0]]--;
                                }
                            }
                        }
                        for (int iX = 0; iX < nodes[i].Count;iX++)
                        {
                            int now = nodes[i][iX];
                            cnts[graph[now][ii][0]]--;
                        }
                    }
                }
            }

            int all = 1;
            for(int i = 0; i < k; i++)
            {
                all *= (i + 1);
            }

            int res = 0;
            for(int i = 0; i < all; i++)
            {
                int[] state = new int[k];
                int tmp = i;
                for(int j = 0; j < k; j++)
                {
                    state[k - 1 - j] = tmp % (k - j);
                    tmp /= (k - j);
                }

                bool ok = true;
                for(int j = 0; j < k; j++)
                {
                    for(int l = j + 1; l < k; l++)
                    {
                        if (!can[j, state[j], l, state[l]])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        break;
                    }
                }

                if (ok)
                {
                    res++;
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
