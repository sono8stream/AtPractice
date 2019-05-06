using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class ARC071_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            string t = Read();
            int q = ReadInt();
            bool[] res = new bool[q];
            int[] sSums = new int[s.Length];
            int[] tSums = new int[t.Length];

            for(int i=0;i<s.Length; i++)
            {
                sSums[i] = s[i] == 'A' ? 1 : 2;
                if (i > 0) sSums[i] += sSums[i - 1];
            }
            for (int i = 0; i < t.Length; i++)
            {
                tSums[i] = t[i] == 'A' ? 1 : 2;
                if (i > 0) tSums[i] += tSums[i - 1];
            }

            for (int i = 0; i < q; i++)
            {
                int[] abcd = ReadInts();
                int sVal = sSums[abcd[1] - 1];
                if (abcd[0] >= 2) sVal -= sSums[abcd[0] - 2];
                int tVal = tSums[abcd[3] - 1];
                if (abcd[2] >= 2) tVal -= tSums[abcd[2] - 2];
                res[i] = sVal % 3 == tVal % 3;
            }

            for(int i = 0; i < q; i++)
            {
                WriteLine(res[i] ? "YES" : "NO");
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
