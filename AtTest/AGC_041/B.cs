using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_041
{
    class B
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
            long[] nmvp = ReadLongs();
            long n = nmvp[0];
            long m = nmvp[1];
            long v = nmvp[2];
            long p = nmvp[3];
            long[] array = ReadLongs();
            Array.Sort(array);
            Array.Reverse(array);
            List<long[]> blocks = new List<long[]>();
            blocks.Add(new long[2] { array[0], 1 });
            for(int i = 1; i < n; i++)
            {
                int prev = blocks.Count - 1;
                if (blocks[prev][0] == array[i])
                {
                    blocks[prev][1]++;
                }
                else
                {
                    blocks.Add(new long[2] { array[i], 1 });
                }
            }
            long[] cntSums = new long[blocks.Count];
            cntSums[0] = blocks[0][1];
            for(int i = 1; i < blocks.Count; i++)
            {
                cntSums[i] = cntSums[i - 1] + blocks[i][1];
            }
            int bottom = 0;
            int top = blocks.Count;
            while (bottom + 1 < top)
            {
                int middle = (bottom + top) / 2;
                long remain = v - (p - 1) - (n - cntSums[middle - 1]);
                long value = blocks[middle][0] + m;
                if (array[p - 1] > value)
                {
                    top = middle;
                    continue;
                }
                if (remain <= 0)
                {
                    bottom = middle;
                    continue;
                }
                remain *= m;
                for (long i = p - 1; i < cntSums[middle - 1]; i++)
                {
                    long delta = Min(value - array[i], m);
                    remain -= delta;
                    if (remain <= 0) break;
                }
                if (remain <= 0)
                {
                    bottom = middle;
                }
                else
                {
                    top = middle;
                }
            }
            WriteLine(cntSums[bottom]);
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
