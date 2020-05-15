using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_166
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] hs = ReadInts();
            bool[] ok = new bool[n];
            for(int i = 0; i < n; i++)
            {
                ok[i] = true;
            }

            for (int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                if (hs[a] <= hs[b])
                {
                    ok[a] = false;
                }
                if (hs[b] <= hs[a])
                {
                    ok[b] = false;
                }
            }

            int res = 0;
            for(int i = 0; i < n; i++)
            {
                if (ok[i])
                {
                    res++;
                }
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
