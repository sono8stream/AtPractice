﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_048
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            bool firstWin = false;
            if (s[0] == s[s.Length - 1])
            {//奇数になるほうが負け
                firstWin = s.Length % 2 == 0;
            }
            else
            {
                firstWin = s.Length % 2 == 1;
            }
            if (firstWin)
            {
                Console.WriteLine("First");
            }
            else
            {
                Console.WriteLine("Second");
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
