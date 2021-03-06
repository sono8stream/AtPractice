﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_182
{
    class D
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
            long[] array = ReadLongs();
            long[] sums = new long[n];
            for(int i = 0; i < n; i++)
            {
                sums[i] = array[i];
                if (i > 0)
                {
                    sums[i] += sums[i - 1];
                }
            }
            int[] maxs = new int[n];
            maxs[0] = sums[0] >= 0 ? 0 : -1;
            for (int i = 1; i < n; i++)
            {
                if (maxs[i - 1] == -1)
                {
                    if (sums[i] >= 0)
                    {
                        maxs[i] = i;
                    }
                    else
                    {
                        maxs[i] = -1;
                    }
                }
                else
                {
                    if (sums[maxs[i - 1]] <= sums[i])
                    {
                        maxs[i] = i;
                    }
                    else
                    {
                        maxs[i] = maxs[i - 1];
                    }
                }
            }

            long res = 0;
            long tmp = 0;
            for(int i = 0; i < n; i++)
            {
                if (maxs[i] >= 0)
                {
                    res = Max(res, tmp + sums[maxs[i]]);
                }
                tmp += sums[i];
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
