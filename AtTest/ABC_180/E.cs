using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_180
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
            int[][] xyzs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xyzs[i] = ReadInts();
            }

            int all = 1 << n;
            int[,] dists = new int[all, n];
            for(int i = 0; i < all; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dists[i, j] = int.MaxValue / 4;
                }
            }
            dists[1, 0] = 0;

            for(int i = 2; i < all; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    if ((i & (1 << j)) == 0)
                    {
                        continue;
                    }

                    for(int k = 0; k < n; k++)
                    {
                        if (j == k || (i & (1 << k)) == 0)
                        {
                            continue;
                        }

                        int delta = Abs(xyzs[j][0] - xyzs[k][0])
                            + Abs(xyzs[j][1] - xyzs[k][1])
                            + Max(0, xyzs[j][2] - xyzs[k][2]);
                        int nextDist = dists[i - (1 << j), k] + delta;
                        if (i == all - 1)
                        {
                            nextDist += Abs(xyzs[0][0] - xyzs[j][0])
                            + Abs(xyzs[0][1] - xyzs[j][1])
                            + Max(0, xyzs[0][2] - xyzs[j][2]);
                        }
                        dists[i, j] = Min(dists[i, j], nextDist);
                    }
                }
            }

            int res = int.MaxValue;
            for(int i = 0; i < n; i++)
            {
                res = Min(res, dists[all - 1, i]);
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
