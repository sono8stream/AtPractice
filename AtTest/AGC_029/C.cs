﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.AGC_029
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            long bottom=0;
            long top = int.MaxValue;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                var que = new Queue<int[]>();
                int len = 0;
                for(int i = 0; i < n; i++)
                {
                    if (len < array[i])
                    {
                        que.Enqueue(new int[2] { 1, array[i] - len });
                        len = array[i];
                    }
                    else
                    {
                        while (array[i] < len)
                        {

                        }
                    }
                }
            }
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
