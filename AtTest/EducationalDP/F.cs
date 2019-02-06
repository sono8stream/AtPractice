using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            string t = Read();
            int[,] dp = new int[s.Length, t.Length];
            if (s[0] == t[0]) dp[0, 0] = 1;
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
                for(int j = 1; j < t.Length; j++)
                {
                    if (s[i] == t[j]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                }
            }
            Console.WriteLine(GetLCS(s, t, dp, s.Length - 1, t.Length - 1));
        }

        static char[] GetLCS(string s, string t, int[,] dp, int i, int j)
        {
            List<char> str = new List<char>();
            while (i >= 0 && j >= 0)
            {
                if (j > 0 && dp[i, j] == dp[i, j - 1])
                {
                    j--;
                }
                else if (i > 0 && dp[i, j] == dp[i - 1, j])
                {
                    i--;
                }
                else
                {
                    if (dp[i, j] > 0) str.Add(s[i]);
                    i--;
                    j--;
                }
            }
            str.Reverse();
            return str.ToArray();
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
