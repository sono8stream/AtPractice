using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Tenka1_2019
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s = Read();
            int[] blackCnt = new int[n];
            blackCnt[n - 1] = s[n - 1] == '#' ? 1 : 0;

            for (int i = n-2; i>=0; i--)
            {
                blackCnt[i] = blackCnt[i + 1];
                if (s[i] == '#') blackCnt[i]++;
            }
            int res = int.MaxValue;
            for(int i = n - 1; i >= 0; i--)
            {
                int tmp = blackCnt[0] - blackCnt[i];
                tmp += n - i - blackCnt[i];
                res = Min(res, tmp);
            }
            res = Min(res, blackCnt[0]);
            WriteLine(res);
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
