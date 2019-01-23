using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeForces._535
{
    class E
    {
        static void ain(string[] args)
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
            int[][] lrs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                lrs[i] = ReadInts();
            }
            int margin = 0;
            var list = new List<int>();
            for(int i = 0; i < n; i++)
            {
                int[] temp = new int[n];
                for(int j = 0; j < n; j++)
                {
                    temp[j] = array[j];
                }
                var tempList = new List<int>();
                for(int j = 0; j < m; j++)
                {
                    int l = lrs[j][0] - 1;
                    int r = lrs[j][1] - 1;
                    if (i < l || i > r) continue;
                    tempList.Add(j + 1);
                    for (int k = l; k <= r; k++)
                    {
                        temp[k]--;
                    }
                }
                Array.Sort(temp);
                int delta = temp[n - 1] - temp[0];
                if (delta > margin)
                {
                    margin = delta;
                    list = tempList;
                }
            }
            Console.WriteLine(margin);
            Console.WriteLine(list.Count);
            for(int i = 0; i < list.Count; i++)
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
