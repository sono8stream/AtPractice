using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_172
{
    class C
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            long k = nmk[2];

            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();

            long[] aSums = new long[n + 1];
            for (int i = 0; i < n; i++)
            {
                aSums[i + 1] = aArray[i];
                aSums[i + 1] += aSums[i];
            }

            long[] bSums = new long[m + 1];
            for (int i = 0; i < m; i++)
            {
                bSums[i + 1] = bArray[i];
                bSums[i + 1] += bSums[i];
            }

            int bI = m;
            int res = 0;
            for(int i = 0; i <= n; i++)
            {
                while (bI > 0 && aSums[i] + bSums[bI] > k)
                {
                    bI--;
                }

                if (aSums[i] + bSums[bI] > k)
                {
                    break;
                }

                res = Max(res, i + bI);
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
