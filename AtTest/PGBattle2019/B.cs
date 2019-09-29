using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.PGBattle2019
{
    class B
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
            int n = ReadInt();
            string s = Read();
            int remain = n % 2 == 0 ? n / 2 : n / 2 + 1;
            int lNow = 1;
            bool isHead = false;
            int rNow = n;
            bool[] sit = new bool[n];
            for (int i = 0; i < n; i++)
            {
                int pos = -1;
                if (s[i] == 'L')
                {
                    if (isHead)
                    {
                        while (sit[lNow-1]) lNow++;
                        pos = lNow;
                    }
                    else
                    {
                        pos = lNow;
                        remain--;
                        lNow += 2;
                    }
                }
                else
                {
                    if (isHead)
                    {
                        while (sit[rNow-1]) rNow--;
                        pos = rNow;
                    }
                    else
                    {
                        pos = rNow;
                        remain--;
                        rNow -= 2;
                    }
                }
                if (!isHead&&remain == 0)
                {
                    isHead = true;
                    lNow = 1;
                    rNow = n;
                }
                sit[pos-1] = true;
                WriteLine(pos);
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
