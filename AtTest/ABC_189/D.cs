using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_189
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
            string[] ss = new string[n];
            for(int i = 0; i < n; i++)
            {
                ss[i] = Read();
            }

            long[,] dp = new long[n + 1,2];
            dp[0, 0] = 1;
            dp[0, 1] = 1;
            for (int i = 1; i <= n; i++)
            {
                if (ss[i-1] == "AND")
                {
                    dp[i, 0] = dp[i - 1, 0] * 2 + dp[i - 1, 1];// 0
                    dp[i, 1] = dp[i - 1, 1];// 1
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 0];
                    dp[i, 1] = dp[i - 1, 0] + dp[i - 1, 1] * 2;
                }
            }

            WriteLine(dp[n, 1]);
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
