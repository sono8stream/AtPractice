﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeThanksFestival2018
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
            int[] tabcd = ReadInts();
            if (tabcd[0] >= tabcd[1] + tabcd[3])
            {
                Console.WriteLine(tabcd[2] + tabcd[4]);
            }
            else if (tabcd[0] >= tabcd[3])
            {
                Console.WriteLine(tabcd[4]);
            }
            else if (tabcd[0] >= tabcd[1])
            {
                Console.WriteLine(tabcd[2]);

            }
            else
            {
                Console.WriteLine(0);
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
