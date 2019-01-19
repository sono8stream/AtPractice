using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Disco2016_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] rc = ReadInts();
            int r = rc[0];
            int c = rc[1];
            int rSq = r * r;
            int cSq = c * c;
            int cnt = 0;
            int max = r / c;
            for (int i = 1; i <= max; i++)
            {
                int lSq = rSq - cSq * i * i;
                cnt += (int)Math.Sqrt(lSq / cSq);
            }
            Console.WriteLine(cnt * 4);
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
