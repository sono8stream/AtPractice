using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_121
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            long[] ab = ReadLongs();
            long a = ab[0];
            long b = ab[1];
            long div = 2;
            long val = 0;
            for(int i = 0; i < 50; i++)
            {
                long cnt = (b / div) * (div / 2);
                if (b % div > div / 2 - 1)
                {
                    cnt += b % div - (div / 2 - 1);
                }
                if (a > 0)
                {
                    cnt -= ((a - 1) / div) * (div / 2);
                    if ((a - 1) % div > div / 2 - 1)
                    {
                        cnt -= (a - 1) % div - (div / 2 - 1);
                    }
                }
                if (cnt % 2 == 1)
                {
                    //WriteLine(div / 2);
                    val += div / 2;
                }
                div *= 2;
            }
            WriteLine(val);
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
