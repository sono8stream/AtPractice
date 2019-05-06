using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day1
{
    class H
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long nn = n;
            long val = 0;
            while (nn > 0)
            {
                val += nn % 10;
                nn /= 10;
            }
            long x = 0;
            long div = 1;
            while (val > 0)
            {
                if (val > 9)
                {
                    x += 9 * div;
                    val -= 9;
                }
                else
                {
                    x += val * div;
                    val = 0;
                }
                div *= 10;
            }
            if (x == n)
            {
                long div2 = 1;
                while ((x / div2) % 10 == 9)
                {
                    div2 *= 10;
                }
                if (div2 == 1) x += 9;
                else x += (div2 / 10) * 9;
            }
            WriteLine(x);
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
