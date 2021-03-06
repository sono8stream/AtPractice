﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Yahoo2019
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            if (nk[0] % 2 == 0)
            {
                if (nk[0] / 2 >= nk[1]) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
            else
            {
                if (nk[0] / 2 + 1 >= nk[1]) Console.WriteLine("YES");
                else Console.WriteLine("NO");
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
