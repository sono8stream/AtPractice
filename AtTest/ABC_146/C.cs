using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_146
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
            long[] abx = ReadLongs();
            long a = abx[0];
            long b = abx[1];
            long x = abx[2];
            long bottom = 0;
            long top = 1000000000 + 1;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                long cost = a * mid;
                long dig = 0;
                long tmp = mid;
                while (tmp > 0)
                {
                    dig++;
                    tmp /= 10;
                }
                cost += b * dig;
                if (cost <= x) bottom = mid;
                else top = mid;
            }
            WriteLine(bottom);
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
