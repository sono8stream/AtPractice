using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_day2
{
    class C
    {

        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] xyz = ReadInts();
            int x = xyz[0];
            int y = xyz[1];
            int z = xyz[2];

            if((x*y)%2==1|| (y * z) % 2 == 1||(z* x)% 2 == 1)
            {
                WriteLine("Hom");
            }
            else
            {
                WriteLine("Tem");
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
