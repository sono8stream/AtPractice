using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1358
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
            long[] nx = ReadLongs();
            int n = (int)nx[0];
            long x = nx[1];
            long[] ds = new long[2 * n];            
            long[] dsTmp = ReadLongs();
            for(int i = 0; i < n; i++)
            {
                ds[i] = dsTmp[i];
                ds[i + n] = dsTmp[i];
            }
            Array.Reverse(ds);
            n *= 2;
            long[] sums = new long[n];
            sums[0] = ds[0];
            for(int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + ds[i];
            }

            long[] rangeSums = new long[n];
            rangeSums[0] = ds[0] * (ds[0] + 1) / 2;
            for(int i = 1; i < n; i++)
            {
                rangeSums[i] = rangeSums[i - 1] + ds[i] * (ds[i] + 1) / 2;
            }

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                long tmp;
                if (x < ds[i])
                {
                    tmp = ds[i] * (ds[i] + 1) / 2;
                    long remain = ds[i] - x;
                    tmp -= remain * (remain + 1) / 2;
                }
                else
                {
                    int bottom = i;
                    int top = n;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        long cnt = sums[mid];
                        if (i > 0)
                        {
                            cnt -= sums[i - 1];
                        }

                        if (cnt <= x)
                        {
                            bottom = mid;
                        }
                        else
                        {
                            top = mid;
                        }
                    }
                    tmp = rangeSums[bottom];
                    if (i > 0)
                    {
                        tmp -= rangeSums[i - 1];
                    }
                    if (bottom + 1 < n) {
                        long xTmp = x - sums[bottom];
                        if (i > 0)
                        {
                            xTmp += sums[i - 1];
                        }
                        tmp += ds[bottom + 1] * (ds[bottom + 1] + 1) / 2;
                        long remain = ds[bottom + 1] - xTmp;
                        tmp -= remain * (remain + 1) / 2;
                    }
                }
                res = Max(res, tmp);
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
