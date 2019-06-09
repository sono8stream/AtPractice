using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_129
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            var dict = new HashSet<int>();
            for(int i = 0; i < m; i++)
            {
                dict.Add(ReadInt());
            }

            var dp = new long[n + 10];
            long mask = 1000000000 + 7;
            dp[0] = 1;
            for (int i = 0; i < n; i++)
            {
                if (!dict.Contains(i))
                {
                    dp[i + 1] += dp[i];
                    dp[i + 1] %= mask;
                    dp[i + 2] += dp[i];
                    dp[i + 2] %= mask;
                }
            }

            WriteLine(dp[n]);
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
