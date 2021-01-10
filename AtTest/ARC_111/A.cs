using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_111
{
    class A
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
            long[] nm = ReadLongs();
            long n = nm[0];
            long m = nm[1];
            if (m == 1)
            {
                WriteLine(0);
                return;
            }

            long[] margins = new long[65];
            long m2 = m * m;
            margins[0] = 10 % m2;
            for (int i = 1; i < 65; i++)
            {
                margins[i] = margins[i - 1] * margins[i - 1];
                margins[i] %= m2;
            }
            long div = 1;
            long val = 1;
            for (int i = 0; i <= 60; i++)
            {
                if ((n & div) > 0)
                {
                    val *= margins[i];
                    val %= m2;
                }
                div *= 2;
            }


            WriteLine(val / m % m);
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
