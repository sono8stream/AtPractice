using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class Tenka1_2017D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }
            long res = 0;
            for(int i = 0; i < n; i++)
            {
                if ((k | abs[i][0]) == k) res += abs[i][1];
            }
            for(int i = 0; i < 30; i++)
            {
                if ((k & (1 << i)) == 0) continue;

                int kk = 0;
                for(int j = 0; j < 30; j++)
                {
                    if (j < i) kk += 1 << j;
                    if (j > i) kk += (k & (1 << j));
                }

                long tmp = 0;
                for(int j = 0; j < n; j++)
                {
                    if ((kk | abs[j][0]) == kk) tmp += abs[j][1];
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
