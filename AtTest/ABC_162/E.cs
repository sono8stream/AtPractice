using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_162
{
    class E
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
            int[] nk = ReadInts();
            long n = nk[0];
            long k = nk[1];
            long mask = 1000000000 + 7;
            long res = 0;
            long[] cnts = new long[k + 1];
            for(long i = k; i >= 1; i--)
            {
                long cnt = Pow(k / i, n, mask);
                for(long j = 2; i * j <= k; j++)
                {
                    cnt = (cnt - cnts[i * j] + mask) % mask;
                }

                cnts[i] = cnt;
                res += cnt * i;
                res %= mask;
            }
            WriteLine(res);
        }

        static long Pow(long x,long y,long mask)
        {
            long res = 1;
            long div = x;
            long dig = 1;
            while (dig <= y)
            {
                if ((dig & y) > 0)
                {
                    res *= div;
                    res %= mask;
                }
                div *= div;
                div %= mask;
                dig *= 2;
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
