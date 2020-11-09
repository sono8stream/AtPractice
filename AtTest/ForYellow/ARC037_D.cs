using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC037_D
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
            int l = ReadInt();

            long mask = 1000000000 + 7;
            long[] alls = new long[l + 1];
            long[] oneEdges = new long[l + 1];
            long[] oneEdgeTops = new long[l + 1];
            long[] twoEdges = new long[l + 1];
            long[] twoEdgeTops = new long[l + 1];
            alls[0] = 1;
            oneEdges[0] = 2;
            oneEdgeTops[0] = 1;
            twoEdges[0] = 2;
            twoEdgeTops[0] = 1;

            for (int i = 1; i <= l; i++)
            {
                alls[i] = alls[i - 1] * 3 % mask;
                alls[i] += oneEdges[i - 1] * oneEdges[i - 1] % mask * oneEdges[i - 1] % mask;
                alls[i] %= mask;

                long haveTops = 2 * twoEdges[i - 1] * twoEdgeTops[i - 1] % mask;
                haveTops += mask - twoEdgeTops[i - 1] * twoEdgeTops[i - 1] % mask;
                oneEdges[i] = oneEdges[i - 1] * oneEdges[i - 1] % mask;
                oneEdges[i] += haveTops * oneEdges[i - 1] % mask;
                oneEdges[i] %= mask;

                oneEdgeTops[i] = haveTops * oneEdgeTops[i - 1] % mask;
                oneEdgeTops[i] %= mask;

                long other = oneEdges[i - 1] * oneEdges[i - 1] % mask;
                other += mask - oneEdgeTops[i - 1] * oneEdgeTops[i - 1] % mask;
                other %= mask;
                twoEdges[i] = twoEdges[i - 1] * other % mask
                    + twoEdges[i - 1] * twoEdges[i - 1] % mask;
                twoEdges[i] %= mask;

                twoEdgeTops[i] = twoEdgeTops[i - 1] * other % mask
                    + twoEdges[i - 1] * twoEdges[i - 1] % mask;
                twoEdgeTops[i] %= mask;
            }

            WriteLine(alls[l]);
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
