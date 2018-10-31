using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_049
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nkl = ReadInts();
            var unionP = new int[nkl[0]];
            var unionPrank = new int[nkl[0]];
            var unionR = new int[nkl[0]];
            var unionRrank = new int[nkl[0]];
            for (int i = 0; i < nkl[0]; i++)
            {
                unionP[i] = i;
                unionPrank[i] = 1;

                unionR[i] = i;
                unionRrank[i] = 1;
            }
            for (int i = 0; i < nkl[1]; i++)
            {
                int[] pq = ReadInts();
                Array.Sort(pq);
                Unite(ref unionP, ref unionPrank, pq[0] - 1, pq[1] - 1);
            }
            for (int i = 0; i < nkl[2]; i++)
            {
                int[] rs = ReadInts();
                Array.Sort(rs);
                Unite(ref unionR, ref unionRrank, rs[0] - 1, rs[1] - 1);
            }
            var groupDict = new Dictionary<int, Dictionary<int, int>>();
            for(int i = 0; i < nkl[0]; i++)
            {
                int p = Root(ref unionP, i);
                int r = Root(ref unionR, i);
                if (!groupDict.ContainsKey(p))
                {
                    groupDict.Add(p, new Dictionary<int, int>());
                }

                if (!groupDict[p].ContainsKey(r))
                {
                    groupDict[p].Add(r, 1);
                }
                else
                {
                    groupDict[p][r]++;
                }
            }

            for (int i = 0; i < nkl[0]; i++)
            {
                //Console.WriteLine(unionP[i] + " " + unionR[i]);
                Console.Write(groupDict[unionP[i]][unionR[i]] + " ");
            }
        }

        static int Root(ref int[] tree, int x)
        {
            int rx = x;
            while (tree[rx] != rx)
            {
                rx = tree[rx];
            }
            tree[x] = rx;
            return rx;
        }

        static bool IsSame(ref int[] tree, int x, int y)
        {
            return Root(ref tree, x)
                == Root(ref tree, y);
        }

        static void Unite(ref int[] tree, ref int[] rank,
            int x, int y)
        {
            int rx = Root(ref tree, x);
            int ry = Root(ref tree, y);
            if (rx == ry) return;
            if (rank[rx] < rank[ry])
            {
                int temp = rx;
                rx = ry;
                ry = temp;
            }
            if (rank[rx] == rank[ry])
            {
                rank[rx]++;
            }
            tree[ry] = rx;
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
