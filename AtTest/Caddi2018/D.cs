using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Caddi2018
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
            int n = ReadInt();
            bool first = false;
            for(int i = 0; i < n; i++)
            {
                int a = ReadInt();
                if (a % 2 == 1)
                {
                    first = true;
                }
            }
            if (first)
            {
                Console.WriteLine("first");
            }
            else
            {
                Console.WriteLine("second");
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
