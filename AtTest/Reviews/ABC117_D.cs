using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Reviews
{
    class ABC117_D
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
            long one = 1;

            int bits = 50;
            int[] cnts = new int[bits];
            for (int i = 0; i < bits; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((array[j] & (one << i)) > 0) cnts[i]++;
                }
            }

            long res = 0;
            for (int i = -1; i < bits; i++)
            {
                if (i >= 0 && (k & (one << i)) == 0) continue;

                long tmp = 0;
                for (int j = 0; j < bits; j++)
                {
                    if (j < i)
                    {
                        tmp += Max(n - cnts[j], cnts[j]) * (one << j);
                    }
                    if (j == i) tmp += cnts[j] * (one << j);
                    if (j > i)
                    {
                        if ((k & (one << j)) > 0)
                        {
                            tmp += (n - cnts[j]) * (one << j);
                        }
                        else
                        {
                            tmp += cnts[j] * (one << j);
                        }
                    }
                }
                res = Max(res, tmp);
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
