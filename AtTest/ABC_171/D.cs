using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_171
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
            int[] array = ReadInts();
            long[] vals = new long[100000 + 100];
            for(int i = 0; i < n; i++)
            {
                vals[array[i]]++;
            }

            long res = 0;
            for(int i = 0; i < vals.Length; i++)
            {
                res += vals[i] * i;
            }

            int q = ReadInt();
            for (int i = 0; i < q; i++)
            {
                int[] bc = ReadInts();
                int b = bc[0];
                int c = bc[1];

                res -= b * vals[b];
                res += c * vals[b];
                vals[c] += vals[b];
                vals[b] = 0;

                WriteLine(res);
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
