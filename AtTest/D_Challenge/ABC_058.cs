using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_058
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            long[] xs = ReadLongs();
            long[] ys = ReadLongs();
            long mask = 1000000000 + 7;
            long ySum = 0;
            for (int i = 0; i < nm[1] / 2; i++)
            {
                ySum += (ys[nm[1] - i - 1] - ys[i]) * (nm[1] - i * 2 - 1);
                ySum %= mask;
            }
            long xSum = 0;
            for(int i = 0; i < nm[0] / 2; i++)
            {
                xSum+= (xs[nm[0] - i - 1] - xs[i]) * (nm[0] - i * 2 - 1);
                xSum %= mask;
            }

            Console.WriteLine((xSum * ySum) % mask);
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
