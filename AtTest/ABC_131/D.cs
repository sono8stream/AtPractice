using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_131
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }
            abs = abs.OrderBy(a => a[1] - a[0]).OrderBy(a=>a[1]).ToArray();

            int now = 0;
            for(int i = 0; i < n; i++)
            {
                if (now > abs[i][1] - abs[i][0])
                {
                    WriteLine("No");
                    return;
                }

                now += abs[i][0];
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
