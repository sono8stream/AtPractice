using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class Indeednow_2015_QualB_D
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
            int[] nc = ReadInts();
            int n = nc[0];
            int c = nc[1];
            int[] array = ReadInts();

            long[] prevs = new long[c];
            long[] res = new long[c];
            for(int i = 0; i < c; i++)
            {
                prevs[i] = -1;
                res[i] = (long)n * (n + 1) / 2;
            }
            for(int i = 0; i < n; i++)
            {
                long delta = i - prevs[array[i] - 1] - 1;
                res[array[i]-1] -= delta * (delta + 1) / 2;
                prevs[array[i] - 1] = i;
            }

            for(int i = 0; i < c; i++)
            {
                long delta = n - prevs[i] - 1;
                res[i] -= delta * (delta + 1) / 2;
                WriteLine(res[i]);
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
