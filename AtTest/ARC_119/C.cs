﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_119
{
    class C
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
            int[] vals = ReadInts();
            long[] evenOddSums = new long[n];
            evenOddSums[0] = vals[0];
            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evenOddSums[i] = evenOddSums[i - 1] + vals[i];
                }
                else
                {
                    evenOddSums[i] = evenOddSums[i - 1] - vals[i];
                }
            }

            long res = 0;
            var dict = new Dictionary<long, int>();
            dict.Add(0, 1);
            dict.Add(evenOddSums[0], 1);
            for(int i = 1; i < n; i++)
            {
                if (dict.ContainsKey(evenOddSums[i]))
                {
                    res += dict[evenOddSums[i]];
                    dict[evenOddSums[i]]++;
                }
                else
                {
                    dict.Add(evenOddSums[i], 1);
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
