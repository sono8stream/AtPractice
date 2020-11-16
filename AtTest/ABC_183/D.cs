using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_183
{
    class D
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
            int[] nw = ReadInts();
            int n = nw[0];
            long w = nw[1];

            long[] deltas = new long[3*100000];
            for(int i = 0; i < n; i++)
            {
                long[] stp = ReadLongs();
                long s = stp[0];
                long t = stp[1];
                long p = stp[2];
                deltas[s] += p;
                deltas[t] -= p;
            }

            long tmp = 0;
            for(int i = 0; i < 3 * 100000; i++)
            {
                tmp += deltas[i];
                if (tmp > w)
                {
                    WriteLine("No");
                    return;
                }
            }

            WriteLine("Yes");
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
