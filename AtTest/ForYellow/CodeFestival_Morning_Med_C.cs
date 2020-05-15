using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFestival_Morning_Med_C
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
            string[] pn = Read().Split();
            decimal p = decimal.Parse(pn[0]);
            long n = long.Parse(pn[1]);
            decimal val = 1;
            decimal tmp = 1 - 2 * p;
            long div = 1;
            while (div <= n)
            {
                if ((n/ div) % 2 == 1)
                {
                    val *= tmp;
                }
                div *= 2;
                tmp *= tmp;
            }
            WriteLine((1 - val) / 2);
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
        private static decimal[] ReadDecimals() { return Array.ConvertAll(Read().Split(), decimal.Parse); }
    }
}
