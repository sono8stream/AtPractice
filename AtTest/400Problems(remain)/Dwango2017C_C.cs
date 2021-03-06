﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class Dwango2017C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = new int[n];
            int[] cnts = new int[4];
            for(int i = 0; i < n; i++)
            {
                array[i] = ReadInt();
                cnts[array[i] - 1]++;
            }
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                if (cnts[array[i] - 1] == 0) continue;
                res++;
                cnts[array[i] - 1]--;
                int now = array[i];
                for (int j = 3; j >= 0; j--)
                {
                    while (cnts[j] > 0 && now + j + 1 <= 4)
                    {
                        cnts[j]--;
                        now += j + 1;
                    }
                }
            }
            Console.WriteLine(res);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
