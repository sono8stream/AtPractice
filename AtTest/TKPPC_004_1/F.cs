using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class F
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
            int[][] bridgeAs = new int[n][];
            int[][] bridgeBs = new int[n][];
            for (int i = 0; i < n; i++) bridgeAs[i] = ReadInts();
            for (int i = 0; i < n; i++) bridgeBs[i] = ReadInts();

            int now = 0;
            for (int i = 0; i < n; i++)
            {
                int minNext = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    int tmp = now;
                    if (tmp % bridgeAs[i][j] > 0)
                    {
                        tmp += bridgeAs[i][j] - tmp % bridgeAs[i][j];
                    }
                    tmp += bridgeBs[i][j];
                    minNext = Min(minNext, tmp);
                }
                now = minNext;
            }
            WriteLine(now);
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
