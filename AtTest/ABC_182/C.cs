using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_182
{
    class C
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int all = 1 << s.Length;
            bool can = false;
            int res = 1000;
            for (int i = 0; i < all; i++)
            {
                int val = 0;
                int cnt = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        val += s[j] - '0';
                        cnt++;
                    }
                }

                if (val % 3 == 0 && cnt > 0)
                {
                    can = true;
                    res = Min(res, s.Length - cnt);
                }
            }

            if (can)
            {
                WriteLine(res);
            }
            else
            {
                WriteLine(-1);
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
