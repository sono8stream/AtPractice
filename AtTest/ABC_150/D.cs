using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_150
{
    class D
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            long[] array = ReadLongs();
            long lcm = array[0];
            for (int i = 1; i < n; i++)
            {
                long gcd = GCD(lcm, array[i]);
                lcm *= array[i] / gcd;
                if (lcm / 2 > m)
                {
                    WriteLine(0);
                    return;
                }
            }
            if (lcm % 2 == 1)
            {
                WriteLine(0);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                long div = lcm / array[i];
                if (div % 2 == 0)
                {
                    WriteLine(0);
                    return;
                }
            }
            WriteLine((m - lcm / 2) / lcm + 1);
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
