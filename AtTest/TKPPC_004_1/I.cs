using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class I
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            Array.Sort(aArray);
            Array.Sort(bArray);
            long[] lows = new long[n];
            long[] highs = new long[n];
            int bNow = 0;
            long mask = 1000000000 + 7;
            for (int i = 0; i < n; i++)
            {
                while (bNow < m && bArray[bNow] < aArray[i]) bNow++;

                lows[i] = bNow;
            }

            bNow = m - 1;
            for(int i = n - 1; i >= 0; i--)
            {
                while (bNow >= 0 && bArray[bNow] > aArray[i]) bNow--;

                highs[i] = m - 1 - bNow;
                if (i < n - 1)
                {
                    highs[i] += highs[i + 1];
                    highs[i] %= mask;
                }
            }

            long res = 0;
            for(int i = 0; i < n-1; i++)
            {
                res += lows[i] * highs[i + 1];
                res %= mask;
            }
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
