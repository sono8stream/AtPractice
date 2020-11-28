using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1398
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
            int[] rgb = ReadInts();
            int r = rgb[0];
            int g = rgb[1];
            int b = rgb[2];
            int[] rs = ReadInts();
            Array.Sort(rs);
            int[] gs = ReadInts();
            Array.Sort(gs);
            int[] bs = ReadInts();
            Array.Sort(bs);

            long[,,] dp = new long[r + 1, g + 1, b + 1];
            long res = 0;
            for (int i = r; i >= 0; i--)
            {
                for (int j = g; j >= 0; j--)
                {
                    for (int k = b; k >= 0; k--)
                    {
                        if (i > 0 && j > 0)
                        {
                            dp[i - 1, j - 1, k]
                                = Max(dp[i - 1, j - 1, k], dp[i, j, k] + rs[i - 1] * gs[j - 1]);
                            res = Max(res, dp[i - 1, j - 1, k]);
                        }
                        if (i > 0 && k > 0)
                        {
                            dp[i - 1, j, k - 1]
                                = Max(dp[i - 1, j, k - 1], dp[i, j, k] + rs[i - 1] * bs[k - 1]);
                            res = Max(res, dp[i - 1, j, k - 1]);
                        }
                        if (j > 0 && k > 0)
                        {
                            dp[i, j - 1, k - 1]
                                = Max(dp[i, j - 1, k - 1], dp[i, j, k] + gs[j - 1] * bs[k - 1]);
                            res = Max(res, dp[i, j - 1, k - 1]);
                        }
                    }
                }
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
