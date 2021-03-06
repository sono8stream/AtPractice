﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] ps = ReadInts();
            bool[] poses = new bool[100001];//0~10000
            var posList = new List<int>();
            poses[0] = true;
            posList.Add(0);
            for(int i = 0; i < n; i++)
            {
                int cnt = posList.Count;
                for(int j = 0; j < cnt; j++)
                {
                    if (poses[posList[j] + ps[i]]) continue;
                    else
                    {
                        poses[posList[j] + ps[i]] = true;
                        posList.Add(posList[j] + ps[i]);
                    }
                }
            }
            Console.WriteLine(posList.Count);
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
