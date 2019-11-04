using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_040
{
    class B
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] lrs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                lrs[i] = ReadInts();
            }
            int maxRange = 0;
            int lMax = 0;
            int rMin = int.MaxValue / 2;
            for(int i = 0; i < n; i++)
            {
                maxRange = Max(maxRange, lrs[i][1] - lrs[i][0]);
                lMax = Max(lMax, lrs[i][0]);
                rMin = Min(rMin, lrs[i][1]);
            }
            int res = Max(rMin - lMax + 1, 0) + maxRange + 1;

            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = new int[2] { Max(lrs[i][1] - lMax + 1, 0), Max(rMin - lrs[i][0] + 1, 0) };
            }
            abs = abs.OrderBy(p => -p[1]).OrderBy(p => p[0]).ToArray();
            int bMax = abs[0][1];
            for(int i = 1; i < n; i++)
            {
                int tmp = abs[i][0] + bMax;
                res = Max(res, tmp);
                bMax = Min(bMax, abs[i][1]);
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
