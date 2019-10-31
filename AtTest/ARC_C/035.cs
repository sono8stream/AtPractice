using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _035
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
            long[,] dists = new long[n,n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dists[i, j] = i == j ? 0 : long.MaxValue / 4;
                }
            }
            for(int i = 0; i < m; i++)
            {
                int[] abc = ReadInts();
                int a = abc[0] - 1;
                int b = abc[1] - 1;
                int c = abc[2];
                dists[a, b] = c;
                dists[b, a] = c;
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    for(int kk = 0; kk < n; kk++)
                    {
                        dists[j, kk] = Min(dists[j, kk], dists[j, i] + dists[i, kk]);
                    }
                }
            }
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    sum += dists[i, j];
                }
            }
            int k = ReadInt();
            for(int i = 0; i < k; i++)
            {
                int[] xyz = ReadInts();
                int x = xyz[0]-1;
                int y = xyz[1]-1;
                int z = xyz[2];
                long delta = 0;
                for (int s = 0; s < n; s++)
                {
                    for (int t = s + 1; t < n; t++)
                    {
                        long tmp1 = dists[s, x] + dists[y, t] + z;
                        long tmp2 = dists[s, y] + dists[x, t] + z;
                        long min = Min(tmp1, tmp2);
                        if (min < dists[s, t])
                        {
                            delta += dists[s, t] - min;
                            dists[s, t] = min;
                            dists[t, s] = min;
                        }
                    }
                }
                sum -= delta;
                WriteLine(sum);
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
