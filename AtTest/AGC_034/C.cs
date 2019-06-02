using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_034
{
    class C
    {
        static void Main(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nx = ReadInts();
            long n = nx[0];
            long x = nx[1];

            long[][] blus = new long[n][];
            for (int i = 0; i < n; i++) blus[i] = ReadLongs();
            blus = blus.OrderBy(a => -(x - a[0]) * a[2]).ToArray();

            long mySum = 0;
            long otherSum = 0;
            for(int i = 0; i < n; i++)
            {
                otherSum += blus[i][0] * blus[i][1];
            }

            int unusedIndex = 0;
            for (; unusedIndex < n; unusedIndex++)
            {
                if (mySum + x * blus[unusedIndex][2]
                    > otherSum + blus[unusedIndex][0] *
                    (blus[unusedIndex][2]-blus[unusedIndex][1]))
                {
                    break;
                }

                mySum += x * blus[unusedIndex][2];
                otherSum += blus[unusedIndex][0]
                    * (blus[unusedIndex][2] - blus[unusedIndex][1]);
            }

            long res = unusedIndex * 100;
            List<long[]> remain = new List<long[]>();
            for(int i = unusedIndex; i < n; i++)
            {
                remain.Add(blus[i]);
            }

            long bottom = -1;
            long top = x;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top + 1) / 2;

                long max = 0;
                long delta = 0;
                for(int i = 0; i < remain.Count; i++)
                {
                    if (max <= mid * remain[i][2])
                    {
                        max = Max(max, mid * remain[i][2]);
                        delta = remain[i][0] * (remain[i][2] - remain[i][1]);
                    }
                }

                if (mySum + max >= otherSum + delta)
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }

            WriteLine(res + top);
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
