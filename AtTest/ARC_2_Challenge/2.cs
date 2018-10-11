using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ARC_2_Challenge
{
    class _2
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split('/');
            int y = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int d = int.Parse(input[2]);
            Console.WriteLine(string.Format("{0}/{1}/{2}", y, m, d));
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
