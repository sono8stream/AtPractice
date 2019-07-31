using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class J
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
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();
            long aSum = aArray.Sum();
            long bSum = bArray.Sum();

            int allM = 1 << m;
            List<long> bBs = new List<long>();
            for(int i = 1; i < allM; i++)
            {
                long tmp = 0;
                for(int j = 0; j < m; j++)
                {
                    if ((i & (1 << j)) > 0) tmp += bArray[j];
                }
                if (tmp * 2 >= bSum) continue;

                bBs.Add(tmp);
            }
            bBs.Sort();

            int allN = 1 << n;
            int max = 0;
            for(int i = 1; i < allN; i++)
            {
                long aB = 0;
                for(int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)aB += aArray[j];
                }
                if (aB * 2 >= aSum) continue;

                int bottom = 0;
                int top = bBs.Count;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    if (bBs[mid] < aB) bottom = mid;
                    else top = mid;
                }
                if (bBs[bottom] >= aB) continue;

                int higher = bottom;

                bottom = -1;
                top = bBs.Count - 1;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top + 1) / 2;
                    if (bSum + aB - aSum < bBs[mid]) top = mid;
                    else bottom = mid;
                }
                if (bSum + aB - aSum >= bBs[top]) continue;

                max = Max(max, higher - top + 1);
            }

            WriteLine(1.0 * max / bBs.Count);
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
