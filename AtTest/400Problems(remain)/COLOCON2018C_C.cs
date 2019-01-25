using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class COLOCON2018C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] ab = ReadLongs();
            long a = ab[0];
            long b = ab[1];
            long n = b - a + 1;
            long cnt2 = 0;
            long cnt3 = 0;
            long cnt6 = 0;
            List<long> others = new List<long>();
            for(long i = a; i <= b; i++)
            {
                if (i % 2 == 0) { cnt2++; continue; }
                if (i % 3 == 0) { cnt3++; continue; }
                others.Add(i);
            }
            long allPat = (long)Math.Pow(2, others.Count);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
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
