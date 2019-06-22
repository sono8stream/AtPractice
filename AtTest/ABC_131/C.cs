using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_131
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] abcd = ReadLongs();
            long a = abcd[0];
            long b = abcd[1];
            long c = abcd[2];
            long d = abcd[3];

            long lcm = LCM(c, d);
            long res = b / c - (a - 1) / c;
            res += b / d - (a - 1) / d;
            res -= b / lcm - (a - 1) / lcm;
            WriteLine(b - a + 1 - res);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long LCM(long a, long b)
        {
            long c = GCD(a, b);
            return a * b / c;
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
