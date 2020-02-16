using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _037
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[] arrayA = ReadLongs();
            long[] arrayB = ReadLongs();
            Array.Sort(arrayA);
            Array.Sort(arrayB);
            long bottom = 0;
            long top = long.MaxValue / 2;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                int cnt = 0;
                for(int i = 0; i < n; i++)
                {
                    if (arrayA[i] * arrayB[0] > mid)
                    {
                        continue;
                    }

                    int bottom2 = 0;
                    int top2 = n;
                    while (bottom2 + 1 < top2)
                    {
                        int mid2 = (bottom2 + top2) / 2;
                        if (arrayA[i] * arrayB[mid2] <= mid)
                        {
                            bottom2 = mid2;
                        }
                        else
                        {
                            top2 = mid2;
                        }
                    }
                    cnt += bottom2 + 1;
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

            long res = long.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (arrayA[i] * arrayB[n - 1] <= bottom)
                {
                    continue;
                }
                int bottom2 = -1;
                int top2 = n-1;
                while (bottom2 + 1 < top2)
                {
                    int mid2 = (bottom2 + top2) / 2;
                    if (arrayA[i] * arrayB[mid2] <= bottom)
                    {
                        bottom2 = mid2;
                    }
                    else
                    {
                        top2 = mid2;
                    }
                }
                res = Min(res, arrayA[i] * arrayB[top2]);
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
