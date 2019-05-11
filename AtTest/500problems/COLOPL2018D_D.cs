using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class COLOPL2018D_D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nx = ReadInts();
            int n = nx[0];
            int x = nx[1];
            long[] ts = new long[n];
            for (int i = 0; i < n; i++) ts[i] = ReadLong();

            var dp = new long[n, n];
            for (int i = 0; i < n; i++) dp[0, i] = x;

            for(int i = 0; i < n-1; i++)
            {
                int baseI = i;
                for (int j = i + 1; j < n; j++)
                {
                    while (baseI < j
                        && dp[i, baseI] + Min(ts[j] - ts[baseI], x)
                        <= dp[i, baseI + 1] + Min(ts[j] - ts[baseI + 1], x))
                    {
                        baseI++;
                    }
                    dp[i + 1, j] = dp[i, baseI] + Min(ts[j] - ts[baseI], x);
                }
            }

            for (int i = 0; i < n; i++) WriteLine(dp[i, n - 1]);
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
