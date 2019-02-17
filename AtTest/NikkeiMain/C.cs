using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.NikkeiMain
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hwk = ReadInts();
            long h = hwk[0];
            long w = hwk[1];
            long k = hwk[2];
            long[] rCnts = new long[h];
            long[] cCnts = new long[w];
            for(int i = 0; i < h; i++)
            {
                rCnts[i] = w;
            }
            for(int i = 0; i < w; i++)
            {
                cCnts[i] = h;
            }
            for(int i = 0; i < k; i++)
            {
                int[] rc = ReadInts();
                int r = rc[0] - 1;
                int c = rc[1] - 1;
                rCnts[r]--;
                cCnts[c]--;
            }
            long center = (h * w - k) / 2;
            int y = 0;
            long sum = 0;
            for(int i = 0; i < h; i++)
            {
                sum += rCnts[i];
                if (center < sum)
                {
                    y = i;
                    break;
                }
            }
            int x = 0;
            sum = 0;
            for(int i = 0; i < w; i++)
            {
                sum += cCnts[i];
                if (center < sum)
                {
                    x = i;
                    break;
                }
            }
            long[] ys = new long[3] { y, y - 1, y + 1 };
            long[] xs = new long[3] { x, x - 1, x + 1 };
            long res = long.MaxValue;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    long tmp = 0;
                    for (long p = 0; p < h; p++)
                    {
                        tmp += rCnts[p] * Math.Abs(ys[i] - p);
                    }
                    for(long p = 0; p < w; p++)
                    {
                        tmp += cCnts[p] * Math.Abs(xs[j] - p);
                    }
                    res = Math.Min(res, tmp);
                }
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
