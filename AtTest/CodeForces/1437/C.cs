using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1437
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
            int q = ReadInt();
            for (int i = 0; i < q; i++)
            {
                int n = ReadInt();
                int[] ts = ReadInts();
                Array.Sort(ts);

                // i, j-sec
                int[,] dp = new int[n, n + 205];
                for (int j = 1; j < n + 205; j++)
                {
                    dp[0, j] = Abs(ts[0] - j);
                    if (j > 1)
                    {
                        dp[0, j] = Min(dp[0, j - 1], dp[0, j]);
                    }
                }
                for(int j =1; j < n; j++)
                {
                    for(int k = j+1; k < n + 205; k++)
                    {
                        dp[j, k] = dp[j - 1, k - 1] + Abs(ts[j] - k);
                        if (k > j + 1)
                        {
                            dp[j, k] = Min(dp[j, k - 1], dp[j, k]);
                        }
                    }
                }

                int res = int.MaxValue;
                for(int j = n; j < n + 205; j++)
                {
                    res = Min(res, dp[n - 1, j]);
                }

                WriteLine(res);
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
