using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_111
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
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            int[] pArray = ReadInts();
            for(int i = 0; i < n; i++)
            {
                int idx = pArray[i] - 1;
                if (idx != i && bArray[idx] >= aArray[i])
                {
                    WriteLine(-1);
                    return;
                }
            }

            int[] haves = new int[n];
            int[] poses = new int[n];
            int[][] sorted = new int[n][];
            for(int i = 0; i < n; i++)
            {
                haves[i] = pArray[i] - 1;
                sorted[i] = new int[2] { aArray[i], i };
                poses[pArray[i] - 1] = i;
            }
            Array.Sort(sorted, (a, b) => a[0] - b[0]);

            int res = 0;
            List<int[]> oprs = new List<int[]>();
            for(int i = 0; i < n; i++)
            {
                int idx = sorted[i][1];
                if (idx != haves[idx])
                {
                    int to = poses[idx];
                    int haveIdx = haves[idx];
                    haves[idx] = idx;
                    haves[to] = haveIdx;
                    poses[haveIdx] = to;
                    res++;
                    oprs.Add(new int[2] { idx, to });
                }
            }

            WriteLine(res);
            for(int i = 0; i < oprs.Count; i++)
            {
                WriteLine((oprs[i][0] + 1) + " " + (oprs[i][1] + 1));
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
