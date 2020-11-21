using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1447
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];

            string a = Read();
            string b = Read();

            int[,] dp = new int[n, m];
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = 0;
                    if (i > 0)
                    {
                        dp[i, j] = Max(dp[i, j], dp[i - 1, j] - 1);
                    }
                    if (j > 0)
                    {
                        dp[i, j] = Max(dp[i, j], dp[i, j - 1] - 1);
                    }
                    if (a[i] == b[j])
                    {
                        int val = 2;
                        if (i > 0 && j > 0)
                        {
                            val += Max(0, dp[i - 1, j - 1]);
                        }
                        dp[i, j] = Max(dp[i, j], val);
                    }
                    max = Max(max, dp[i, j]);
                }
            }

            WriteLine(max);
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
