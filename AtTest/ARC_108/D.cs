using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_108
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
            int n = ReadInt();
            char aa = Read()[0];
            char ab = Read()[0];
            char ba = Read()[0];
            char bb = Read()[0];

            if (n <=3)
            {
                WriteLine(1);
                return;
            }

            long mask = 1000000000 + 7;
            if (ab == 'A')
            {
                if (aa == 'A')
                {
                    WriteLine(1);
                }
                else
                {
                    if (ba == 'B')
                    {
                        long res = 1;

                        for (int i = 0; i < n - 3; i++)
                        {
                            res *= 2;
                            res %= mask;
                        }
                        WriteLine(res);
                        return;
                    }
                    else
                    {
                        long[,] dp = new long[n - 3, 2];
                        dp[0, 0] = 1;
                        dp[0, 1] = 1;
                        for (int i = 1; i < n - 3; i++)
                        {
                            dp[i, 0] += dp[i - 1, 0] + dp[i - 1, 1];
                            dp[i, 0] %= mask;
                            dp[i, 1] += dp[i - 1, 0];
                            dp[i, 1] %= mask;
                        }

                        WriteLine((dp[n - 4, 0] + dp[n - 4, 1])% mask);
                    }
                }
            }
            else
            {
                if (bb == 'B')
                {
                    WriteLine(1);
                }
                else
                {
                    if (ba == 'A')
                    {
                        long res = 1;

                        for (int i = 0; i < n - 3; i++)
                        {
                            res *= 2;
                            res %= mask;
                        }
                        WriteLine(res);
                        return;
                    }
                    else
                    {
                        long[,] dp = new long[n - 3, 2];
                        dp[0, 0] = 1;
                        dp[0, 1] = 1;
                        for (int i = 1; i < n - 3; i++)
                        {
                            dp[i, 0] += dp[i - 1, 0] + dp[i - 1, 1];
                            dp[i, 0] %= mask;
                            dp[i, 1] += dp[i - 1, 0];
                            dp[i, 1] %= mask;
                        }

                        WriteLine((dp[n - 4, 0] + dp[n - 4, 1]) % mask);
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
