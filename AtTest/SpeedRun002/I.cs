using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.SpeedRun002
{
    class I
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[][] abs = new long[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadLongs();
                abs[i] = new long[3] { abs[i][0], abs[i][1], i };
            }
            abs = abs.OrderBy(a => -a[0] * a[1]).ToArray();

            for(int i = 1; i < n; i++)
            {
                long x = (long)Ceiling(1.0 * abs[i][0] / abs[0][1]);
                if (abs[0][0] - abs[i][1] * x <= 0)
                {
                    WriteLine(-1);
                    return;
                }
            }

            WriteLine(abs[0][2] + 1);
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
