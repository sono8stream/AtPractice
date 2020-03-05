using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class SoundHound2018_Summer_Qual_E
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
            Dictionary<int,int>[] graph = new Dictionary<int,int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new Dictionary<int, int>();
            }
            for (int i = 0; i < m; i++)
            {
                int[] uvs = ReadInts();
                int u = uvs[0] - 1;
                int v = uvs[1] - 1;
                int s = uvs[2];
                graph[u].Add( v, s );
                graph[v].Add( u, s );
            }

            int?[][] conds = new int?[n][];
            for (int i = 0; i < n; i++)
            {
                conds[i] = new int?[2];
            }
            Queue<int[]> que = new Queue<int[]>();
            que.Enqueue(new int[3] { 0, 0, 1 });
            int min = 1;
            int max = int.MaxValue;
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int index = val[0];
                int num = val[1];
                int next = val[2] == 1 ? 0 : 1;

                foreach (int to in graph[index].Keys)
                {
                    int s = graph[index][to];
                    if (conds[to][next] == null)
                    {
                        conds[to][next] = s - num;
                    }
                    else
                    {
                        if (conds[to][next] != s - num)
                        {
                            WriteLine(0);
                            return;
                        }
                    }
                    if (conds[to][0] != null && conds[to][1] != null)
                    {
                        int target = (int)(conds[to][0] - conds[to][1]);
                        if (target > 0 && target % 2 == 0)
                        {
                            target /= 2;
                            min = Max(min, target);
                            max = Min(max, target);
                        }
                        else
                        {
                            WriteLine(0);
                            return;
                        }
                    }
                    if (conds[to][0] != null)
                    {
                        max = Min(max, (int)conds[to][0] - 1);
                    }
                    if (conds[to][1] != null)
                    {
                        min = Max(min, -(int)conds[to][1] + 1);
                    }
                    if (max < min)
                    {
                        WriteLine(0);
                        return;
                    }
                    que.Enqueue(new int[3] { to, (int)conds[to][next], next });
                    graph[to].Remove(index);
                }
                graph[index].Clear();
            }

            WriteLine(max - min + 1);
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
