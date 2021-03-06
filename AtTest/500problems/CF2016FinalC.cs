﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class CF2016FinalC
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            bool[] bits = new bool[32];
            int[] changeBits = new int[n];
            for (int i = 0; i < n; i++)
            {
                int val = ReadInt();
                int minBit = -1;
                for(int j = 0; j < 32; j++)
                {
                    if ((val & (1 << j)) > 0)
                    {
                        bits[j] = !bits[j];
                        if (minBit == -1) minBit = j;
                    }
                }
                changeBits[i] = minBit;
            }
            Array.Sort(changeBits);
            Array.Reverse(changeBits);
            int cnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (bits[changeBits[i]])
                {
                    for(int j = 0; j <= changeBits[i]; j++)
                    {
                        bits[j] = !bits[j];
                    }
                    cnt++;
                }
            }
            for(int i = 0; i < 32; i++)
            {
                if (bits[i])
                {
                    WriteLine(-1);
                    return;
                }
            }
            WriteLine(cnt);
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
