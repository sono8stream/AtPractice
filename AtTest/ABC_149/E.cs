using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_149
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
            long[] nm = ReadLongs();
            long n = nm[0];
            long m = nm[1];
            long[] array = ReadLongs();
            Array.Sort(array);
            Array.Reverse(array);

            long bottom = 0;
            long top = 300000;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                long cnt = 0;
                for(int i = 0; i < n; i++)
                {
                    if (mid > array[i] + array[0]) continue;
                    long bottom2 = 0;
                    long top2 = n;
                    while (bottom2 + 1 < top2)
                    {
                        long mid2 = (bottom2 + top2) / 2;
                        if (array[i] + array[mid2] >= mid) bottom2 = mid2;
                        else top2 = mid2;
                    }
                    cnt += bottom2 + 1;
                }
                if (cnt >= m) bottom = mid;
                else top = mid;
            }

            long resCnt = 0;
            long res = 0;
            long[] sums = new long[n];
            for(int i = 0; i < n; i++)
            {
                sums[i] = array[i];
                if (i > 0) sums[i] += sums[i - 1];
            }
            for(int i = 0; i < n; i++)
            {
                if (bottom > array[i] + array[0]) continue;
                long bottom2 = 0;
                long top2 = n;
                while (bottom2 + 1 < top2)
                {
                    long mid2 = (bottom2 + top2) / 2;
                    if (array[i] + array[mid2] >= bottom) bottom2 = mid2;
                    else top2 = mid2;
                }
                resCnt += bottom2 + 1;
                res += sums[bottom2] + array[i] * (bottom2 + 1);
            }
            res -= (resCnt - m) * bottom;
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
