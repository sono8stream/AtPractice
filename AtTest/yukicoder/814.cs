using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.yukicoder
{
    class _814
    {
        static void Main(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long res = 0;
            for(int i = 0; i < n; i++)
            {
                long[] kld = ReadLongs();
                long k = kld[0];
                long l = kld[1];
                int d = (int)kld[2];
                long xor = 0;
                long one = 1;
                for (int j = 0; j < d; j++)
                {
                    if ((l & (one << j)) > 0)
                    {
                        if (k % 2 == 1) xor += (one << j);
                    }
                }
                long unused = (l >> d) - 1;
                long shift = (l >> d) + k - 1;
                //WriteLine(one << 62);
                for (int j = d; j < 62; j++)
                {
                    long div = (one << (j - d + 1));
                    long cnt = (shift / div) * div / 2;
                    if (shift % div >= div / 2) {
                        cnt += shift % div - div / 2 + 1;
                    }
                    if (unused >= 0)
                    {
                        cnt -= (unused / div) * div / 2;
                        if (unused % div >= div / 2)
                        {
                            cnt -= unused % div - div / 2 + 1;
                        }
                    }
                    if (cnt%2>0) xor += (one<<j);
                }
                res ^=xor;
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
