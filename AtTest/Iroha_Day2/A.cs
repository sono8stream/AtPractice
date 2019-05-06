using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day2
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            string t = Read();
            int[,] dp = new int[s.Length, t.Length];
            dp[0, 0] = s[0] == t[0] ? 1 : 0;
            for(int i = 1; i < s.Length; i++)
            {
                if (s[i] == t[0]) dp[i, 0] = 1;
                else dp[i, 0] = dp[i - 1, 0];
            }
            for (int i = 1; i < t.Length; i++)
            {
                if (s[0] == t[i]) dp[0, i] = 1;
                else dp[0, i] = dp[0, i - 1];
            }
            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 1; j < t.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            WriteLine(dp[s.Length - 1, t.Length - 1] + 1);
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
