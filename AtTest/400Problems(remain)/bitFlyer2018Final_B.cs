using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class bitFlyer2018Final_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            long[] xArray = ReadLongs();
            long[][] qs = new long[q][];
            for (int i = 0; i < q; i++)
            {
                qs[i] = ReadLongs();
            }
            long[] sums = new long[n];
            sums[0] = xArray[0];
            for (int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + xArray[i];
            }
            for (int i = 0; i < q; i++)
            {
                long res = 0;
                int bottom = 0;
                int top = n;
                while (bottom + 1 < top)
                {
                    int x = (bottom + top) / 2;
                    if (xArray[x] < qs[i][0] - qs[i][1])
                    {
                        bottom = x;
                    }
                    else
                    {
                        top = x;
                    }
                }
                int l = bottom;
                if (l == 0 && xArray[0] >= qs[i][0] - qs[i][1])
                    l = -1;
                res += qs[i][1] * (l + 1);
                bottom = 0;
                top = n;
                while (bottom + 1 < top)
                {
                    int x = (bottom + top) / 2;
                    if (xArray[x] <= qs[i][0])
                    {
                        bottom = x;
                    }
                    else
                    {
                        top = x;
                    }
                }
                int center = bottom;
                if (center == 0 && xArray[0] > qs[i][0])
                    center = -1;
                res += qs[i][0] * (center - l);
                if (center >= 0) res -= sums[center];
                if (l >= 0) res += sums[l];

                bottom = 0;
                top = n;
                while (bottom + 1 < top)
                {
                    int x = (bottom + top) / 2;
                    if (xArray[x] <= qs[i][0] + qs[i][1])
                    {
                        bottom = x;
                    }
                    else
                    {
                        top = x;
                    }
                }
                int r = bottom;
                if (r == 0 && xArray[0] > qs[i][0] + qs[i][1]) r = -1;
                if (r >= 0) res += sums[r];
                if (center >= 0) res -= sums[center];
                res -= qs[i][0] * (r - center);
                res += (n - r - 1) * qs[i][1];
                Console.WriteLine(res);
                //Console.WriteLine(l + " " + center + " " + r);
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
