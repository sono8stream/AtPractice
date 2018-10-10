using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_077
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] arrayA = ReadInts();
            int[] arrayB = ReadInts();
            int[] arrayC = ReadInts();
            Array.Sort(arrayA);
            Array.Sort(arrayB);
            Array.Sort(arrayC);
            int itrA = 0;
            int itrB = 0;
            long[] ABpatterns = new long[n];
            for (; itrB < n; itrB++)
            {
                while (itrA < n && arrayA[itrA] < arrayB[itrB])
                {
                    itrA++;
                }
                ABpatterns[itrB] = itrB == 0
                    ? itrA : ABpatterns[itrB - 1] + itrA;
            }

            itrB = 0;
            int itrC = 0;
            long[] BCpatterns = new long[n];
            for (; itrC < n; itrC++)
            {
                while (itrB < n && arrayB[itrB] < arrayC[itrC])
                {
                    itrB++;
                }
                if (itrB == 0)
                {
                    BCpatterns[itrC] = 0;
                }
                else
                {
                    BCpatterns[itrC] = itrC == 0
                        ? ABpatterns[itrB - 1]
                        : BCpatterns[itrC - 1] + ABpatterns[itrB - 1];
                }
            }

            Console.WriteLine(BCpatterns[n - 1]);
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
