using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1462
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[][] lrsLeftSort = new int[n][];
                int[][] lrsRightSort = new int[n][];
                // l, r, idx
                for (int j = 0; j < n; j++)
                {
                    int[] lr = ReadInts();
                    lrsLeftSort[j] = new int[3] { lr[0], lr[1], j };
                    lrsRightSort[j] = new int[3] { lr[0], lr[1], j };
                }
                int[] res = new int[n];

                Array.Sort(lrsLeftSort, (a, b) => a[0] - b[0]);
                Array.Sort(lrsRightSort, (a, b) => a[1] - b[1]);

                int now = -1;
                for (int j = 0; j < n; j++)
                {
                    while (now + 1 < n && lrsRightSort[now + 1][1] < lrsLeftSort[j][0])
                    {
                        now++;
                    }

                    res[lrsLeftSort[j][2]] += now + 1;
                }

                Array.Sort(lrsLeftSort, (a, b) => b[0] - a[0]);
                Array.Sort(lrsRightSort, (a, b) => b[1] - a[1]);
                now = -1;
                for(int j = 0; j < n; j++)
                {
                    while (now + 1 < n && lrsLeftSort[now + 1][0] > lrsRightSort[j][1])
                    {
                        now++;
                    }

                    res[lrsRightSort[j][2]] += now + 1;
                }

                WriteLine(res.Min());
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
