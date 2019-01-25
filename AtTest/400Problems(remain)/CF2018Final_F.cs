using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CF2018Final_F
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            int[] ps = ReadInts();
            var childs = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                childs[i] = new List<int>();
            }
            int root = 0;
            for (int i = 0; i < n; i++)
            {
                int parent = ps[i] - 1;
                if (parent < 0) root = i;
                else childs[parent].Add(i);
            }
            int[] rank = new int[n];
            bool[] visit = new bool[n];
            NestDFS(childs, ref rank, root, 1);
            int remain = DFS(childs, rank, visit, root);
            int[] res = new int[m];
            for (int i = 0; i < m; i++)
            {
                bool canPut = false;
                for (int j = 0; j < n; j++)
                {
                    if (visit[j]) continue;
                    int count = DFS(childs, rank, visit, j);
                    if ((i < m - 1 && remain - count >= k - rank[j])
                        || (i == m - 1 && rank[j] == k))
                    {
                        visit[j] = true;
                        canPut = true;
                        res[i] = j + 1;
                        remain -= count;
                        k -= rank[j];
                        //Console.WriteLine(res[i]);
                        break;
                    }
                }
                if (!canPut)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            for(int i = 0; i < m; i++)
            {
                Console.Write(res[i] + " ");
            }
        }

        static void NestDFS(List<int>[] childs, ref int[] rank,
            int now, int nowRank)
        {
            rank[now] = nowRank;
            for(int i = 0; i < childs[now].Count; i++)
            {
                NestDFS(childs, ref rank, childs[now][i], nowRank + 1);
            }
        }

        static int DFS(List<int>[] childs,int[] rank,bool[] visit, int now)
        {
            if (visit[now]) return 0;
            int res = rank[now];
            for(int i = 0; i < childs[now].Count; i++)
            {
                res += DFS(childs, rank, visit, childs[now][i]);
            }
            return res;
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
