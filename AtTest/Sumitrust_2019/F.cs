using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Sumitrust_2019
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
            int[] t12 = ReadInts();
            int t1 = t12[0];
            int t2 = t12[1];
            long[] a12 = ReadLongs();
            long a1 = a12[0];
            long a2 = a12[1];
            long[] b12 = ReadLongs();
            long b1 = b12[0];
            long b2 = b12[1];
            long delta1 = (a1 - b1) * t1;
            long delta2 = delta1 + (a2 - b2) * t2;
            if (delta2 == 0)
            {
                WriteLine("infinity");
            }
            else if ((delta1 < 0 && delta2 > 0)
                || (delta1 > 0 && delta2 < 0))
            {
                long res = 1;
                if (-delta1 % delta2 == 0)
                {
                    res += -delta1 / delta2 * 2 - 1;
                }
                else
                {
                    res += -delta1 / delta2 * 2;
                }
                WriteLine(res);
            }
            else
            {
                WriteLine(0);
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
