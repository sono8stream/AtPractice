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
            int[] childCnts = new int[n];
            for(int i = 0; i < n; i++)
            {
                childCnts[i] = -1;
            }
            DFS(childs, ref childCnts, root);
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(childCnts[i]);
            }
            for(int i = 0; i < n; i++)
            {

            }
        }

        static void DFS(List<int>[] childs, ref int[] childCnts, int index)
        {
            if (childCnts[index] != -1) return;

            if (childs[index].Count == 0)
            {
                childCnts[index] = 0;
                return;
            }
            int cnt = 0;
            for(int i = 0; i < childs[index].Count; i++)
            {
                DFS(childs, ref childCnts, childs[index][i]);
                cnt += childCnts[childs[index][i]] + 1;
            }
            childCnts[index] = cnt;
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
