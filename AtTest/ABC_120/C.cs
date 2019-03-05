using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_120
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int rCnt = 0;
            int bCnt = 0;
            int res = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (bCnt > 0)
                    {
                        bCnt--;
                        res += 2;
                    }
                    else
                    {
                        rCnt++;
                    }
                }
                else
                {
                    if (rCnt > 0)
                    {
                        rCnt--;
                        res += 2;
                    }
                    else
                    {
                        bCnt++;
                    }
                }
            }
            WriteLine(res);
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
