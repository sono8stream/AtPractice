using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_031
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            long mask = 1000000000 + 7;
            long n = ReadLong();
            string s = Read();
            long[] cnts = new long[26];
            for (int i = 0; i < 26; i++) cnts[i] = 1;
            for(int i = 0; i < n; i++)
            {
                cnts[s[i] - 'a']++;
            }
            long res = 1;
            for(int i = 0; i < 26; i++)
            {
                res *= cnts[i];
                res %= mask;
            }
            WriteLine(res - 1);
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
