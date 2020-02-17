using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_155
{
    class E
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
            string s = Read();
            long[,] dp = new long[s.Length, 2];
            dp[0, 0] = s[0] - '0';
            dp[0, 1] = 1 + 10 - dp[0, 0];
            for (int i = 0; i < s.Length - 1; i++)
            {
                int num = s[i+1] - '0';
                dp[i + 1, 0] = Min(dp[i, 0], dp[i, 1]) + num;
                dp[i + 1, 1] = Min(dp[i, 1] - 1 + 10 - num, dp[i, 0] + 1 + 10 - num);
            }
            WriteLine(Min(dp[s.Length - 1, 0], dp[s.Length - 1, 1]));
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
