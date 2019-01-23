﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeForces._535
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
            int n = ReadInt();
            char[] lamps = Read().ToCharArray();
            char[] pat = new char[3] { 'R', 'G', 'B' };
            int cnt = 0;
            for(int i = 1; i < n; i++)
            {
                if (lamps[i] == lamps[i - 1])
                {
                    cnt++;
                    for(int j = 0; j < 3; j++)
                    {
                        if (lamps[i - 1] == pat[j]) continue;
                        if (i < n - 1 && lamps[i +1] == pat[j]) continue;
                        lamps[i] = pat[j];
                        break;
                    }
                }
            }
            Console.WriteLine(cnt);
            Console.WriteLine(lamps);
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
