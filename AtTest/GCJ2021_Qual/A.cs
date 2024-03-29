﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2021_Qual
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
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int n = ReadInt();
            int[] vals = ReadInts();
            int sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int minI = i;
                for(int j = i; j < n; j++)
                {
                    if (vals[minI] > vals[j])
                    {
                        minI = j;
                    }
                }

                sum += minI - i + 1;
                for(int j = 0; i + j < minI - j; j++)
                {
                    int tmp = vals[i+j];
                    vals[i + j] = vals[minI - j];
                    vals[minI - j] = tmp;
                }
            }

            return () =>
            {
                WriteLine(sum);
            };
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
