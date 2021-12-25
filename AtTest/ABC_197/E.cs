using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_197
{
    class E
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
            long[] mins = new long[n];
            long[] maxs = new long[n];
            for(int i = 0; i < n; i++)
            {
                mins[i] = long.MaxValue;
                maxs[i] = long.MinValue;
            }

            for(int i = 0; i < n; i++)
            {
                int[] xc = ReadInts();
                int c = xc[1] - 1;
                mins[c] = Min(mins[c], xc[0]);
                maxs[c] = Max(maxs[c], xc[0]);
            }

            long[,] dists = new long[n, 2];
            int prev = -1;
            for(int i = 0; i < n; i++)
            {
                if (mins[i] == long.MaxValue)
                {
                    continue;
                }

                if (prev == -1)
                {
                    dists[i, 0] = Abs(maxs[i]) + (maxs[i] - mins[i]);
                    dists[i, 1] = Abs(mins[i]) + (maxs[i] - mins[i]);
                }
                else
                {
                    long nearMin = Min(Abs(mins[i] - mins[prev]) + dists[prev, 0], Abs(mins[i] - maxs[prev]) + dists[prev, 1]);
                    long nearMax = Min(Abs(maxs[i] - mins[prev]) + dists[prev, 0], Abs(maxs[i] - maxs[prev]) + dists[prev, 1]);

                    dists[i, 0] = (maxs[i] - mins[i]) + nearMax;
                    dists[i, 1] = (maxs[i] - mins[i]) + nearMin;
                }
                prev = i;
            }

            long res = Min(Abs(mins[prev]) + dists[prev, 0], Abs(maxs[prev]) + dists[prev, 1]);
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
