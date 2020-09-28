using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1426
{
    class F
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
            long mask = 1000000000 + 7;

            long[,] dp = new long[n, 3];
            long pats = 1;
            for(int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    dp[i, 0] += dp[i - 1, 0];
                    dp[i, 1] += dp[i - 1, 1];
                    dp[i, 2] += dp[i - 1, 2];
                }
                switch (s[i])
                {
                    case 'a':
                        dp[i, 0] += pats;
                        break;
                    case 'b':
                        if (i > 0)
                        {
                            dp[i, 1] += dp[i - 1, 0];
                        }
                        break;
                    case 'c':
                        if (i > 0)
                        {
                            dp[i, 2] += dp[i - 1, 1];
                        }
                        break;
                    case '?':
                        dp[i, 0] += pats;
                        if (i > 0)
                        {
                            dp[i, 0] += dp[i - 1, 0] * 2;
                            dp[i, 1] += dp[i - 1, 0] + dp[i - 1, 1] * 2;
                            dp[i, 2] += dp[i - 1, 1] + dp[i - 1, 2] * 2;
                        }
                        pats *= 3;
                        pats %= mask;
                        break;
                }
                dp[i, 0] %= mask;
                dp[i, 1] %= mask;
                dp[i, 2] %= mask;
            }

            WriteLine(dp[n - 1, 2]);
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
