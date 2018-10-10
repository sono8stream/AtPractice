using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_110
{
    class D
    {

        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            long m = long.Parse(input[1]);
            long[] factors;
            factors = GetFactors(m);
            for (int i = 0; i < n; i++)
            {

            }
            Console.WriteLine("text");
        }

        static long[] GetFactors(long m)
        {
            long rm = (long)Math.Sqrt(m);
            var list = new List<long>();
            for (long i = 1; i <= rm; i++)
            {
                if (m % i == 0) list.Add(m);
            }

            return list.ToArray();
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
