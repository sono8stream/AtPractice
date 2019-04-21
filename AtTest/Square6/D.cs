using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Square6
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            double[][] xrs = new double[n][];
            for (int i = 0; i < n; i++)
            {
                xrs[i] = ReadDoubles();
            }
            xrs = xrs.OrderBy(a => a[0]).ToArray();

            double[] lefts = new double[n];
            lefts[0] = xrs[0][1];
            for (int i = 1; i < n; i++)
            {
                if (lefts[i - 1] - (xrs[i][0] - xrs[i - 1][0]) >= 0)
                {
                    lefts[i] = Pow(
                        Pow(lefts[i - 1] - (xrs[i][0] - xrs[i - 1][0]), 3)
                        + Pow(xrs[i][1], 3), 1.0 / 3);
                }
                else lefts[i] = xrs[i][1];
            }
            double[] rights = new double[n];
            rights[n - 1] = xrs[n - 1][1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (rights[i + 1] - (xrs[i + 1][0] - xrs[i][0]) >= 0)
                {
                    rights[i] = Pow(
                        Pow(rights[i + 1] - (xrs[i + 1][0] - xrs[i][0]), 3)
                        + Pow(xrs[i][1], 3), 1.0 / 3);
                }
                else rights[i] = xrs[i][1];
            }

            double res = xrs[0][1];
            for (int i = 0; i + 1 < n; i++)
            {
                double tmp = 0;
                if (lefts[i] < rights[i + 1])
                {
                    if (lefts[i] - (xrs[i + 1][0] - xrs[i][0]) >= 0)
                    {
                        tmp = Pow(
                            Pow(lefts[i] - (xrs[i + 1][0] - xrs[i][0]), 3)
                            + Pow(rights[i + 1], 3), 1.0 / 3);
                    }
                    else tmp = rights[i + 1];
                }
                else
                {
                    if (rights[i + 1] - (xrs[i + 1][0] - xrs[i][0]) >= 0)
                    {
                        tmp = Pow(Pow(lefts[i], 3)
                            + Pow(rights[i + 1] - (xrs[i + 1][0] - xrs[i][0]), 3),
                            1.0 / 3);
                    }
                    else tmp = lefts[i];
                }
                res = Max(res, tmp);
            }
            WriteLine(res);
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
