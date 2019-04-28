using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] dx = ReadLongs();
            long d = dx[0];
            long x = dx[1];

            long[,] dp = new long[1, x+1];
            for (int i = 0; i < x; i++) {
                dp[0, i] = 1;
                dp[0, x] += dp[0, i];
            }
            long mask = 1000000000 + 7;
            for(int i = 1; i <= d; i++)
            {
                long[,] next = new long[i * 2 + 1, x];

                for(int j = 0; j < i * 2 + 1; j++)
                {
                    for(int k = 0; k < x; k++)
                    {
                        if (j == 0)
                        {
                            if (i == 1)
                            {
                                next[j, k] = dp[0, x];
                                next[j, k] -= dp[0, k];
                            }
                            else
                            {
                                next[j, k] = dp[1, x];
                                next[j, k] -= dp[1, k];
                            }
                        }
                        else if (j == i * 2)
                        {
                            if (i == 1)
                            {
                                next[j, k] = dp[0, x];
                                next[j, k] -= dp[0, k];
                            }
                            else
                            {
                                next[j, k] = dp[1, x];
                                next[j, k] -= dp[1, k];
                            }
                        }
                        else
                        {
                            next[j, k] = next[j - 1, x];
                            next[j, k] -= next[j - 1, k];
                        }
                        while (next[j, k] < 0) next[j, k] += mask;
                        next[j, k] %= mask;
                        next[j, x] += next[j, k];
                        next[j, x] %= mask;
                    }
                }
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
