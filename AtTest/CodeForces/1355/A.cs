﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1355
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                long[] ak = ReadLongs();
                long a = ak[0];
                long k = ak[1];

                for(int j = 2; j <= k; j++)
                {
                    long delta = GetDelta(a);
                    if (delta == 0)
                    {
                        break;
                    }

                    a += delta;
                }

                WriteLine(a);
            }
        }

        static long GetDelta(long a)
        {
            long min = 9;
            long max = 0;
            while (a>0)
            {
                min = Min(min, a % 10);
                max = Max(max, a % 10);
                a /= 10;
            }

            return min * max;
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
