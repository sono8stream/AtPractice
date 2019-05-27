using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.SpeedRun002
{
    class J
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[][] abs = new long[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadLongs();
            }

            var set = new SortedSet<long>();
            long aMax = (long)Sqrt(abs[0][0]);
            for (int j = 1; j <= aMax; j++)
            {
                if (abs[0][0] % j == 0)
                {
                    set.Add(-j);
                    set.Add(-abs[0][0] / j);
                }
            }
            long bMax = (long)Sqrt(abs[0][1]);
            for (int j = 1; j <= bMax; j++)
            {
                if (abs[0][1] % j == 0)
                {
                    set.Add(-j);
                    set.Add(-abs[0][1] / j);
                }
            }

            foreach (long val in set)
            {
                bool ok = true;
                for(int i = 0; i < n; i++)
                {
                    if (abs[i][0] % -val > 0 && abs[i][1] % -val > 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    WriteLine(-val);
                    return;
                }
            }
        }

        static long GCD(long a, long b)
        {
            if (a % b == 0) return b;
            else return GCD(b, a % b);
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
