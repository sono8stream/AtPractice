﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_108
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int l = ReadInt();
            var marginList = new List<bool>();
            int m = 0;
            int ll = l;
            while (ll > 1)
            {
                marginList.Add(ll % 2 == 1);
                m += 2 + (ll & 1);
                ll /= 2;
            }
            int n = marginList.Count;
            Console.WriteLine((n + 1) + " " + m);
            for(int i = 0; i < marginList.Count; i++)
            {
                if (marginList[i])
                {
                    l--;
                    Console.WriteLine((i + 1) + " " + (n + 1) + " " + l);
                }
                Console.WriteLine((i + 1) + " " + (i + 2) + " " + 0);
                Console.WriteLine((i + 1) + " " + (i + 2) + " " + l / 2);
                l /= 2;
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
