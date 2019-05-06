using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class DDCC2017Final_B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] nz = ReadLongs();
            long n = nz[0];
            long z = nz[1];
            long[] array = ReadLongs();

            long[] gcds = new long[n];
            for(int i = 0; i < n; i++)
            {
                gcds[i] = GCD(z, array[i]);
            }

            long res = 1;
            for(int i = 0; i < n; i++)
            {
                res = LCM(res, gcds[i]);
            }
            WriteLine(res);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long LCM(long a, long b)
        {
            long c = GCD(a, b);
            return a / c * b;
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
