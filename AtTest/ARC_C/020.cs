﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _020
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] als = new int[n][];
            for(int i = 0; i < n; i++)
            {
                als[i] = ReadInts();
            }
            long b = ReadInt();
            long res = 0;
            for (int i = 0; i < n; i++)
            {
                long pow = 1;
                while (pow <= als[i][0]) pow *= 10;
                List<bool> bit = new List<bool>();
                long ll = als[i][1];
                while (ll > 0)
                {
                    bit.Add(ll % 2 == 1);
                    ll /= 2;
                }
                bit.Reverse();

                //doubling
                long nowMod = als[i][0] % b;
                long val = 0;
                for(int j = 1; j < bit.Count; j++)
                {

                }
            }
            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
