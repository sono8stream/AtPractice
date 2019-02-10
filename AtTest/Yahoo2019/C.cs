using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Yahoo2019
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
            long[] kab = ReadLongs();
            long k = kab[0];
            long a = kab[1];
            long b = kab[2];
            if (b - 2 <= a)
            {
                Console.WriteLine(1 + k);
            }
            else
            {
                if (k <= a - 1)
                {
                    Console.WriteLine(1 + k);
                }
                else
                {
                    k -= a - 1;
                    long res = a;
                    long delta = b - a;
                    res += delta * (k / 2);
                    if (k % 2 > 0) res++;
                    Console.WriteLine(res);
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
