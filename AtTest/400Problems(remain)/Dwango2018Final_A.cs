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
            int h = hms[0] % 12;
            int m = hms[1];
            int s = hms[2];
            int[] cs = ReadInts();
            int c1 = cs[0];
            int c2 = cs[1];
            int t1 = -1;
            int t2 = -1;
            int c1Cnt = 0;
            int c2Cnt = 0;
            bool c1OK = false;
            bool c2OK = c2 == 0;
            bool sBehind = s <= m;
            bool mBehind = 660 * m + 11 * s <= 3600 * h;
            for(int i =1; i < 650000; i++)
            {
                s++;
                if (s == 60)
                {
                    s = 0;
                    m++;
                    if (m == 60)
                    {
                        m = 0;
                        h++;
                        if (h == 12) h = 0;
                    }
                }
                if (s <= m)
                {
                    sBehind = true;
                }
                else
                {
                    if (sBehind)
                    {
                        c1Cnt++;
                        if (c1Cnt == c1)
                        {
                            c1OK = true;
                        }
                        if (c1 < c1Cnt)
                        {
                            break;
                        }
                        sBehind = false;
                    }
                }
                if(660 * m + 11 * s <= 3600 * h)
                {
                    mBehind = true;
                }
                else
                {
                    if (mBehind)
                    {
                        c2Cnt++;
                        if (c2Cnt == c2)
                        {
                            c2OK = true;
                        }
                        if (c2 < c2Cnt)
                        {
                            break;
                        }
                        mBehind = false;
                    }
                }
                if (c1OK && c2OK)
                {
                    if (t1 == -1) t1 = i;
                    if (!(s == 0 && m == 0 && h == 0)) t2 = i;
                }
                //Console.WriteLine(c1Cnt + " " + c2Cnt);
            }
            if (t1 == -1) Console.WriteLine(-1);
            else Console.WriteLine(t1 + " " + t2);
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
