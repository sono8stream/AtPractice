using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_188
{
    class D
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
            int[] nc = ReadInts();
            int n = nc[0];
            long c = nc[1];
            int[][] abcs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abcs[i] = ReadInts();
            }

            var sortedMap = new SortedDictionary<int,long>();
            for(int i = 0; i < n; i++)
            {
                if (!sortedMap.ContainsKey(abcs[i][0]))
                {
                    sortedMap.Add(abcs[i][0], 0);
                }
                sortedMap[abcs[i][0]] += abcs[i][2];

                if (!sortedMap.ContainsKey(abcs[i][1] + 1))
                {
                    sortedMap.Add(abcs[i][1] + 1, 0);
                }
                sortedMap[abcs[i][1] + 1] -= abcs[i][2];
            }

            long res = 0;
            long sum = 0;
            int prevTiming = -1;
            foreach(int key in sortedMap.Keys)
            {
                if (prevTiming>0)
                {
                    long length = key - prevTiming;
                    res += length * Min(sum, c);
                }
                sum += sortedMap[key];
                prevTiming = key;
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
