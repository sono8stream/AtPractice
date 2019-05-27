using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_128
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] ss = ReadLongs();
            long res = 0;
            for (int i = 1; i < n / 2; i++)
            {
                long sum = 0;
                var useSet = new HashSet<long>();
                for (int j = 1; i * (j + 1) < n - 1; j++)
                {
                    long other = n - i * j - 1;
                    useSet.Add(i * j);
                    if (useSet.Contains(other)) break;

                    sum += ss[i * j] + ss[other];
                    res = Max(res, sum);
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
