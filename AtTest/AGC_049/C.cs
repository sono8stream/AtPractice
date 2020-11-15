using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_049
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
            long[] arrayA = ReadLongs();
            long[] arrayB = ReadLongs();

            int[] breakSums = new int[n];
            long ignorePos = long.MaxValue;
            for(int i = n - 1; i >= 0; i--)
            {
                if (i +1< n)
                {
                    breakSums[i] = breakSums[i + 1];
                }
                if (arrayA[i] > arrayB[i])
                {
                    ignorePos = Min(ignorePos, arrayA[i] - arrayB[i]);
                }
                else if (arrayA[i] < ignorePos)
                {
                    breakSums[i]++;
                }
            }

            long res = breakSums[0];
            for (int i = 0; i < n; i++)
            {
                if (arrayA[i] <= arrayB[i])
                {
                    long removeCnt = arrayB[i] - arrayA[i] + 1;
                    long breakCnt = i==n-1?0:breakSums[i+1];
                    res = Min(res, Max(removeCnt, breakCnt));
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
