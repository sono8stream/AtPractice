using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_184
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
            long[] rc1 = ReadLongs();
            long[] rc2 = ReadLongs();

            if (rc1[0] == rc2[0] && rc1[1] == rc2[1])
            {
                WriteLine(0);
                return;
            }

            if (rc1[0] + rc1[1] == rc2[0] + rc2[1]
                || rc1[0] - rc1[1] == rc2[0] - rc2[1]
                || Abs(rc1[0] - rc2[0]) + Abs(rc1[1] - rc2[1]) <= 3)
            {
                WriteLine(1);
                return;
            }


            for (long rr = rc2[0] - 2; rr <= rc2[0] + 2; rr++)
            {
                for (long cc = rc2[1] - 2; cc <= rc2[1] + 2; cc++)
                {
                    if (rc1[0] + rc1[1] == rr + cc
                || rc1[0] - rc1[1] == rr - cc
                || Abs(rc1[0] - rr) + Abs(rc1[1] - cc) <= 3)
                    {
                        WriteLine(2);
                        return;
                    }
                }
            }

            if ((Abs(rc1[0] - rc2[0]) + Abs(rc1[1] - rc2[1])) % 2 == 0)
            {
                WriteLine(2);
                return;
            }

            WriteLine(3);
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
