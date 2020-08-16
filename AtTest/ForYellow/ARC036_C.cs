using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC036_C
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            string s = Read();

            long[,] vals = new long[k + 1, k + 1];
            vals[0, 0] = 1;
            long mask = 1000000000 + 7;
            for (int i = 0; i < n; i++)
            {
                long[,] next = new long[k + 1, k + 1];
                for (int l = 0; l <= k; l++)
                {
                    for (int r = 0; r <= k; r++)
                    {
                        if (l < k && (s[i] == '0' || s[i] == '?'))
                        {
                            next[l + 1, Max(r - 1, 0)] += vals[l, r];
                            next[l + 1, Max(r - 1, 0)] %= mask;
                        }
                        if (r < k && (s[i] == '1' || s[i] == '?'))
                        {
                            next[Max(l - 1, 0), r + 1] += vals[l, r];
                            next[Max(l - 1, 0), r + 1] %= mask;
                        }
                    }
                }
                vals = next;
            }

            long res = 0;
            for(int l = 0; l <= k; l++)
            {
                for(int r = 0; r <= k; r++)
                {
                    res += vals[l, r];
                    res %= mask;
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
