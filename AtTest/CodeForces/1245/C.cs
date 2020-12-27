using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1245
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
            long[] dp = new long[s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'm' || s[i] == 'w')
                {
                    WriteLine(0);
                    return;
                }
            }
            if (s.Length == 1)
            {
                WriteLine(1);
                return;
            }
            long mask = 1000000000 + 7;
            dp[0] = 1;
            dp[1] = 1;
            if ((s[0] == 'n' && s[1] == 'n')
                || (s[0] == 'u' && s[1] == 'u'))
            {
                dp[1] += 1;
            }
            for(int i = 2; i < s.Length; i++)
            {
                dp[i] = dp[i - 1];
                if ((s[i-1] == 'n' && s[i] == 'n')
                    || (s[i-1] == 'u' && s[i] == 'u'))
                {
                    dp[i] += dp[i - 2];
                }
                dp[i] %= mask;
            }
            WriteLine(dp[s.Length - 1]);
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
