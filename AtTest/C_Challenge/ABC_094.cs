using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_094
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] xs = ReadInts();
            var xSub = new int[n];
            for (int i = 0; i < n; i++)
            {
                xSub[i] = xs[i];
            }
            Array.Sort(xSub);
            int medMin = xSub[n / 2 - 1];
            int medMax = xSub[n / 2];
            for (int i = 0; i < n; i++)
            {
                if (xs[i] <= medMin)
                {
                    Console.WriteLine(medMax);
                }
                else
                {
                    Console.WriteLine(medMin);
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
