using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Disco2017_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nc = ReadInts();
            int n = nc[0];
            int c = nc[1];
            var list = new List<int>();
            for(int i = 0; i < n; i++)
            {
                list.Add(ReadInt());
            }
            list.Sort();
            list.Reverse();
            int res = 0;
            while (list.Count > 0)
            {
                if (list.Count > 1
                    && list[0] + list[list.Count - 1] < c)
                {
                    list.RemoveAt(list.Count - 1);
                }
                list.RemoveAt(0);
                res++;
            }
            Console.WriteLine(res);
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
