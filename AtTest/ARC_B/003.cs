﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_B
{
    class _003
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string[][] strs = new string[n][];
            for (int i = 0; i < n; i++)
            {
                strs[i] = new string[2];
                strs[i][0] = Read();
                strs[i][1] = "";
                for (int j = strs[i][0].Length - 1; j >= 0; j--)
                {
                    strs[i][1] += strs[i][0][j];
                }
            }
            strs = strs.OrderBy(a => a[1]).ToArray();
            for(int i = 0; i < n; i++)
            {
                WriteLine(strs[i][0]);
            }
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
