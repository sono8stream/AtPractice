﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ARC_A
{
    class _051
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] circle = ReadInts();
            int[] square = ReadInts();
            bool red = !(circle[0] + circle[1] <= square[2]
                && circle[0] - circle[1] >= square[0]
                && circle[1] + circle[1] <= square[3]
                && circle[1] - circle[1] < square[1]);
            //bool blue=
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
