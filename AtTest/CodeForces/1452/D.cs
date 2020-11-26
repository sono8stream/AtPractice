using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1452
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
            long mask = 998244353;

            long[] dp = new long[n+1];
            dp[0] = 1;
            dp[1] = 1;
            long[] oddSums = new long[n + 1];
            oddSums[1] = 1;
            long[] evenSums = new long[n + 1];
            evenSums[0] = 1;

            for(int i = 2; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    dp[i] = evenSums[i - 1];
                    dp[i] %= mask;
                    oddSums[i] = oddSums[i - 2] + dp[i];
                    oddSums[i] %= mask;
                }
                else
                {
                    dp[i] = oddSums[i - 1];
                    dp[i] %= mask;
                    evenSums[i] = evenSums[i - 2] + dp[i];
                    evenSums[i] %= mask;
                }
            }

            long div = 1;
            for(int i = 0; i < n; i++)
            {
                div *= 2;
                div %= mask;
            }

            long res = dp[n];
            res *= Inverse(div, mask);
            res %= mask;
            WriteLine(res);
        }


        static long Inverse(long val,long mask)
        {
            long a = mask;
            long b = val % mask;
            long x = 1;
            long x1 = 0;
            long y = 0;
            long y1 = 1;
            while (b > 0)
            {
                long q = a / b;
                long r = a % b;
                long x2 = (mask + x - (q * x1) % mask) % mask;
                long y2 = (mask + y - (q * y1) % mask) % mask;
                a = b;
                b = r;
                x = x1;
                x1 = x2;
                y = y1;
                y1 = y2;
            }
            return y;
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
