using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_183
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
            int[] nk = ReadInts();
            int n = nk[0];
            long k = nk[1];
            long[,] dists = new long[n,n];
            for(int i = 0; i < n; i++)
            {
                long[] row = ReadLongs();
                for(int j = 0; j < n; j++)
                {
                    dists[i, j] = row[j];
                }
            }

            int[,] factorials = FactorialArray(n - 1);
            int res = 0;
            for(int i = 0; i < factorials.GetLength(0); i++)
            {
                long dist = 0;
                int now = 0;
                for(int j = 0; j < n-1; j++)
                {
                    int next = factorials[i, j] + 1;
                    dist += dists[now, next];
                    now = next;
                }
                dist += dists[now, 0];
                if (dist == k)
                {
                    res++;
                }
            }

            WriteLine(res);
        }

        static long Factorial(long n)
        {
            if (n == 0) return 1;

            return n * Factorial(n - 1);
        }

        static int[,] FactorialArray(int n)
        {
            long allPat = Factorial(n);
            var array = new int[allPat, n];
            var indexArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                indexArray[i] = i;
            }

            int modder = n;
            int divider = 1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < allPat; j++)
                {
                    array[j, i] = j / divider % modder;
                }
                divider *= modder;
                modder--;
            }

            var indexList = new List<int>();
            for (int i = 0; i < allPat; i++)
            {
                indexList.AddRange(indexArray);
                for (int j = 0; j < n; j++)
                {
                    int index = array[i, j];
                    array[i, j] = indexList[index];
                    indexList.RemoveAt(index);
                }
            }

            return array;
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
