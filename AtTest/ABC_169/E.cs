using AtTest.EducationalDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_169
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
            int n = ReadInt();
            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }

            int[][] ranges = new int[2][];

            Array.Sort(abs, (a, b) =>
            {
                if (a[0] == b[0])
                {
                    return a[1] - b[1];
                }
                return a[0] - b[0];
            });
            if (n % 2 == 0)
            {
                for(int i = n - 1; i > 0; i--)
                {

                }
            }
            else
            {
                for (int i = n - 1; i > 0; i--)
                {

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
