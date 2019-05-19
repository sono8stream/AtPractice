using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_126
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            int front = int.Parse(s.Substring(0, 2));
            int back = int.Parse(s.Substring(2, 2));

            if (1<=front&&front <= 12
                &&1<=back&& back <= 12)
            {
                WriteLine("AMBIGUOUS");
            }
            else if (1<=front&&front <= 12)
            {
                WriteLine("MMYY");
            }
            else if (1<=back&&back <= 12)
            {
                WriteLine("YYMM");
            }
            else
            {
                WriteLine("NA");
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
