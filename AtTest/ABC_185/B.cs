using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_185
{
    class B
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
            int[] nmt = ReadInts();
            long n = nmt[0];
            int m = nmt[1];
            long t = nmt[2];

            long now = n;
            long time = 0;
            for(int i = 0; i < m; i++)
            {
                long[] ab = ReadLongs();
                long a = ab[0];
                long b = ab[1];
                long down = a - time;
                if (now <= down)
                {
                    WriteLine("No");
                    return;
                }
                now -= down;
                now += b - a;
                now = Min(now, n);
                time = b;
            }

            long lastDown = t - time;
            if (now <= lastDown)
            {
                WriteLine("No");
                return;
            }
            WriteLine("Yes");
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
