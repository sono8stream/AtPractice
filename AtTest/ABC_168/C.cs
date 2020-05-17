using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_168
{
    class C
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
            int[] abhm = ReadInts();
            int a = abhm[0];
            int b = abhm[1];
            int h = abhm[2];
            int m = abhm[3];
            double x1 = a * Cos(PI / 2 - 2 * PI * h / 12 - PI / 6 * m / 60);
            double y1 = a * Sin(PI / 2 - 2 * PI * h / 12 - PI / 6 * m / 60);
            double x2 = b * Cos(PI / 2 - 2 * PI * m / 60);
            double y2 = b * Sin(PI / 2 - 2 * PI * m / 60);

            WriteLine(Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
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
