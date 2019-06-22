using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_131
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];

            int max = (n - 1) * (n - 2) / 2;
            if (k > max)
            {
                WriteLine(-1);
                return;
            }

            int delta = max - k;
            int m = delta + n - 1;
            WriteLine(m);
            for (int i = 1; i < n ; i++)
            {
                WriteLine(1 + " " + (i + 1));
            }
            if (delta == 0) return;
            for(int i = 1; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    WriteLine((i + 1) + " " + (j + 1));
                    delta--;
                    if (delta == 0) return;
                }
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
