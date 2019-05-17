using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.diverta2019
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] rgbn = ReadInts();
            int r = rgbn[0];
            int g = rgbn[1];
            int b = rgbn[2];
            int n = rgbn[3];

            int[] val = new int[3] { r, g, b };
            Array.Sort(val);
            Array.Reverse(val);
            int res = 0;
            for(int i = 0; i * val[0] <= n; i++)
            {
                int delta = n - i * val[0];
                for(int j = 0; j * val[1] <= delta; j++)
                {
                    int delta2 = delta - j * val[1];
                    if (delta2 % val[2] == 0) res++;
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
