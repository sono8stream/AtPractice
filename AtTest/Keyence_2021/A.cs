using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Keyence_2021
{
    class A
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
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();

            long[] aMaxs = new long[n];
            for (int i = 0; i < n; i++) {
                aMaxs[i] = aArray[i];
                if (i > 0)
                {
                    aMaxs[i] = Max(aMaxs[i], aMaxs[i - 1]);
                }
            }

            long[] abMaxs = new long[n];
            for(int i = 0; i < n; i++)
            {
                abMaxs[i] = bArray[i] * aMaxs[i];
                if (i > 0)
                {
                    abMaxs[i] = Max(abMaxs[i], abMaxs[i - 1]);
                }

                WriteLine(abMaxs[i]);
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
