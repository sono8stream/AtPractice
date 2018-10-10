using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_065
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] inputs = ReadInts();
            int n = inputs[0];
            int m = inputs[1];
            if (Math.Abs(n - m) > 1)
            {
                Console.WriteLine(0);
                return;
            }
            long mask = 1000000000 + 7;

            long factor1 = Permutation(n, n, mask);
            long factor2 = Permutation(m, m, mask);
            long result = (factor1 * factor2) % mask;
            if (n == m)
            {
                result *= 2;
                result %= mask;
            }
            Console.WriteLine(result);
        }

        static long Permutation(long n, long m, long mask)
        {
            long val = 1;
            for (long i = 0; i < m; i++)
            {
                val *= ((n - i) % mask);
                val %= mask;
            }
            return val;
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
