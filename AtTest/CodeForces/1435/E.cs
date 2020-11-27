using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1435
{
    class E
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
            int t = ReadInt();
            for (int i = 0; i < t; i++)
            {
                long[] abcd = ReadLongs();
                long a = abcd[0];
                long b = abcd[1];
                long c = abcd[2];
                long d = abcd[3];

                if (a > b * c)
                {
                    WriteLine(-1);
                    continue;
                }

                if (c <= d)
                {
                    WriteLine(a);
                    continue;
                }

                long x = a / (b * d);
                long x1 = x - 1;
                long x2 = x + 1;

                long res = 0;
                if (x >= 0)
                {
                    res = Max(a, a * (x + 1) - x * (x + 1) / 2*b*d);
                }
                if (x1 >= 0)
                {
                    res = Max(res, a * (x1 + 1) -  x1 * (x1 + 1) / 2 * b * d);
                }
                if (x2 >= 0)
                {
                    res = Max(res, a * (x2 + 1) -  x2 * (x2 + 1) / 2 * b * d);
                }
                WriteLine(res);
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
