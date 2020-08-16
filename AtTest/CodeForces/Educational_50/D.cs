using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces.Educational_50
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
            long[] aArray = ReadLongs();
            int m = ReadInt();
            long[] bArray = ReadLongs();

            long aSum = aArray.Sum();
            long bSum = bArray.Sum();
            if (aSum != bSum)
            {
                WriteLine(-1);
                return;
            }

            long a = 0;
            long b = 0;
            long res = 0
                ;
            int aI = 0;
            int bI = 0;
            while (aI < n || bI < m)
            {
                if (a < b)
                {
                    a += aArray[aI];
                    aI++;
                }
                else
                {
                    b += bArray[bI];
                    bI++;
                }

                if (a == b)
                {
                    a = 0;
                    b = 0;
                    res++;
                }
            }
            WriteLine(res);
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
