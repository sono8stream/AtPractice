using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class CF2015_Morning_Easy_D
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
            string s = Read();
            int res = n;
            for(int i = 0; i < n - 1; i++)
            {
                int l = i + 1;
                int r = n - i - 1;
                int[,] dp = new int[l + 1, r + 1];
                for (int j= 0; j <= l; j++)
                {
                    dp[j, 0] = j;
                }
                for(int j = 0; j <= r; j++)
                {
                    dp[0, j] = j;
                }

                for (int j = 1; j <= l; j++)
                {
                    for (int k = 1; k <= r; k++)
                    {
                        dp[j, k] = Min(dp[j - 1, k], dp[j, k - 1]) + 1;
                        if (s[j - 1] == s[l + k - 1])
                        {
                            dp[j, k] = Min(dp[j, k], dp[j - 1, k - 1]);
                        }
                    }
                }

                res = Min(res, dp[l, r]);
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
