using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1379
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
            int[] nhmk = ReadInts();
            int n = nhmk[0];
            int h = nhmk[1];
            int m = nhmk[2];
            int k = nhmk[3];

            int[][] ms = new int[n * 2][];
            for (int i = 0; i < n; i++)
            {
                int val = ReadInts()[1];
                ms[i] = new int[2] { val, i };
                ms[i + n] = new int[2] { val + m, i };
            }
            Array.Sort(ms, (a, b) => a[0] - b[0]);

            long res = long.MaxValue;
            int idx = 0;
            for (int i = 0; i < n; i++)
            {
                long left = BinarySearch(ms, ms[i][0] + k - 1);
                long right1 = BinarySearch(ms, ms[i][0] + m / 2);
                long right2 = BinarySearch(ms, ms[i][0] + m / 2 + k - 1);

                long tmp = left - i + right2 - right1;
                if (tmp < res)
                {
                    res = tmp;
                    idx = i;
                }
            }

            WriteLine(res + " " + (ms[idx][0] + k) % (m / 2));
            if (res > 0)
            {
                for (int i = idx + 1; i < 2 * n; i++)
                {
                    if (ms[i][0] < ms[idx][0] + k
                        || (ms[i][0] > ms[idx][0] + m / 2
                        && ms[i][0] < ms[idx][0] + m / 2 + k))
                    {
                        Write((ms[i][1] + 1) + " ");
                    }
                }
                WriteLine();
            }
        }

        static int BinarySearch(int[][] ms,int target)
        {
            int bottom = 0;
            int top = ms.Length;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top)/2;
                if (ms[mid][0] <= target)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }

            return bottom;
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
