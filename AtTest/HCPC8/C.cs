using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC8
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            int commaCnt = 0;
            int colonCnt = 0;
            int nest = 0;
            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == '{') nest++;
                if (s[i] == '}') nest--;
                if (nest > 0) continue;

                if (s[i] == ',')
                {
                    WriteLine("set");
                    return;
                }
                if (s[i] == ':')
                {
                    WriteLine("dict");
                    return;
                }
            }
            if (s.Length == 2)
            {
                WriteLine("dict");
            }
            else
            {
                WriteLine("set");
            }
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
