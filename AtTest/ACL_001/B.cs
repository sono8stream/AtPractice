using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ACL_001
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
            long n = ReadLong();
            if (n == 1)
            {
                WriteLine(1);
                return;
            }

            long res = long.MaxValue;
            for (long i = 1; i * i <= 2 * n; i++)
            {
                if (2*n % i != 0)
                {
                    continue;
                }

                long other = 2 * n / i;
                long gcd;
                long x = 0, y = 0;
                gcd = ExtendedEuclidian(i, other, ref x, ref y);
                if (gcd == 1 && x != 0 && y != 0)
                {
                    res = Min(res, Abs(i * x));
                    res = Min(res, Abs(other * y));
                }
            }

            WriteLine(res);
        }

        static long ExtendedEuclidean(long a,long b,ref long x,ref long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }

            long d = ExtendedEuclidean(b, a % b, ref y, ref x);
            y -= a / b * x;
            return d;
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
