using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_117
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
            int[] nm = ReadInts();
            int[] xs = ReadInts();
            int n = nm[0];
            int m = nm[1];
            if (n >= m)
            {
                Console.WriteLine(0);
                return;
            }
            Array.Sort(xs);
            int delta = xs[m - 1] - xs[0];
            int[] deltas = new int[m - 1];
            for(int i = 0; i+1 < m; i++)
            {
                deltas[i] = xs[i + 1] - xs[i];
            }
            Array.Sort(deltas);
            Array.Reverse(deltas);
            for(int i = 0; i < n - 1; i++)
            {
                delta -= deltas[i];
            }
            Console.WriteLine(delta);
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
