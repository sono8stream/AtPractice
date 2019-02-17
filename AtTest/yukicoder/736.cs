using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.yukicoder
{
    class _736
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            long gcd = array[0];
            for(int i = 1; i < n; i++)
            {
                gcd = GCD(gcd, array[i]);
            }
            for(int i =0; i < n; i++)
            {
                Console.Write(array[i] / gcd);
                if (i < n - 1) Console.Write(":");
            }
        }

        static long GCD(long x,long y)
        {
            long a = Math.Max(x, y);
            long b = Math.Min(x, y);
            while (b > 0)
            {
                long tmp = b;
                b = a % b;
                a = tmp;
            }
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
