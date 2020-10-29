using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_106
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            if (n > 1 && m >= n - 1 || m < 0)
            {
                WriteLine(-1);
                return;
            }

            if (m == 0)
            {
                for(int i = 0; i < n; i++)
                {
                    WriteLine((i * 2 + 1) + " " + (i * 2 + 2));
                }
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    WriteLine((i * 4 + 2) + " " + (i * 4 + 4));
                }

                WriteLine(1 + " " + (m * 4 + 3));
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
