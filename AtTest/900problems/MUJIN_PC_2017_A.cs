using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._900problems
{
    class MUJIN_PC_2017_A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long[] xs = ReadLongs();
            long res = 1;
            long tmp = 1;
            long mask = 1000000000 + 7;
            for(int i = 1; i < n; i++)
            {
                tmp++;
                if (xs[i] <= 2 * (tmp-1))
                {
                    res *= tmp;
                    res %= mask;
                    tmp--;
                }
            }
            res *= Permutation(tmp, tmp, mask);
            res %= mask;
            WriteLine(res);
        }

        static long Permutation(long n, long m, long mask)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= ((n - i) % mask);
                val %= mask;
            }
            return val;
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
