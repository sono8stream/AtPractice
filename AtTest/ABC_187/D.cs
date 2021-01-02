using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_187
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
            int n = ReadInt();
            long[][] abs = new long[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadLongs();
            }

            long sum = 0;
            long[] deltas = new long[n];
            for(int i = 0; i < n; i++)
            {
                sum -= abs[i][0];
                deltas[i] = abs[i][0] * 2 + abs[i][1];
            }
            Array.Sort(deltas);
            Array.Reverse(deltas);
            for(int i = 0; i < n; i++)
            {
                if (sum > 0)
                {
                    WriteLine(i);
                    return;
                }

                sum += deltas[i];
            }
            WriteLine(n);
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
