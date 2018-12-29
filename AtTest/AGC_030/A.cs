using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_030
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] abc = ReadLongs();
            long a = abc[0];
            long b = abc[1];
            long c = abc[2];
            if (c <= b+1)
            {
                Console.WriteLine(b + c);
            }
            else
            {
                if (c <= b + a + 1)
                {
                    Console.WriteLine(b + c);
                }
                else
                {
                    Console.WriteLine(b * 2 + a + 1);
                }
            }
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
