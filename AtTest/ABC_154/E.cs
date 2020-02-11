using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_154
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
            string n = Read();
            int k = ReadInt();
            var dp = new long[n.Length, 2, k + 1];
            dp[0, 0, 0] = 1;
            dp[0, 0, 1] = n[0] - '1';
            dp[0, 1, 1] = 1;
            for (int i = 0; i < n.Length - 1; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    if (n[i+1] == '0')
                    {
                        dp[i + 1, 1, j] += dp[i, 1, j];
                    }
                    else
                    {
                        dp[i + 1, 1, j + 1] += dp[i, 1, j];
                        dp[i + 1, 0, j + 1] += dp[i, 1, j] * (n[i+1] - '1');
                        dp[i + 1, 0, j] += dp[i, 1, j];
                    }
                    dp[i + 1, 0, j + 1] += dp[i, 0, j] * 9;
                    dp[i + 1, 0, j] += dp[i, 0, j];
                }
                if (n[i+1] == '0')
                {
                    dp[i + 1, 1, k] += dp[i, 1, k];
                }
                else
                {
                    dp[i + 1, 0, k] += dp[i, 1, k];
                }
                dp[i + 1, 0, k] += dp[i, 0, k];
            }
            WriteLine(dp[n.Length - 1, 0, k] + dp[n.Length - 1, 1, k]);
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
