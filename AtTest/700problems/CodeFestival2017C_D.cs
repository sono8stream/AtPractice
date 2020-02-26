using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class CodeFestival2017C_D
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

            var dict = new Dictionary<int, int>();
            dict.Add(0, 0);
            int[] dp = new int[s.Length + 1];
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i] = int.MaxValue / 2;
            }
            dp[0] = 0;
            int now = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int tmp = 1 << (s[i] - 'a');
                int next = now ^ tmp;
                if (dict.ContainsKey(next))
                {
                    if (dict[next] == 0)
                    {
                        dp[i + 1] = 1;
                    }
                    else
                    {
                        dp[i + 1] = dp[dict[next]];
                    }
                }
                for (int j = 0; j < 26; j++)
                {
                    int target = (1 << j) ^ next;
                    if (dict.ContainsKey(target))
                    {
                        dp[i + 1] = Min(dp[i + 1], dp[dict[target]] + 1);
                    }
                }

                now = next;
                if (dict.ContainsKey(now))
                {
                    if (dp[dict[now]] > dp[i + 1])
                    {
                        dict[now] = i + 1;
                    }
                }
                else
                {
                    dict.Add(now, i + 1);
                }
            }
            WriteLine(dp[s.Length]);
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
