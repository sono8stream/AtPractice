using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_095
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nc = ReadLongs();
            int n = (int)nc[0];
            long c = nc[1];
            var xvs = new long[n][];
            for (int i = 0; i < n; i++)
            {
                long[] xv = ReadLongs();
                xvs[i] = new long[2];
                xvs[i][0] = xv[0];
                xvs[i][1] = xv[1];
            }

            var sums = new long[n];
            var sumsTurn = new long[n];
            sums[0] = xvs[0][1] - xvs[0][0];
            sumsTurn[0] = xvs[0][1] - xvs[0][0] * 2;
            for (int i = 1; i < n; i++)
            {
                sums[i] = sums[i - 1] + xvs[i][1]
                    - (xvs[i][0] - xvs[i - 1][0]);
                sumsTurn[i] = sums[i] - xvs[i][0];
            }

            var sumsR = new long[n];
            var sumsTurnR = new long[n];
            sumsR[0] = xvs[n - 1][1] - (c - xvs[n - 1][0]);
            sumsTurnR[0] = xvs[n - 1][1] - (c - xvs[n - 1][0]) * 2;
            for (int i = 1; i < n; i++)
            {
                sumsR[i] = sumsR[i - 1] + xvs[n - i - 1][1]
                    - (xvs[n - i][0] - xvs[n - i - 1][0]);
                sumsTurnR[i] = sumsR[i] - (c - xvs[n - i - 1][0]);
            }

            /*Console.WriteLine(sums[0]);
            Console.WriteLine(sumsTurn[0]);
            Console.WriteLine(sumsR[0]);
            Console.WriteLine(sumsTurnR[0]);*/
            for (int i = 1; i < n; i++)
            {
                /*Console.WriteLine(sums[i]);
                Console.WriteLine(sumsTurn[i]);
                Console.WriteLine(sumsR[i]);
                Console.WriteLine(sumsTurnR[i]);*/
                sums[i] = Math.Max(sums[i], sums[i - 1]);
                sumsTurn[i] = Math.Max(sumsTurn[i], sumsTurn[i - 1]);
                sumsR[i] = Math.Max(sumsR[i], sumsR[i - 1]);
                sumsTurnR[i] = Math.Max(sumsTurnR[i], sumsTurnR[i - 1]);
            }

            long result = 0;
            result = Math.Max(result, sums[n - 1]);
            result = Math.Max(result, sumsR[n - 1]);
            for (int i = 0; i < n - 1; i++)
            {
                result = Math.Max(result, sums[i] + sumsTurnR[n - i - 2]);
                result = Math.Max(result, sumsTurn[i] + sumsR[n - i - 2]);
            }

            Console.WriteLine(result);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
