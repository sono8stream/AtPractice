﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class AGC024_C
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
            int[] array = new int[n];
            for (int i = 0; i < n; i++) array[i] = ReadInt();
            if (array[0] > 0)
            {
                WriteLine(-1);
                return;
            }
            for(int i = 1; i < n; i++)
            {
                if (array[i] > array[i - 1] + 1)
                {
                    WriteLine(-1);
                    return;
                }
            }

            long res = 0;
            for (int i = 1;i< n; i++){
                if (array[i] <= array[i-1])
                {
                    res += array[i];
                }
                else
                {
                    res++;
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
