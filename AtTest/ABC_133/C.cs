using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_133
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] lr = ReadLongs();
            long l = lr[0];
            long r = lr[1];
            if (r-l >= 2019)
            {
                WriteLine(0);
            }
            else
            {
                bool[] ok = new bool[2019];
                long ll = l % 2019;
                long rr = r % 2019;
                if (ll < rr)
                {
                    for (long i = ll; i <= rr; i++) ok[i] = true;
                }
                else
                {
                    for (long i = ll; i < 2019; i++) ok[i] = true;
                    for (long i = 0; i <=rr; i++) ok[i] = true;
                }

                long res = 2018;
                for (long i = 0; i < 2019; i++)
                {
                    if (!ok[i]) continue;
                    for (long j = i + 1; j < 2019; j++)
                    {
                        if (!ok[j]) continue;

                        res = Min(res, (i * j) % 2019);
                    }
                }

                WriteLine(res);
            }
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
