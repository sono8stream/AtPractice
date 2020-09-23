using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_178
{
    class F
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
            int[] arrayA = ReadInts();
            int[] arrayB = ReadInts();

            int[] cntsA = new int[n + 1];
            int[] cntsB = new int[n + 1];
            for(int i = 0; i < n; i++)
            {
                cntsA[arrayA[i]]++;
                cntsB[arrayB[i]]++;
            }

            int maxShift = 0;
            for(int i = 1; i <= n; i++)
            {
                if (cntsA[i] + cntsB[i] > n)
                {
                    WriteLine("No");
                    return;
                }

                if (i > 0)
                {
                    cntsA[i] += cntsA[i - 1];
                    cntsB[i] += cntsB[i - 1];
                }

                maxShift = Max(maxShift, cntsB[i] - cntsA[i - 1]);
            }

            WriteLine("Yes");
            for(int i = 0; i < n; i++)
            {
                Write(arrayB[(i + maxShift) % n]);
                if (i + 1 < n)
                {
                    Write(" ");
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
