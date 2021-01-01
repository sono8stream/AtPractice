using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1236
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
            long[] nm = ReadLongs();
            long n = nm[0];
            long m=nm[1];
            long mask = 1000000000 + 7;

            long[] pow2s = new long[40];
            pow2s[0] = 2;
            for(int i = 1; i < 40; i++)
            {
                pow2s[i] = pow2s[i - 1] * pow2s[i - 1];
                pow2s[i] %= mask;
            }

            long div = 1;
            long dig = 0;
            long pow = 1;
            while (div <= m)
            {
                if ((m / div) % 2 == 1)
                {
                    pow *= pow2s[dig];
                    pow %= mask;
                }
                div *= 2;
                dig++;
            }
            pow = (pow + mask - 1) % mask;

            long[] powPows = new long[40];
            powPows[0] = pow;
            for(int i =1; i < 40; i++)
            {
                powPows[i] = powPows[i - 1] * powPows[i - 1];
                powPows[i] %= mask;
            }

            div = 1;
            dig = 0;
            long res = 1;
            while (div <= n)
            {
                if ((n / div) % 2 == 1)
                {
                    res *= powPows[dig];
                    res %= mask;
                }
                div *= 2;
                dig++;
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
