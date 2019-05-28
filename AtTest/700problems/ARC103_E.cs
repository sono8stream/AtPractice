using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC103_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            int n = s.Length;
            if (s[n - 1] == '1' || s[0] == '0')
            {
                WriteLine(-1);
                return;
            }

            //check pair
            for (int i = 0; i < (n - 1) / 2; i++)
            {
                if ((s[i] != s[n - 2 - i]))
                {
                    WriteLine(-1);
                    return;
                }
            }

            int now = 1;
            int last = -1;
            for(int i = 1; i < n - 2; i++)
            {
                if (s[i] == '0') continue;

                if (last >= 0)
                {
                    WriteLine((last + 1) + " " + (i + 1));
                }

                for (int j = last+1; j < i; j++)
                {
                    WriteLine((j + 1) + " " + (i + 1));
                }

                last = i;
            }

            if (last >= 0)
            {
                WriteLine((last + 1) + " " + n);
            }

            for (int j = last + 1; j < n-1; j++)
            {
                WriteLine((j + 1) + " " + n);
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
