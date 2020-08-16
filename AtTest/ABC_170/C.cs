using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_170
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
            int[] xn = ReadInts();
            int x = xn[0];
            int n = xn[1];
            if (n == 0)
            {
                WriteLine(x);
                return;
            }
            int[] ps = ReadInts();
            var hashset = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                hashset.Add(ps[i]);
            }

            int res = -100;
            for(int i = -100; i < 200; i++)
            {
                if (hashset.Contains(i))
                {
                    continue;
                }

                int delta = Abs(x - i);
                if (delta < Abs(x - res))
                {
                    res = i;
                }
            }

            WriteLine(res);
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
