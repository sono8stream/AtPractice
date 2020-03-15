using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Hitachi2020
{
    class B
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
            int[] abm = ReadInts();
            int a = abm[0];
            int b = abm[1];
            int m = abm[2];
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            int[][] xycs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                xycs[i] = ReadInts();
            }

            int res = int.MaxValue;
            for(int i = 0; i < m; i++)
            {
                int x = xycs[i][0] - 1;
                int y = xycs[i][1] - 1;
                int c = xycs[i][2];

                res = Min(res, aArray[x] + bArray[y] - c);
            }

            Array.Sort(aArray);
            Array.Sort(bArray);
            res = Min(res, aArray[0] + bArray[0]);
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
