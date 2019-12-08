using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JOI2019_2
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
            long[] mr = ReadLongs();
            long m = mr[0];
            long r = mr[1];
            long[][] costs = new long[10][];
            costs[0] = new long[10] { 1, 2, 3, 4, 3, 4, 5, 4, 5, 6 };
            costs[1] = new long[10] { 2, 1, 2, 3, 2, 3, 4, 3, 4, 5 };
            costs[2] = new long[10] { 3, 2, 1, 2, 3, 2, 3, 4, 3, 4 };
            costs[3] = new long[10] { 4, 3, 2, 1, 4, 3, 2, 5, 4, 3 };
            costs[4] = new long[10] { 3, 2, 3, 4, 1, 2, 3, 2, 3, 4 };
            costs[5] = new long[10] { 4, 3, 2, 3, 2, 1, 2, 3, 2, 3 };
            costs[6] = new long[10] { 5, 4, 3, 2, 3, 2, 1, 4, 3, 2 };
            costs[7] = new long[10] { 4, 3, 4, 5, 2, 3, 4, 1, 2, 3 };
            costs[8] = new long[10] { 5, 4, 3, 4, 3, 2, 3, 2, 1, 2 };
            costs[9] = new long[10] { 6, 5, 4, 3, 4, 3, 2, 3, 2, 1 };
            long res = long.MaxValue;
            for(long i = 0; i < 100000; i++)
            {
                long val = m * i + r;
                long tmp = 0;
                long div = 1;
                long now = 0;
                while (div * 10 <= val) div *= 10;
                WriteLine(div);
                while (div >= 1)
                {
                    long next = (val / div) % 10;
                    tmp += costs[now][next];
                    now = next;
                    div /= 10;
                }
                if (res > tmp) WriteLine(val);
                res = Min(res, tmp);
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
