using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_110
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nmxy = ReadInts();
            int n = nmxy[0];
            int m = nmxy[1];
            int x = nmxy[2];
            int y = nmxy[3];
            int[] xs = ReadInts();
            int[] ys = ReadInts();
            Array.Sort(xs);
            Array.Sort(ys);
            if (xs[n - 1] >= ys[0])
            {
                WriteLine("War");
                return;
            }

            for(int i = xs[n - 1] + 1; i <= ys[0]; i++)
            {
                if (x < i && i <= y)
                {
                    WriteLine("No War");
                    return;
                }
                else continue;
            }
            WriteLine("War");
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
