using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Aising2018
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[] array = ReadInts();
            int[][] xs = new int[q][];
            for(int i = 0; i < q; i++)
            {
                xs[i] = new int[3] { ReadInt(), i, 0 };
            }
            Array.Sort(xs, (a, b) => a[0] - b[0]);
            var crossSums = new long[n];
            crossSums[0] = array[0];
            crossSums[1] = array[1];
            var allSums = new long[n];
            allSums[0] = array[0];
            allSums[1] = allSums[0] + array[1];
            for(int i = 2; i < n; i++)
            {
                crossSums[i] = crossSums[i - 2] + array[i];
                allSums[i] = allSums[i - 1] + array[i];
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
