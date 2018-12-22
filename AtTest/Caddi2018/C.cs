using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Caddi2018
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
            long[] np = ReadLongs();
            if (np[0] == 1)
            {
                Console.WriteLine(np[1]);
                return;
            }

            double n = np[0];
            long p = np[1];
            long max = (long)Math.Pow(p, 1 / n)+1;
            long res = 1;
            for(long i = 1; i <= max; i++)
            {
                long pow = (long)Math.Pow(i, n);
                if (pow <= p && p % pow == 0) res = i;
            }
            Console.WriteLine(res);
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
