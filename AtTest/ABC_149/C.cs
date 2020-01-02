using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_149
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
            bool[] isPrime = new bool[1000000];
            for (int i = 2; i < isPrime.Length; i++) isPrime[i] = true;
            for (int i = 2; i < isPrime.Length; i++)
            {
                if (!isPrime[i]) continue;
                for (int j = 2; i * j < isPrime.Length; j++)
                {
                    isPrime[i * j] = false;
                }
            }

            int x = ReadInt();
            for (int i = x; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    WriteLine(i);
                    return;
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
