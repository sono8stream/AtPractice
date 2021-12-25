using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_113
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];

            long mask = 998244353;
            long res = 0;
            long[] nPows = new long[k + 1];
            long[] mPows = new long[k + 1];
            for (int i = 1; i <= k; i++)
            {
                nPows[i] = Pow(i, n, mask);
                mPows[i] = Pow(i, m, mask);
            }

            if (n == 1)
            {
                res = mPows[k];
            }
            else if (m == 1)
            {
                res = nPows[k];
            }
            else
            {
                for (int i = 1; i <=k; i++)
                {
                    long bPats = (mPows[i] - mPows[i - 1] + mask) % mask;
                    res += bPats * nPows[k - i + 1];
                    res %= mask;
                }
            }

            WriteLine(res);
        }

        static long Pow(long a,long b,long mask)
        {
            long res = 1;
            long div = 1;
            long cur = a;
            while (div <= b)
            {
                if ((b & div) > 0)
                {
                    res *= cur;
                    res %= mask;
                }
                cur *= cur;
                cur %= mask;
                div *= 2;
            }
            return res;
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
