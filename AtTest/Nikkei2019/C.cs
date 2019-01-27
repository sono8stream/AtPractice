using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.Nikkei2019
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
            bool[] used = new bool[n];
            var abArray = new long[n][];
            long allSum = 0;
            long[] abSums = new long[n];
            for (int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                allSum += ab[0];
                abSums[i] = ab[0] + ab[1];
            }
            Array.Sort(abSums);
            Array.Reverse(abSums);
            for(int i = 1; i < n; i += 2)
            {
                allSum -= abSums[i];
            }
            Console.WriteLine(allSum);
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
