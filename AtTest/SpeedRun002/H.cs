﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.SpeedRun002
{
    class H
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] res = new long[n];
            for(int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                long delta = Abs(ab[0] - ab[1]);
                if (delta == 0) res[i] = -1;
                else res[i] = delta;
            }

            for (int i = 0; i < n; i++) WriteLine(res[i]);
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
