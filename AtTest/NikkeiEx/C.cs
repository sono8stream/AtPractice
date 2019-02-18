using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.NikkeiEx
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int val = 0;
            bool plus = true;
            while (n > 0)
            {
                if (plus)
                {
                    val += n % 10;
                }
                else
                {
                    val -= n % 10;
                }
                plus = !plus;
                n /= 10;
            }
            while (val < 0) val += 11;
            Console.WriteLine(val % 11);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
