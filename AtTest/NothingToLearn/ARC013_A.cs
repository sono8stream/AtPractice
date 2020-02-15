using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.NothingToLearn
{
    class ARC013_A
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
            int[] nml = ReadInts();
            int[] pqr = ReadInts();
            int res = 0;
            res = Max(res, (nml[0] / pqr[0]) * (nml[1] / pqr[1]) * (nml[2] / pqr[2]));
            res = Max(res, (nml[0] / pqr[0]) * (nml[2] / pqr[1]) * (nml[1] / pqr[2]));
            res = Max(res, (nml[1] / pqr[0]) * (nml[0] / pqr[1]) * (nml[2] / pqr[2]));
            res = Max(res, (nml[1] / pqr[0]) * (nml[2] / pqr[1]) * (nml[0] / pqr[2]));
            res = Max(res, (nml[2] / pqr[0]) * (nml[0] / pqr[1]) * (nml[1] / pqr[2]));
            res = Max(res, (nml[2] / pqr[0]) * (nml[1] / pqr[1]) * (nml[0] / pqr[2]));
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
