﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_139
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
            int n = ReadInt();
            List<double[]> xyAngles = new List<double[]>();
            for (int i = 0; i < n; i++)
            {
                long[] xy = ReadLongs();
                xyAngles.Add(new double[3] { xy[0], xy[1], Atan2(xy[1], xy[0]) });
            }
            xyAngles = xyAngles.OrderBy(a => a[2]).ToList();
            for (int i = 0; i < n; i++)
            {
                xyAngles.Add(new double[3]
                { xyAngles[i][0], xyAngles[i][1], xyAngles[i][2] });
            }

            double res = 0;
            for (int i = 0; i < 2 * n; i++)
            {
                for (int j = i; j < Min(2 * n, i + n); j++)
                {
                    double x = 0;
                    double y = 0;
                    for (int k = i; k <= j; k++)
                    {
                        x += xyAngles[k][0];
                        y += xyAngles[k][1];
                    }
                    res = Max(res, Sqrt(x * x + y * y));
                }
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
