using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class CF2016_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int bottom = 1;
            int top = n + 1;
            while (bottom + 1 < top)
            {
                long x = (bottom + top) / 2;

                if (n > x * (x + 1) / 2)
                {
                    bottom = (int)x;
                }
                else
                {
                    top = (int)x;
                }
            }
            bottom++;
            for(int i = bottom; i > 0; i--)
            {
                if (n >= i)
                {
                    Console.WriteLine(i);
                    n -= i;
                }
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
