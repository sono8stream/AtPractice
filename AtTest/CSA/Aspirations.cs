using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CSA
{
    class Aspirations
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] lrd = ReadInts();
            int l = lrd[0];
            int r = lrd[1];
            int d = lrd[2];
            int min = l / d;
            if (l % d > 0) min++;
            int max = r / d;
            if (max < min || (min == max && min>1))
            {
                WriteLine("impossible");
                return;
            }
            else
            {
                WriteLine(max - min + 1);
                for (int i = min; i <= max; i++)
                {
                    Write(d * i + " ");
                }
                WriteLine();
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
