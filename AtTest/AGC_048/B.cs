using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_048
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
            int n = ReadInt();
            long[] arrayA = ReadLongs();
            long[] arrayB = ReadLongs();

            long res = 0;
            long[] odds = new long[n / 2];
            long[] evens = new long[n / 2];
            for(int i = 0; i < n; i++)
            {
                res += arrayA[i];
                if (i % 2 == 0)
                {
                    evens[i / 2] = arrayB[i] - arrayA[i];
                }
                else
                {
                    odds[i / 2] = arrayB[i] - arrayA[i];
                }
            }

            Array.Sort(odds);
            Array.Sort(evens);

            for(int i = 0; i < n / 2; i++)
            {
                if (odds[i] + evens[i] > 0)
                {
                    res += odds[i] + evens[i];
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
