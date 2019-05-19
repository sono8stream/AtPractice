using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1166
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();

            int cCnt = 26;
            int[] cnts = new int[cCnt];
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                cnts[s[0] - 'a']++;
            }

            int res = 0;
            for(int i = 0; i < cCnt; i++)
            {
                int first = cnts[i] / 2;
                int second = cnts[i] / 2;
                if (cnts[i] % 2 > 0) second++;

                res += first * (first - 1) / 2;
                res += second * (second - 1) / 2;
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
