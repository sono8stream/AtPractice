using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_046
{
    class B
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
            int[] abcd = ReadInts();
            int a = abcd[0];
            int b = abcd[1];
            int c = abcd[2];
            int d = abcd[3];

            long[,] dp = new long[c+1, d+1];
            dp[a, b] = 1;
            long mask = 998244353;
            for(int i = a; i <= c; i++)
            {
                for(int j = b; j <= d; j++)
                {
                    if (i == a && j == b)
                    {
                        continue;
                    }

                    dp[i, j] = dp[i - 1, j] * j;
                    dp[i, j] %= mask;
                    dp[i, j] += dp[i, j - 1] * i;
                    dp[i, j] %= mask;
                    dp[i, j] += mask - (dp[i - 1, j - 1] * (i - 1) * (j - 1)) % mask;
                    dp[i, j] %= mask;
                }
            }

            WriteLine(dp[c, d]);
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
