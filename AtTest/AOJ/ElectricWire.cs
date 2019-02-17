using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AOJ
{
    class ElectricWire
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] xy = ReadInts();
            int x = xy[0];
            int y = xy[1];
            int a = Math.Max(x, y);
            int b = Math.Min(x, y);
            while (b > 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }
            int gcd = a;
            int unitX = x / gcd;
            int unitY = y / gcd;
            int unitCnt = unitX - 1 + unitY - 1 + 1;
            Console.WriteLine(unitCnt * gcd + 1);
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
