using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CF_0837
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
            int[] nab = ReadInts();
            int n = nab[0];
            int a = nab[1];
            int b = nab[2];
            int[][] xys = new int[n][];
            for (int i = 0; i < n; i++)
            {
                xys[i] = ReadInts();
            }
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int x1 = xys[i][0];
                    int y1 = xys[i][1];
                    int x2 = xys[j][0];
                    int y2 = xys[j][1];
                    if ((x1 + x2 <= a && Max(y1, y2) <= b)
                        || (x1 + x2 <= b && Max(y1, y2) <= a)
                        || (Max(x1, x2) <= a && y1 + y2 <= b)
                        || (Max(x1, x2) <= b && y1 + y2 <= a)
                        || (x1 + y2 <= a && Max(y1, x2) <= b)
                        || (x1 + y2 <= b && Max(y1, x2) <= a)
                        || (Max(x1, y2) <= a && y1 + x2 <= b)
                        || (Max(x1, y2) <= b && y1 + x2 <= a))
                    {
                        res = Max(res, x1 * y1 + x2 * y2);
                    }
                }
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
