﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_100
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var array = ReadInts();
            long cnt = 0;
            for (int i = 0; i < n; i++)
            {
                while (array[i] % 2 == 0)
                {
                    array[i] /= 2;
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
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