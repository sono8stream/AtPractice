using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_181
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            long[] hs = ReadLongs();
            long[] ws = ReadLongs();
            Array.Sort(hs);
            Array.Sort(ws);

            long[] oddSums = new long[n];
            long[] evenSums = new long[n];
            for(int i = 1; i < n; i++)
            {
                oddSums[i] = oddSums[i - 1];
                evenSums[i] = evenSums[i - 1];
                if (i % 2 == 1)
                {
                    evenSums[i] += hs[i] - hs[i - 1];
                }
                else
                {
                    oddSums[i] += hs[i] - hs[i - 1];
                }
            }

            int now = 0;
            long res = long.MaxValue;
            for (int i = 0; i < m; i++)
            {
                long tmp = 0;
                if (ws[i] < hs[0])
                {
                    tmp = hs[0] - ws[i] + oddSums[n - 1];
                }
                else if (ws[i] >= hs[n - 1])
                {
                    tmp = ws[i] - hs[n - 1];
                    tmp += evenSums[n - 1];
                }
                else
                {
                    int bottom = 0;
                    int top = n - 1;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        if (hs[mid] <= ws[i])
                        {
                            bottom = mid;
                        }
                        else
                        {
                            top = mid;
                        }
                    }

                    if (bottom % 2 == 1)
                    {
                        tmp = evenSums[bottom] + hs[bottom + 1] - ws[i]
                            + oddSums[n - 1] - oddSums[bottom + 1];
                    }
                    else
                    {
                        tmp = evenSums[bottom] + ws[i] - hs[bottom]
                            + oddSums[n - 1] - oddSums[bottom];
                    }
                }
                res = Min(res, tmp);
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
