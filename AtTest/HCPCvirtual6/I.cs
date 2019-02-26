using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPCvirtual6
{
    class I
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int q = ReadInt();
            long[] res = new long[q];
            for(int i =0; i < q; i++)
            {
                long[] ab = ReadLongs();
                long a = ab[0];
                long b = ab[1];
                long[] sums = new long[b - a + 1];
                for(int j = 0; j < b - a + 1; j++)
                {
                    sums[j] = a + j;
                    if (j > 0) sums[j] += sums[j - 1];
                }
                long val = sums[b - a];
                val -= a - 1;
                for(int j = 1; j < b - a + 1; j++)
                {
                    long bad = sums[j] - (sums[b - a] - sums[b - a - j]);
                    if (bad > 1)
                    {
                        val -= bad - 1;
                    }
                }
                res[i] = val;
            }
            for(int i = 0; i < q; i++)
            {
                WriteLine(res[i]);
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
