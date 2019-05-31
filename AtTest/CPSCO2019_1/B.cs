using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CPSCO2019_1
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            int[] cnts = new int[26];
            for (int i = 0; i < s.Length; i++) cnts[s[i] - 'a']++;

            int min = int.MaxValue;
            int max = 0;
            for(int i = 0; i < 26; i++)
            {
                if (cnts[i] == 0) continue;

                min = Min(min, cnts[i]);
                max = Max(max, cnts[i]);
            }

            WriteLine(min == max ? "Yes" : "No");
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
