using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_106
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
            long n = ReadLong();
            if (n < 8)
            {
                WriteLine(-1);
                return;
            }

            long fives = 5;
            int fiveCnt = 1;
            while (fives * 5 <= n - 3)
            {
                fives *= 5;
                fiveCnt++;
            }

            long threes = 3;
            int threeCnt = 1;
            while (fives > 1)
            {
                long other = n - fives;
                while (threes * 3 <= other)
                {
                    threes *= 3;
                    threeCnt++;
                }

                if (fives + threes == n)
                {
                    WriteLine(threeCnt + " " + fiveCnt);
                    return;
                }

                fives /= 5;
                fiveCnt--;
            }

            WriteLine(-1);
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
