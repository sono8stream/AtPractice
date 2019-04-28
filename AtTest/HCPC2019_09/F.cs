using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_09
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                int block = (i - 1) % 25;
                int x = (block % 5) * 300;
                int y = (block / 5) * 300;
                if (i <= 25)
                {
                    x += i;
                    y += i;
                }
                else if (i <= 50)
                {
                    x += 300 - i;
                    y += 300 - i;
                }
                else if (i <= 75)
                {
                    x += 300 - i;
                    y += i;
                }
                else
                {
                    x += i;
                    y += 300 - i;
                }
                WriteLine(x + " " + y);
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
