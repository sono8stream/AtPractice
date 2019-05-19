using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_126
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] mk = ReadInts();
            int m = mk[0];
            int k = mk[1];

            int max = (1 << m) - 1;

            if (max < k)
            {
                WriteLine(-1);
                return;
            }

            if (max == 1)
            {
                if (k == 1)
                {
                    WriteLine(-1);
                    return;
                }
                else
                {
                    WriteLine("0 0 1 1");
                    return;
                }
            }

            int[] vals = new int[2 * max + 2];
            for(int i = 0; i <= max; i++)
            {
                if (i == k)
                {
                    vals[max] = i;
                    vals[vals.Length - 1] = i;
                }
                else if (i < k)
                {
                    vals[i] = i;
                    vals[vals.Length - 2 - i] = i;
                }
                else
                {
                    vals[i - 1] = i;
                    vals[vals.Length - 2 - i + 1] = i;
                }
            }

            for (int i = 0; i < vals.Length; i++)
            {
                Write(vals[i]);
                if (i < vals.Length - 1) Write(" ");
            }
            WriteLine();
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
