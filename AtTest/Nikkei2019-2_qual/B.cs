﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Nikkei2019_2_qual
{
    class B
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
            int n = ReadInt();
            int[] ds = ReadInts();
            if (ds[0] != 0)
            {
                WriteLine(0);
                return;
            }
            Array.Sort(ds);
            long[] cnts = new long[n];
            cnts[0] = 1;
            long mask = 998244353;
            long res = 1;
            for(int i = 1; i < n; i++)
            {
                if (ds[i] == 0 || cnts[ds[i] - 1] == 0)
                {
                    WriteLine(0);
                    return;
                }
                res *= cnts[ds[i] - 1];
                res %= mask;
                cnts[ds[i]]++;
            }
            WriteLine(res);
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
