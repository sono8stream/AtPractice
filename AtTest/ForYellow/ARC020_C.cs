﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC020_C
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
            long[][] als = new long[n][];
            for(int i = 0; i < n; i++)
            {
                als[i] = ReadLongs();
            }
            Array.Reverse(als);
            long b = ReadLong();

            long res = 0;
            long digMod = 1;
            for(int i = 0; i < n; i++)
            {
                long a = als[i][0];
                long l = als[i][1];

                long dig = 1;
                while (dig <= a)
                {
                    dig *= 10;
                }
                dig %= b;

                long bit = 1;
                long tmp = a;
                while (bit <= l)
                {
                    if ((l & bit) > 0)
                    {
                        res += tmp * digMod;
                        res %= b;
                        digMod *= dig;
                        digMod %= b;
                    }

                    tmp += tmp * dig;
                    tmp %= b;
                    dig *= dig;
                    dig %= b;
                    bit *= 2;
                }
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
