using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class MPC2018_D
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
            for(int x = 1; x <= n; x++)
            {
                for(int y = 1; y <= m; y++)
                {

                }
            }
        }

        static int Reverse(int x)
        {
            if (x < 10) return x;
            else if (x < 100) return x / 10 + x % 10 * 10;
            else return x / 100 + (x % 100) / 10 * 10 + (x % 10) * 100;
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
