using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Keyence_2020
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
            long[][] lrs = new long[n][];
            for(int i = 0; i < n; i++)
            {
                long[] xl = ReadLongs();
                lrs[i] = new long[2] { xl[0] - xl[1], xl[0] + xl[1] };
            }
            Array.Sort(lrs, (a, b) => a[1].CompareTo(b[1]));
            int res = 1;
            long now = lrs[0][1];
            for(int i = 1; i < n; i++)
            {
                if (lrs[i][0] < now) continue;
                now = lrs[i][1];
                res++;
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
