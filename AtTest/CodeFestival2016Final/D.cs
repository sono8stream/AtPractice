using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeFestival2016Final
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] xs = ReadInts();
            Array.Sort(xs);
            int remainVal = -1;
            int[] pairCnts = new int[m];
            int[] remainCnts = new int[m];
            for (int i = 0; i < n; i++)
            {
                if (remainVal == xs[i])
                {
                    pairCnts[xs[i] % m]++;
                    remainVal = -1;
                }
                else
                {
                    if (remainVal > 0) remainCnts[remainVal % m]++;
                    remainVal = xs[i];
                }
            }
            if (remainVal > 0) remainCnts[remainVal % m]++;

            int res = 0;
            for (int i = 0; i <= m - i; i++)
            {
                int other = m - i;
                if (i == 0 || i == m - i)
                {
                    res += remainCnts[i] / 2 + pairCnts[i];
                }
                else
                {
                    int a, b;
                    if (remainCnts[i] < remainCnts[other])
                    {
                        a = i;
                        b = other;
                    }
                    else
                    {
                        a = other;
                        b = i;
                    }
                    res += remainCnts[a];
                    remainCnts[b] -= remainCnts[a];
                    res += Min(pairCnts[a] * 2, remainCnts[b]);
                    pairCnts[a] = Max(
                        (pairCnts[a] * 2 - remainCnts[b]) / 2, 0);
                    res += pairCnts[a] + pairCnts[b];
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
