using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class Dwango2018Final_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hms = ReadInts();
            int h = hms[0];
            int m = hms[1];
            int s = hms[2];
            int[] cs = ReadInts();
            int c1 = cs[0];
            int c2 = cs[1];
            int t1 = 0;
            int t2 = 0;
            if (c1 == 0)
            {
                if (c2 > 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                t2 = s <= m ? m - s : 60 + m - s + 1;
            }
            else
            {
                if (s <= m)
                {
                    t1 = m - s + 1;

                }
                else
                {
                    t1= 60 + m - s + 2;
                }
                t1 += 61 * (c1 - 1);
            }
            Console.WriteLine(t1 + " " + t2);
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
