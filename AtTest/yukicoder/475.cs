using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.yukicoder
{
    class _475
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nsw = ReadInts();
            int n = nsw[0];
            int s = nsw[1];
            int w = nsw[2];
            long[] prevArray = new long[n - 1];
            int[] array = ReadInts();
            for (int i = 0; i < n; i++)
            {
                if (i < w) prevArray[i] = array[i];
                if (i > w) prevArray[i - 1] = array[i];
            }
            prevArray = prevArray.OrderBy(a => -a).ToArray();

            int writerTotal = array[w] + 100 * s;

            int[] points = new int[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                points[i] = 50 * s + 500 * s / (8 + 2 * (i + 1));
            }
            double res = 1;
            int pointI = n - 2;
            for (int i = 0; i < n - 1; i++)
            {
                while (pointI >= 0
                    && prevArray[i] + points[pointI] <= writerTotal)
                {
                    pointI--;
                }
                pointI++;
                if (n - 1 - pointI - i <= 0)
                {
                    WriteLine(0);
                    return;
                }
                res *= n - 1 - pointI - i;
                res /= (n-i-1);
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
