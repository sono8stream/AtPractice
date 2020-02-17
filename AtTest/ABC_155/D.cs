using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_155
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
            long[] nk = ReadLongs();
            int n = (int)nk[0];
            long k = nk[1];
            long[] array = ReadLongs();
            Array.Sort(array);

            long bottom = long.MinValue / 8;
            long top = long.MaxValue / 8;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                long cnt = 0;
                for (int i = 1; i < n; i++)
                {
                    int ok = array[i] < 0 ? i - 1 : 0;
                    int ng = array[i] < 0 ? -1 : i;
                    if (array[i] * array[ok] > mid)
                    {
                        continue;
                    }
                    while (Abs(ok - ng) > 1)
                    {
                        int mid2 = (ok + ng) / 2;
                        if (array[i] * array[mid2] <= mid)
                        {
                            ok = mid2;
                        }
                        else
                        {
                            ng = mid2;
                        }
                    }
                    cnt += array[i] < 0 ? i - ok : ok + 1;
                }
                if (cnt < k)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            WriteLine(top);
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
