using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1422
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
            string s = Read();

            long mask = 1000000000 + 7;
            // yet, using, used
            long[,] counts = new long[s.Length, 3];
            counts[0, 0] = 1;
            counts[0, 1] = 1;
            for(int i = 1; i < s.Length; i++)
            {
                counts[i, 0] = counts[i - 1, 0];
                counts[i, 0] %= mask;
                counts[i, 1] = counts[i - 1, 0] + counts[i - 1, 1];
                counts[i, 1] %= mask;
                counts[i, 2] = counts[i - 1, 1] + counts[i - 1, 2];
                counts[i, 2] %= mask;
            }

            long[,] dp = new long[s.Length, 3];
            dp[0,0] = s[0] - '0';

            for(int i = 1; i < s.Length; i++)
            {
                int delta = s[i] - '0';
                dp[i, 0] = dp[i - 1, 0] * 10 + delta * counts[i - 1, 0];
                dp[i, 0] %= mask;
                dp[i, 1] = dp[i - 1, 0] + dp[i - 1, 1];
                dp[i, 1] %= mask;
                dp[i, 2] = dp[i - 1, 1] * 10 + delta * counts[i - 1, 1]
                    + dp[i - 1, 2] * 10 + delta * counts[i - 1, 2];
                dp[i, 2] %= mask;
            }

            long res =  dp[s.Length- 1, 1] + dp[s.Length - 1, 2];
            res %= mask;
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
