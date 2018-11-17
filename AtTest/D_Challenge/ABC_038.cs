using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_038
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var hws = new int[n][];
            for (int i = 0; i < n; i++)
            {
                hws[i] = ReadInts();
            }
            Array.Sort(hws, (a, b) => a[0] - b[0]);
            Array.Sort(hws);
            int[] inCnts = new int[n];
            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j < i; j++)
                {

                }
            }
            Console.WriteLine("text");
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
