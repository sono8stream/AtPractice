using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_157
{
    class F
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            double[][] xycs = new double[n][];
            for(int i = 0; i < n; i++)
            {
                xycs[i] = ReadDoubles();
            }
            double bottom = 0;
            double top = 10000;
            double thres = 0.0000001;
            while (bottom + thres < top)
            {
                double mid = (bottom + top) / 2;

                List<double[]> poses = new List<double[]>();
                for(int i = 0; i < n; i++)
                {
                    double x1 = xycs[i][0];
                    double y1 = xycs[i][1];
                    double r1 = mid / xycs[i][2];
                    poses.Add(new double[2] { xycs[i][0], xycs[i][1] });
                    for(int j = i + 1; j < n; j++)
                    {
                        double x2 = xycs[j][0];
                        double y2 = xycs[j][1];
                        double r2 = mid / xycs[j][2];
                        double dist = Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
                        if (dist > Abs(r1 - r2) && dist < r1 + r2)
                        {

                        }
                    }
                }
            }
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
