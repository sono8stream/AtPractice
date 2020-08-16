using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces.Educational_50
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                long[] lr = ReadLongs();
                long l = lr[0];
                long r = lr[1];

                long upper = GetCount(r);
                long lower = GetCount(l - 1);
                WriteLine(upper - lower);
            }
        }

        static long GetCount(long val)
        {
            string s = val.ToString();
            long[,,] dp = new long[s.Length, 2, 4];
            dp[0, 1, 1] = 1;
            dp[0, 0, 0] = 1;
            dp[0, 0, 1] = s[0] - '0' - 1;
            for(int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (s[i] == '0')
                    {
                        dp[i, 1, j] += dp[i - 1, 1, j];
                    }
                    else if (j > 0)
                    {
                        dp[i, 1, j] += dp[i - 1, 1, j - 1];
                    }

                    dp[i, 0, j] += dp[i - 1, 0, j];
                    if (j > 0)
                    {
                        dp[i, 0, j] += dp[i - 1, 0, j - 1] * 9;
                    }
                    if (s[i] > '0')
                    {
                        dp[i, 0, j] += dp[i - 1, 1, j];
                        if (j > 0)
                        {
                            dp[i, 0, j] += dp[i - 1, 1, j - 1] * (s[i] - '1');
                        }
                    }
                }
            }

            long res = 0;
            for(int i = 0; i < 4; i++)
            {
                res += dp[s.Length - 1, 0, i] + dp[s.Length - 1, 1, i];
            }

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
