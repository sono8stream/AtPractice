using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2016B_C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] wh = ReadInts();
            long w = wh[0];
            long h = wh[1];
            long[] ps = new long[w];
            long[] qs = new long[h];
            for (int i = 0; i < w; i++) ps[i] = ReadLong();
            for (int i = 0; i < h; i++) qs[i] = ReadLong();
            Array.Sort(ps);
            Array.Sort(qs);
            long[] pSums = new long[w];
            for (int i = 0; i < w; i++)
            {
                pSums[i] = ps[i];
                if (i > 0) pSums[i] += pSums[i - 1];
            }
            long res = pSums[w - 1];
            long now = w - 1;
            for(long i = h - 1; i >= 0; i--)
            {
                //WriteLine(res);
                while (now >= 0 && ps[now] >= qs[i]) now--;
                if (now >= 0) res += pSums[now];
                res += qs[i] * (w - now);
                //WriteLine(now);
            }
            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
