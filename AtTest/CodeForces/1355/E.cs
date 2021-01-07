using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1355
{
    class E
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
            int[] narm = ReadInts();
            int n = narm[0];
            long a = narm[1];
            long r = narm[2];
            long m = narm[3];
            m = Min(m, a + r);
            long[] array = ReadLongs();
            Array.Sort(array);
            if (n == 1)
            {
                WriteLine(0);
                return;
            }

            long totalSum = array.Sum();
            long res = Min((totalSum - array[0] * n) * r, (array[n - 1] * n - totalSum) * a);
            long bottom = array[0];
            long top = int.MaxValue;
            while (bottom + 1 < top)
            {
                long mid = (bottom + top) / 2;
                long tmpSum = 0;
                long left = 0;
                for (int i = 0; i < n; i++)
                {
                    if (array[i] > mid)
                    {
                        break;
                    }

                    tmpSum += array[i];
                    left = i + 1;
                }
                long otherSum = totalSum - tmpSum;
                long right = n - left;
                long val = mid * left - tmpSum - (otherSum - mid * right);
                if (val <= 0)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            {
                res = Min(res, GetScore(bottom - 1, array, totalSum, a, r, m));
                res = Min(res, GetScore(bottom, array, totalSum, a, r, m));
                res = Min(res, GetScore(bottom + 1, array, totalSum, a, r, m));
            }

            WriteLine(res);
        }

        static long GetScore(long bottom,long[] array,long totalSum,long a,long r,long m)
        {
            long tmpSum = 0;
            long left = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > bottom)
                {
                    break;
                }

                tmpSum += array[i];
                left = i + 1;
            }
            long otherSum = totalSum - tmpSum;
            long right = array.Length - left;
            long leftCnt = bottom * left - tmpSum;
            long rightCnt = otherSum - bottom * right;
            if (leftCnt < rightCnt)
            {
                return leftCnt * m + (rightCnt - leftCnt) * r;
            }
            else
            {
                return rightCnt * m + (leftCnt - rightCnt) * a;
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
