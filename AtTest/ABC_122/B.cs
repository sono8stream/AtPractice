using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_122
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int max = 0;
            for(int i = 0; i < s.Length; i++)
            {
                int len = 0;
                for(int j = i; j < s.Length; j++)
                {
                    if (s[j] == 'A' || s[j] == 'C'
                        || s[j] == 'G' || s[j] == 'T')
                    {
                        len++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                max = Max(max, len);
            }
            WriteLine(max);
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
