using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CF2015_MorningHard_A
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
            long[] array = ReadLongs();
            long[] sums = new long[n];
            sums[0] = array[0];
            for (int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + array[i];
            }
            long[] leftSums = new long[n];
            long[] rightSums = new long[n];
            leftSums[0] = array[0];
            for(int i = 1; i < n; i++)
            {
                leftSums[i] = leftSums[i - 1] + sums[i] + i;
            }
            rightSums[n - 1] = array[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rightSums[i] = rightSums[i + 1] + sums[n - 1] - sums[i] + array[i] + n - 1 - i;
            }

            long res = long.MaxValue;
            for(int i = 0; i < n; i++)
            {
                int fBlack = 0;
                int fWhite = 0;
                int bBlack = 0;
                int bWhite = 0;
                if (i % 2 == 0)
                {
                    fBlack = i / 2;
                    fWhite = i / 2;
                    bBlack = (n - 1 - i) / 2;
                    bWhite = (n - 1 - i + 1) / 2;
                }
                else
                {
                    fBlack = (i + 1) / 2;
                    fWhite = i / 2;
                    bBlack = (n - 1 - i + 1) / 2;
                    bWhite = (n - 1 - i) / 2;
                }

                if (fBlack + fWhite + bBlack + bWhite == n - 1 &&
                    fBlack + bBlack - fWhite - bWhite >= 0 &&
                    fBlack + bBlack - fWhite - bWhite <= 1)
                {
                    long val = 0;
                    if (i - 1 >= 0)
                    {
                        val += leftSums[i - 1];
                    }
                    if (i + 1 < n)
                    {
                        val += rightSums[i + 1];
                    }
                    res = Min(res, val);
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
