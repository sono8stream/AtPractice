using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Square6
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long rangeSum = 0;

            long[] aArray = new long[n];
            long[] bArray = new long[n];
            long res = 0;
            for (int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                long a = ab[0];
                long b = ab[1];
                aArray[i] = a;
                bArray[i] = b;
                res += b - a;
            }
            Array.Sort(aArray);
            Array.Sort(bArray);
            for(int i = 0; i < n; i++)
            {
                if (i <= n / 2)
                {
                    res += aArray[n / 2] - aArray[i];
                    res += bArray[n/2] - bArray[i];
                }
                else
                {
                    res += aArray[i] - aArray[n/2];
                    res += bArray[i] - bArray[n /2];
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
