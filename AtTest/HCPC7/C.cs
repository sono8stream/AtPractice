using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC7
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[][] xws = new long[n][];
            for (int i = 0; i < n; i++)
            {
                xws[i] = ReadLongs();
            }
            double bottom = long.MinValue / 2;
            double top = long.MaxValue / 2;
            double thres = 0.000000001;
            while (bottom + thres <= top)
            {
                double mid = (bottom + top) / 2;
                bool bottomD = false;
                double bottomMax = 0;
                bool midD = false;
                double midMax = 0;
                bool topD = false;
                double topMax = 0;
                for (int i = 0; i < n; i++)
                {
                    double bottomVal = (xws[i][0] - bottom) * xws[i][1];
                    if (Abs(bottomVal) > bottomMax)
                    {
                        bottomMax = Abs(bottomVal);
                        bottomD = bottomVal > 0;
                    }
                    double midVal = (xws[i][0] - mid) * xws[i][1];
                    if (Abs(midVal) > midMax)
                    {
                        midMax = Abs(midVal);
                        midD = midVal > 0;
                    }
                    double topVal = (xws[i][0] - top) * xws[i][1];
                    if (Abs(topVal) > topMax)
                    {
                        topMax = Abs(topVal);
                        topD = topVal > 0;
                    }
                }
                if (bottomD == midD)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            WriteLine(bottom);
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
