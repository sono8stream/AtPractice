using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeForces._535
{
    class E2
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] array = ReadInts();
            int[][] sub = new int[n][];
            for(int i = 0; i < n; i++)
            {
                sub[i] = new int[2] { array[i], i };
            }
            Array.Sort(sub,(a,b)=>a[0]-b[0]);
            Array.Reverse(sub);
            int[][] lrs = new int[m][];
            for (int i = 0; i < m; i++)
            {
                lrs[i] = ReadInts();
            }
            int margin = 0;
            var list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int now = array[i];
                int[][] maxs = new int[m][];
                for (int j = 0; j < m; j++)
                {
                    maxs[j] = new int[2] { sub[j][0], sub[j][1] };
                }
                var tempList = new List<int>();
                for (int j = 0; j < m; j++)
                {
                    int l = lrs[j][0] - 1;
                    int r = lrs[j][1] - 1;
                    if (i < l || i > r) continue;
                    tempList.Add(j + 1);
                    for (int k = 0; k < m; k++)
                    {
                        if (maxs[k][1] >= l && maxs[k][1] <= r) maxs[k][0]--;
                    }
                    now--;
                }
                Array.Sort(maxs,(a,b)=>a[0]-b[0]);
                int delta = m == 0 ? sub[0][0]-sub[n-1][0] : maxs[m - 1][0] - now;
                if (delta > margin)
                {
                    margin = delta;
                    list = tempList;
                }
            }
            Console.WriteLine(margin);
            Console.WriteLine(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
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
