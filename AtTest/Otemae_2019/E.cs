using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Otemae_2019
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[] ds = new int[n];
            long[] dSums = new long[n];
            for(int i = 0; i < n; i++)
            {
                ds[i] = ReadInt();
                dSums[i] = ds[i];
                if (i > 0) dSums[i] += dSums[i - 1];
            }

            int[][] tlrs = new int[q][];
            for(int i = 0; i < q; i++)
            {
                tlrs[i] = ReadInts();
            }

            for(int i = 0; i < q; i++)
            {
                int t = tlrs[i][0];
                int l = tlrs[i][1];
                int r = tlrs[i][2];

                int bottom = -1;
                int top = n;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    long pos = Max(t - dSums[mid], -mid - 1);

                    if (pos<=r)
                    {
                        top = mid;
                    }
                    else
                    {
                        bottom = mid;
                    }
                }
                int right = top;

                bottom = -1;
                top = n;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    long pos = Max(t - dSums[mid], -mid - 1);

                    if (pos >= l)
                    {
                        bottom = mid;
                    }
                    else
                    {
                        top = mid;
                    }
                }
                int left = bottom;

                int res = l <= t && t <= r ? 1 : 0;

                if (right == n || left == -1)
                {

                }
                else
                {
                    res += left - right + 1;
                }

                WriteLine(res);
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
