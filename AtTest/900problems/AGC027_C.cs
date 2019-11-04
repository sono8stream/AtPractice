using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._900problems
{
    class AGC027_C
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
            string s = Read();
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            bool[] isLoop = new bool[n];
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }
            int cnt = 0;
            bool[] removed = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (removed[i]) continue;

                Queue<int> que = new Queue<int>();
                que.Enqueue(i);
                while (que.Count > 0)
                {
                    int now = que.Dequeue();
                    if (removed[now]) continue;
                    bool a = false;
                    bool b = false;
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        if (removed[graph[now][j]]) continue;
                        if (s[graph[now][j]] == 'A') a = true;
                        if (s[graph[now][j]] == 'B') b = true;
                    }
                    if (a && b) continue;

                    removed[now] = true;
                    cnt++;
                    for(int j = 0; j < graph[now].Count; j++)
                    {
                        if (removed[graph[now][j]]) continue;
                        que.Enqueue(graph[now][j]);
                    }
                }
            }
            if (cnt == n) WriteLine("No");
            else WriteLine("Yes");
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
