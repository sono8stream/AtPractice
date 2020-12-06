using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1397
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
            int[] nrd = ReadInts();
            int n = nrd[0];
            long r1 = nrd[1];
            long r2 = nrd[2];
            long r3 = nrd[3];
            long d = nrd[4];
            long[] array = ReadLongs();

            // 往復したか？
            long[,] dp = new long[n, 2];
            for(int i = 0; i < n; i++)
            {
                dp[i, 0] = long.MaxValue / 10;
                dp[i, 1] = long.MaxValue / 10;
            }
            for(int i = 0; i < n; i++)
            {
                long unvisited = 0;
                long visited = 0;
                if (i > 0)
                {
                    unvisited = dp[i - 1, 0] + d;
                    visited = dp[i - 1, 1] + d;
                }

                long noRound = CalcNoRound(array[i], r1, r2, r3);
                long round = CalcRound(array[i], r1, r2, r3);
                dp[i, 0] = Min(dp[i, 0], Min(visited, unvisited) + noRound);
                if (i > 0)
                {
                    dp[i, 0] = Min(dp[i, 0], visited + round);
                }
                if (i == n - 1)
                {
                    dp[i, 0] = Min(dp[i, 0], visited + noRound - d);
                }
                dp[i, 1] = Min(dp[i, 1], Min(visited, unvisited) + round + d * 2);
            }
            WriteLine(Min(dp[n - 1, 0], dp[n - 1, 1]));
        }

        static long CalcNoRound(long a,long r1,long r2,long r3)
        {
            long res = long.MaxValue;
            res = Min(res, a * r1 + r3);
            return res;
        }

        static long CalcRound(long a, long r1, long r2, long r3)
        {
            long res = long.MaxValue;
            res = Min(res, a * r1 + 2 * r1);
            res = Min(res, r2 + r1);
            return res;
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
