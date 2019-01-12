using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Aising2018
{
    class D
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            long[] array = ReadLongs();
            var queries = new int[q];
            for(int i = 0; i < q; i++)
            {
                queries[i] = ReadInt();
            }

            var oddSums = new long[n / 2 + n % 2];
            oddSums[0] = n % 2 == 0 ? array[1] : array[0];
            for (int i = 1; i < oddSums.Length; i++)
            {
                oddSums[i] = oddSums[i - 1];
                oddSums[i] += n % 2 == 0 ? array[i * 2 + 1] : array[i * 2];
            }
            var allSums = new long[n];
            allSums[0] = array[0];
            for(int i = 1; i < n; i++)
            {
                allSums[i] = allSums[i - 1] + array[i];
            }

            for (int i = 0; i < q; i++)
            {
                if (queries[i] <= array[0])
                {
                    Console.WriteLine(allSums[n - 1] - allSums[n / 2 - 1]);
                    continue;
                }
                if (array[n - 1] <= queries[i])
                {
                    Console.WriteLine(oddSums[oddSums.Length - 1]);
                    continue;
                }

                int bottom = 0;
                int top = n;
                while (bottom + 1 < top)
                {
                    int x = (bottom + top) / 2;

                }

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
