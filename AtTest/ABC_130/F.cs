using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_130
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[][] xys = new long[n][];
            char[] dirs = new char[n];
            for(int i = 0; i < n; i++)
            {
                string[] ss = Read().Split();
                xys[i] = new long[2] { int.Parse(ss[0]), int.Parse(ss[1]) };
                dirs[i] = ss[2][0];
            }
            long[] rludMax = new long[4];
            long[] rludMin = new long[4];
            long[] rludFix = new long[4];
            for(int i = 0; i < 4; i++)
            {
                rludMax[i] = long.MinValue;
                rludMin[i] = long.MaxValue;
            }
            rludFix[0] = long.MinValue;
            rludFix[1] = long.MaxValue;
            rludFix[2] = long.MinValue;
            rludFix[3] = long.MaxValue;
            for(int i = 0; i < n; i++)
            {
                switch (dirs[i])
                {
                    case 'R':
                        rludMax[0] = Max(rludMax[0], xys[i][0]);
                        rludMin[0] = Min(rludMin[0], xys[i][0]);
                        rludFix[2] = Max(rludFix[2], xys[i][1]);
                        rludFix[3] = Min(rludFix[3], xys[i][1]);
                        break;
                    case 'L':
                        rludMax[1] = Max(rludMax[1], xys[i][0]);
                        rludMin[1] = Min(rludMin[1], xys[i][0]);
                        rludFix[2] = Max(rludFix[2], xys[i][1]);
                        rludFix[3] = Min(rludFix[3], xys[i][1]);
                        break;
                    case 'U':
                        rludMax[2] = Max(rludMax[2], xys[i][1]);
                        rludMin[2] = Min(rludMin[2], xys[i][1]);
                        rludFix[0] = Max(rludFix[0], xys[i][0]);
                        rludFix[1] = Min(rludFix[1], xys[i][0]);
                        break;
                    case 'D':
                        rludMax[3] = Max(rludMax[3], xys[i][1]);
                        rludMin[3] = Min(rludMin[3], xys[i][1]);
                        rludFix[0] = Max(rludFix[0], xys[i][0]);
                        rludFix[1] = Min(rludFix[1], xys[i][0]);
                        break;
                }
            }

            double[][] rludTimes = new double[4][];//dec, stable, inc
            for(int i = 0; i < 4; i++)
            {
                rludTimes[i] = new double[3];
            }
            rludTimes[0][0] = Max(0.5 * (rludMax[1] - rludMax[1]),
                rludMax[1] - rludFix[0]);
            rludTimes[0][0] = Max(rludTimes[0][0], 0);


            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            // Write output here

            Out.Flush();
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
