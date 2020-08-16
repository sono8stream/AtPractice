﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.M_Solutions_2020
{
    class A
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int x = ReadInt();
            int cnt = 1;
            if (x <= 599)
            {
                cnt++;
            }
            if (x <= 799)
            {
                cnt++;
            }
            if (x <= 999)
            {
                cnt++;
            }
            if (x <= 1199)
            {
                cnt++;
            }
            if (x <= 1399)
            {
                cnt++;
            }
            if (x <= 1599)
            {
                cnt++;
            }
            if (x <= 1799)
            {
                cnt++;
            }
            WriteLine(cnt);
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
