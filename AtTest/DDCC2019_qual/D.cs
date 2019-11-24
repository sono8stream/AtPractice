using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DDCC2019_qual
{
    class D
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
            long m = ReadInt();
            int[] ds = new int[m];
            long[] cs = new long[m];
            long digits = 0;
            long sum = 0;
            for(int i = 0; i < m; i++)
            {
                long[] dc = ReadLongs();
                ds[i] = (int)dc[0];
                cs[i] = dc[1];
                digits += cs[i];
                sum += cs[i] * ds[i];
            }
            long res = digits - 1;
            long ups = sum / 9;
            if (sum % 9 == 0) ups--;
            res += ups;
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
