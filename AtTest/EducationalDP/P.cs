using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class P
    {
        static long mask = 1000000000 + 7;

        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] xy = ReadInts();
                int x = xy[0] - 1;
                int y = xy[1] - 1;
                graph[x].Add(y);
                graph[y].Add(x);
            }
            long[,] dp = new long[n, 2];//j=0:white,j=1:black
            bool[] visit = new bool[n];
            DFS(ref dp,ref visit, graph, 0);
            Console.WriteLine((dp[0, 0] + dp[0, 1]) % mask);
        }

        static void DFS(ref long[,] dp,ref bool[] visit,
            List<int>[] graph, int now)
        {
            visit[now] = true;            
            dp[now, 0] = 1;
            dp[now, 1] = 1;

            for (int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];
                if (visit[to]) continue;

                DFS(ref dp,ref visit, graph, to);
                dp[now, 0] *= dp[to, 0] + dp[to, 1];
                dp[now, 0] %= mask;
                dp[now, 1] *= dp[to, 0];
                dp[now, 1] %= mask;
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
