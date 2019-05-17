using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.diverta2019
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
            string[] ss = new string[n];
            for (int i = 0; i < n; i++) ss[i] = Read();

            int res = 0;
            int lastAcnt = 0;
            int firstBcnt = 0;
            int baCnt = 0;
            for(int i = 0; i < n; i++)
            {
                bool nowA = false;
                for(int j = 0; j < ss[i].Length; j++)
                {
                    if (nowA && ss[i][j] == 'B') res++;
                    nowA = ss[i][j] == 'A';
                }

                if (ss[i][0] == 'B' && ss[i][ss[i].Length - 1] == 'A') baCnt++;
                else if (ss[i][0] == 'B') firstBcnt++;
                else if (ss[i][ss[i].Length - 1] == 'A') lastAcnt++;
            }

            if (baCnt > 0)
            {
                if (lastAcnt > 0)
                {
                    res++;
                    lastAcnt--;
                }
                res += baCnt - 1;
                baCnt = 1;
            }
            res += Min(lastAcnt + baCnt, firstBcnt);
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
