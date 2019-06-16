using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_130
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];
            long[] array = ReadLongs();
            long[] sums = new long[n];
            sums[0] = array[0];
            for(int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + array[i];
            }

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                long max = sums[n - 1];
                if (i > 0) max -= sums[i - 1];
                if (max < k) continue;

                long bottom = i-1;
                long top = n - 1;
                while (bottom + 1 < top)
                {
                    long mid = (bottom + top + 1) / 2;

                    long now = sums[mid];
                    if (i > 0) now -= sums[i - 1];
                    if (now >= k) top = mid;
                    else bottom = mid;
                }
                res += n - top;
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
