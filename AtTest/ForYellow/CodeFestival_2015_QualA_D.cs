using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFestival_2015_QualA_D
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
            int[] xs = new int[m];
            for(int i = 0; i < m; i++)
            {
                xs[i] = ReadInt() - 1;
            }

            long bottom = -1;
            long top = int.MaxValue;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                long now = -1;
                bool ok = true;
                for(int i = 0; i < m; i++)
                {
                    long delta = xs[i] - now - 1;
                    if (delta > mid)
                    {
                        ok = false;
                        break;
                    }
                    else if (delta < 0)
                    {
                        now = xs[i] + mid;
                    }
                    else
                    {
                        now = Max(xs[i], Max(xs[i] + mid - delta * 2, xs[i] + (mid - delta) / 2));
                    }
                }
                if (ok && now >= n - 1)
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }
            WriteLine(top);
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
