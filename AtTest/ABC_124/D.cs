using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_124
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            string s = Read();
            List<int> cnts = new List<int>();
            if (s[0] == '0') cnts.Add(0);
            cnts.Add(1);
            for (int i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    cnts[cnts.Count - 1]++;
                }
                else
                {
                    cnts.Add(1);
                }
            }
            if (s[n - 1] == '0') cnts.Add(0);
            int sum = 0;
            if (cnts.Count <= 2*k+1)
            {
                for(int i = 0; i < cnts.Count; i++)
                {
                    sum += cnts[i];
                }
                WriteLine(sum);
                return;
            }
            for (int i = 0; i <  2 * k + 1; i++)
            {
                sum += cnts[i];
            }
            int res = sum;
            for (int i = 2; i + 2 * k < cnts.Count; i += 2)
            {
                sum -= cnts[i - 2] + cnts[i - 1];
                sum += cnts[i + 2 * k - 1] + cnts[i + 2 * k];
                res = Max(res, sum);
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
