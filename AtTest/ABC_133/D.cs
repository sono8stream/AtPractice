using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_133
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
            long[] array = ReadLongs();
            long deltaSum = 0;
            for(int i = 0; i < n; i++)
            {
                if (i % 2 == 0) deltaSum += array[i];
                else deltaSum -= array[i];
            }

            long[] res = new long[n];
            res[0] = deltaSum;
            res[n - 1] = (array[n - 1] - res[0] / 2) * 2;
            for(int i = n - 2; i > 0; i--)
            {
                res[i] = (array[i] - res[i + 1] / 2) * 2;
            }

            for(int i =0; i < n; i++)
            {
                Write(res[i]);
                if (i + 1 < n) Write(" ");
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
