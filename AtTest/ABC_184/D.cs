﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_184
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
            int[] abc = ReadInts();

            double[,,] dp = new double[105, 105, 105];
            for (int i = 99; i >= 0; i--)
            {
                for (int j = 99; j >= 0; j--)
                {
                    for (int k = 99; k >= 0; k--)
                    {
                        dp[i, j, k] += (dp[i + 1, j, k] + 1) * i / (i + j + k);
                        dp[i, j, k] += (dp[i, j + 1, k] + 1) * j / (i + j + k);
                        dp[i, j, k] += (dp[i, j, k + 1] + 1) * k / (i + j + k);
                    }
                }
            }
            WriteLine(dp[abc[0], abc[1], abc[2]]);
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
