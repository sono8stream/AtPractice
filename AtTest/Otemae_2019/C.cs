using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Otemae_2019
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
            int n = ReadInt();
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            int[] cnts = new int[100000 + 5];
            for(int i = 0; i < n; i++)
            {
                cnts[bArray[i]]++;
            }

            int[] findCnts = new int[100000 + 5];
            int max = n;
            for(int i = 0; i < n; i++)
            {
                findCnts[aArray[i]]++;
                max = Min(max, cnts[aArray[i]] / findCnts[aArray[i]]);
                WriteLine(max);
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
