using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_2020_Day1
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];

            int[][] lks = new int[q][];
            long[] deltas = new long[n + 1];
            for (int i = 0; i < q; i++)
            {
                lks[i] = ReadInts();
                lks[i][0]--;
                deltas[lks[i][0]]++;
                deltas[lks[i][0] + lks[i][1]]--;
            }

            for (int i =1; i <= n; i++)
            {
                deltas[i] += deltas[i - 1];
            }
            for(int i = 0; i < q; i++)
            {
                deltas[lks[i][0] + lks[i][1]] -= lks[i][1];
            }

            long now = 0;
            for (int i = 0; i < n; i++)
            {
                now += deltas[i];

                Write(now);
                if (i + 1 < n)
                {
                    Write(" ");
                }
            }
            WriteLine();
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
