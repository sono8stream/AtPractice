using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1461
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
            int t = ReadInt();
            for(int i=0; i < t; i++)
            {
                int[] nq = ReadInts();
                int n = nq[0];
                int q = nq[1];
                long[] array = ReadLongs();
                Array.Sort(array);
                long[] sums = new long[n];
                for(int j = 0; j < n; j++)
                {
                    sums[j] = array[j];
                    if (j > 0)
                    {
                        sums[j] += sums[j - 1];
                    }
                }

                var vals = new HashSet<long>();
                FindAllValues(vals,array, sums, 0, n - 1);
                for(int j = 0; j < q; j++)
                {
                    long val = ReadLong();
                    WriteLine(vals.Contains(val) ? "Yes" : "No");
                }
            }
        }

        static void FindAllValues(HashSet<long>vals, long[] array,long[] sums,int left,int right)
        {
            long sum = sums[right];
            if (left > 0)
            {
                sum -= sums[left - 1];
            }
            vals.Add(sum);

            if (array[left] == array[right])
            {
                return;
            }

            long target = (array[left] + array[right]) / 2;
            int bottom = left;
            int top = right;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                if (array[mid] <= target)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            FindAllValues(vals, array, sums, left, bottom);
            FindAllValues(vals, array, sums, bottom + 1, right);
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
