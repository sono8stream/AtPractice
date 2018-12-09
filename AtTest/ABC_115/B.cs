using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_115
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var ps = new int[n];
            int res = 0;
            int max = int.MinValue;
            for(int i = 0; i < n; i++)
            {
                ps[i] = ReadInt();
                max = Math.Max(max, ps[i]);
                res += ps[i];
            }
            Console.WriteLine(res - max / 2);
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
