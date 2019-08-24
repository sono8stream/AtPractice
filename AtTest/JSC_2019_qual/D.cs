using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JSC_2019_qual
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
            int n = ReadInt();
            bool odd = n % 2 == 1;
            int[,] levels = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                int delta = 2;
                int start = 1;
                int level = 1;
                while (start < n)
                {
                    for (int j = 0; i+start + j * delta < n; j++)
                    {
                        levels[i, i+start+j*delta] = level;
                    }
                    delta *= 2;
                    start *= 2;
                    level++;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    Write(levels[i, j]);
                    if (j < n -1) Write(" ");
                }
                WriteLine();
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
