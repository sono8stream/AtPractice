using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Aising2018
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[] array = ReadInts();
            int[][] xs = new int[q][];
            for(int i = 0; i < q; i++)
            {
                xs[i] = new int[2] { ReadInt(), i };
            }
            Array.Sort(xs, (a, b) => b[0] - a[0]);
            var crossSums = new long[n];
            crossSums[0] = array[0];
            crossSums[1] = array[1];
            var allSums = new long[n];
            allSums[0] = array[0];
            allSums[1] = allSums[0] + array[1];
            for(int i = 2; i < n; i++)
            {
                crossSums[i] = crossSums[i - 2] + array[i];
                allSums[i] = allSums[i - 1] + array[i];
            }
            int boundary = n - 1;
            long[] res = new long[q];
            for (int i = 0; i < q; i++)
            {
                while (boundary >= 2)
                {
                    int next = boundary - 2;
                    int mid = (n - 1 + next) / 2;
                    if (xs[i][0] - array[next] <= array[mid] - xs[i][0])
                    {
                        boundary -= 2;
                    }
                    else
                    {
                        break;
                    }
                }
                //Console.WriteLine(boundary);
                int nowMid = (n - 1 + boundary) / 2;
                res[xs[i][1]] = allSums[n - 1] - allSums[nowMid - 1];
                if (boundary >=2) res[xs[i][1]] += crossSums[boundary - 2];
            }

            for(int i = 0; i < q; i++)
            {
                Console.WriteLine(res[i]);
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
