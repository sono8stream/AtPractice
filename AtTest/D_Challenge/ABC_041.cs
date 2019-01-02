using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_041
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var bDict = new Dictionary<int, bool>[nm[0]];
            var eDict = new Dictionary<int,bool>[nm[0]];
            for(int i = 0; i < nm[0]; i++)
            {
                bDict[i] = new Dictionary<int, bool>();
                eDict[i] = new Dictionary<int, bool>();
            }
            var xys = new int[nm[1]][];
            for(int i = 0; i < nm[1]; i++)
            {
                xys[i] = ReadInts();
                int x = xys[i][0] - 1;
                int y = xys[i][1] - 1;
                if (x < y) bDict[y].Add(x,true);
                if (x > y) eDict[x].Add(y,true);
            }
            var first = new List<int>();
            first.Add(0);
            Console.WriteLine(DFS(first, bDict, eDict));
        }

        static long DFS(List<int> order,
            Dictionary<int, bool>[] bDict, Dictionary<int, bool>[] eDict)
        {
            int now = order.Count;

            List<int> poses = new List<int>();
            int bCnt = 0;
            for (int i = 0; i <= order.Count; i++)
            {
                if (bCnt == bDict[now].Count) poses.Add(i);
                if (i < order.Count)
                {
                    if (bDict[now].ContainsKey(order[i])) bCnt++;
                    if (eDict[now].ContainsKey(order[i])) break;
                }
            }

            if (now == bDict.Length - 1)
            {
                return poses.Count;
            }
            else
            {
                long cnt = 0;
                for (int i = 0; i < poses.Count; i++)
                {
                    order.Insert(poses[i], now);
                    cnt += DFS(order, bDict, eDict);
                    order.RemoveAt(poses[i]);
                }
                return cnt;
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
