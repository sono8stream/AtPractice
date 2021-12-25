using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_223
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
            int[][] abs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }

            double totalTime = 0;
            for (int i = 0; i < n; i++)
            {
                totalTime += 1.0 * abs[i][0] / abs[i][1];
            }

            double remainTime = totalTime / 2;
            double burnLeftLength = 0;
            for(int i = 0; i < n; i++)
            {
                double burnTime = 1.0 * abs[i][0] / abs[i][1];
                if (burnTime >= remainTime)
                {
                    burnLeftLength += abs[i][1] * remainTime;
                    WriteLine(burnLeftLength);
                    return;
                }
                else
                {
                    burnLeftLength += abs[i][0];
                    remainTime -= burnTime;
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
