using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day2
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] xy = ReadInts();
            int[] ab = ReadInts();
            int[] sxy = ReadInts();
            int[] txy = ReadInts();
            long x1 = 0;
            long y1 = ab[0];
            long x2 = xy[0];
            long y2 = ab[1];
            long x3 = sxy[0];
            long y3 = sxy[1];
            long x4 = txy[0];
            long y4 = txy[1];

            bool cross = ((x1 - x2) * (y3 - y1) + (y1 - y2) * (x1 - x3))
                * ((x1 - x2) * (y4 - y1) + (y1 - y2) * (x1 - x4)) <= 0;

            WriteLine(cross ? "Yes" : "No");
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
