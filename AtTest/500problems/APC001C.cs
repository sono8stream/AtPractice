using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class APC001C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            WriteLine(0);
            string s = Read();
            if (s[0] == 'V') return;
            char first = s[0];
            WriteLine(n - 1);
            string l = Read();
            if (l[0] == 'V') return;
            int bottom = 0;
            int top = n - 1;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                WriteLine(mid);
                string now = Read();
                if (now[0] == 'V') return;

                if ((mid % 2 == 0 && now[0] == first)
                    || (mid % 2 == 1 && now[0] != first))
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
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
