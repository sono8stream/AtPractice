using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeThanksFestival2018
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
            int n = ReadInt();
            long[] xs = ReadLongs();
            Array.Sort(xs);
            long[] xMargins = new long[n-1];
            for (int i = 0; i < n-1; i++)
            {
                xMargins[i] = xs[i + 1] - xs[i];
            }

            long res = 0;
            for(int i = 0; i < n - 1; i++)
            {
                long l = i + 1;
                long r = n - l;
                res += xMargins[i] * l * r;
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
