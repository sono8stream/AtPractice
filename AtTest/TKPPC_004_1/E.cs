using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
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
            long[] nmke = ReadLongs();
            long n = nmke[0];
            long m = nmke[1];
            long k = nmke[2];
            long e = nmke[3];
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();
            Array.Sort(aArray);
            Array.Sort(bArray);
            Array.Reverse(bArray);
            long[] sumA = new long[n];
            long[] sumB = new long[m];
            for(int i = 0; i < n; i++)
            {
                sumA[i] = aArray[i];
                if (i > 0) sumA[i] += sumA[i - 1];
            }
            for(int i = 0; i < m; i++)
            {
                sumB[i] = bArray[i];
                if (i > 0) sumB[i] += sumB[i - 1];
            }

            if (sumA[n - 1] <= e + sumB[k - 1])
            {
                WriteLine("Yes");
                if (sumA[n - 1] <= e)
                {
                    WriteLine(0);
                    return;
                }
                for(int i = 0; i < m; i++)
                {
                    if (sumA[n - 1] <= e + sumB[i])
                    {
                        WriteLine(i + 1);
                        return;
                    }
                }
            }
            else
            {
                WriteLine("No");
                for(int i = 0; i < n; i++)
                {
                    if (sumA[i] > e + sumB[k - 1])
                    {
                        WriteLine(i);
                        return;
                    }
                }
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
