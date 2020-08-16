using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TokioMarine_2020
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
            int k = nk[1];
            int[] array = ReadInts();
            for(int i = 0; i < k; i++)
            {
                int[] next = new int[n];
                for (int j = 0; j < n; j++)
                {
                    next[Max(j - array[j], 0)]++;
                    if (j + array[j] + 1 < n)
                    {
                        next[j + array[j] + 1]--;
                    }
                }

                int maxCnt = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j > 0)
                    {
                        next[j] += next[j - 1];
                    }
                    if (next[j] == n)
                    {
                        maxCnt++;
                    }
                }

                array = next;
                if (maxCnt == n)
                {
                    break;
                }
            }

            for(int i = 0; i < n; i++)
            {
                Write(array[i] + " ");
            }
            WriteLine();
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
