using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC111
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
            int n = ReadInt();
            int[] vs = ReadInts();
            int[][] evenCnts = new int[100005][];
            int[][] oddCnts = new int[100005][];
            for (int i = 0; i < 100005; i++)
            {
                evenCnts[i] = new int[2] { 0, i };
                oddCnts[i] = new int[2] { 0, i };
            }
            for (int i = 0; i < n; i += 2)
            {
                evenCnts[vs[i]][0]++;
            }
            for (int i = 1; i < n; i += 2)
            {
                oddCnts[vs[i]][0]++;
            }
            Array.Sort(evenCnts, (a, b) => b[0] - a[0]);
            Array.Sort(oddCnts, (a, b) => b[0] - a[0]);
            if (evenCnts[0][1] == oddCnts[0][1])
            {
                WriteLine(Min(n - evenCnts[0][0] - oddCnts[1][0],
                    n - evenCnts[1][0] - oddCnts[0][0]));
            }
            else
            {
                WriteLine(n - evenCnts[0][0] - oddCnts[0][0]);
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
