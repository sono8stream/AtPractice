using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2016FinalB
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            double[][] xys = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                xys[i] = ReadDoubles();
            }
            double[] ls = new double[3];
            for(int i = 0; i < 3; i++)
            {
                double x1 = xys[i][0];
                double y1 = xys[i][1];
                double x2 = xys[(i+1)%3][0];
                double y2 = xys[(i+1)%3][1];
                ls[i] = Sqrt(Pow(x1 - x2, 2) + Pow(y1 - y2, 2));
            }
            double[] tans = new double[3];
            for (int i = 0; i < 3; i++)
            {
                double a = ls[(i + 2) % 3];
                double b = ls[i % 3];
                double c = ls[(i + 1) % 3];
                tans[i] = Sqrt(4 * a * b / ((a + b) * (a + b) - c * c) - 1);
            }
            double res = 0;
            for(int i = 0; i < 3; i++)
            {
                res = Max(res, ls[i] / (1 / tans[i] + 2 + 1 / tans[(i + 1) % 3]));
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
