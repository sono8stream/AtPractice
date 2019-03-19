﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_031
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nab = ReadInts();
            int n = nab[0];
            int a = nab[1];
            int b = nab[2];
            int delta = 0;
            int div = 1;
            for(int i = 0; i < n; i++)
            {
                if ((a & div) != (b & div)) delta++;
                div *= 2;
            }
            if (delta % 2 ==0)
            {
                WriteLine("NO");
                return;
            }
            WriteLine("YES");
            var dict = new Dictionary<int, bool>();
            dict.Add(a,true);
            dict.Add(b,true);
            int all = 1 << n;
            int val = a;
            int[] res = new int[all];
            res[0] = Min(a, b);
            res[all - 1] = Max(a, b);
            if (b < a) Array.Reverse(res);
            for(int i = 0; i < 1 << n; i++)
            {
                Write(res[i]);
                if (i + 1 < 1 << n) Write(" ");
            }
            WriteLine();
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
