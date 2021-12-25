using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_189
{
    class F
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            int[] array;
            if (k == 0)
            {
                ReadLine();
                array = new int[0];
            }
            else
            {
                array = ReadInts();
            }

            double[,] dp = new double[n + 1, 2];
            double sum = 0;
            double sumX = 0;
            for(int i = n-1; i >=0; i--)
            {
                if (i + m < n)
                {
                    sum -= dp[i + m + 1, 0];
                    sumX -= dp[i + m + 1, 1];
                }

                bool can = true;
                for (int j = 0; j < k; j++)
                {
                    if (i == array[j])
                    {
                        can = false;
                    }
                }
                if (!can)
                {
                    dp[i, 0] = 0;
                    dp[i, 1] = 1;
                    sumX++;
                    continue;
                }

                int cannots = 0;
                for(int j = 0; j < k; j++)
                {
                    if (i < array[j] && array[j] <= i + m)
                    {
                        cannots++;
                    }
                }
                if (cannots == m)
                {
                    WriteLine(-1);
                    return;
                }

                dp[i, 0] = 1 + sum / m;
                dp[i, 1] = sumX / m;
                sum += dp[i, 0];
                sumX += dp[i, 1];
            }

            double x = dp[0, 0] / (1 - dp[0, 1]);
            WriteLine(x);
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
