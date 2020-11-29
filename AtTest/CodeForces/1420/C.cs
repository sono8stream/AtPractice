﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1420
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nq = ReadInts();
                int n = nq[0];
                int q = nq[1];
                long[] array = ReadLongs();

                // plus or minus
                long[,] dp = new long[n, 2];
                dp[0, 0] = array[0];
                for(int j = 1; j < n; j++)
                {
                    dp[j, 0] = Max(dp[j - 1, 0], dp[j - 1, 1] + array[j]);
                    dp[j, 1] = Max(dp[j - 1, 1], dp[j - 1, 0] - array[j]);
                }

                WriteLine(Max(dp[n - 1, 0], dp[n - 1, 1]));
            }
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
