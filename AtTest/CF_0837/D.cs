using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CF_0837
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[] array = ReadLongs();
            long[] twos = new long[n];
            long[] fives = new long[n];
            long twoAll = 0;
            long fiveAll = 0;
            for(int i = 0; i < n; i++)
            {
                long tmp = array[i];
                while (tmp % 2 == 0)
                {
                    twos[i]++;
                    tmp /= 2;
                }
                while (tmp % 5 == 0)
                {
                    fives[i]++;
                    tmp /= 5;
                }
                twoAll += twos[i];
                fiveAll += fives[i];
            }
            HashSet<long>[,] dp = new HashSet<long>[n, k + 1];
            for(int i = 0; i < n; i++)
            {
                dp[i, 0] = new HashSet<long>();
                dp[i, 0].Add(0);
            }
            dp[0, 1] = new HashSet<long>();
            dp[0, 1].Add(twos[0] * 1000000 + fives[0]);
            for(int i = 1; i < n; i++)
            {
                for(int j = 1; j <= k; j++)
                {
                    dp[i, j] = new HashSet<long>();
                    foreach(long val in dp[i - 1, j - 1])
                    {
                        long nextVal = val;
                        nextVal += twos[i] * 1000000 + fives[i];
                        dp[i, j].Add(nextVal);
                    }
                    if (dp[i - 1, j] == null) break;
                    foreach(long val in dp[i - 1, j])
                    {
                        dp[i, j].Add(val);
                    }
                }
            }
            long res = 0;
            foreach(long val in dp[n - 1, k])
            {
                long two = val / 1000000;
                long five = val % 1000000;
                res = Max(res, Min(two, five));
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
