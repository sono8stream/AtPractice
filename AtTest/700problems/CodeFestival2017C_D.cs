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

            var dict = new Dictionary<string, List<int>>();
            dict.Add("", new List<int>());
            dict[""].Add(0);
            bool[] now = new bool[26];
            string[] codes = new string[s.Length + 1];
            codes[0] = "";
            for (int i = 0; i < s.Length; i++)
            {
                now[s[i] - 'a'] = !now[s[i] - 'a'];
                codes[i + 1] = "";
                for (int j = 0; j < 26; j++)
                {
                    if (now[j])
                    {
                        codes[i+1] += (char)('a' + j);
                        if (i % 2 == 0 && s[i] == 'a' + j)
                        {
                            continue;
                        }
                    }
                }
                if (!dict.ContainsKey(codes[i+1]))
                {
                    dict.Add(codes[i+1], new List<int>());
                }
                dict[codes[i+1]].Add(i + 1);

                    if (!dict.ContainsKey(codes[i]))
                    {
                        dict.Add(codes[i], new List<int>());
                    }
                dict[codes[i]].Add(i + 1);
                 }
               
            int[] dp = new int[s.Length + 1];
            for(int i = 0; i <= s.Length; i++)
            {
                dp[i] = int.MaxValue / 2;
            }
            dp[0] = 0;

            now = new bool[26];
            for (int i = 0; i < s.Length; i++)
            {
                string code = "";
                for (int j = 0; j < 26; j++)
                {
                    if (now[j])
                    {
                        code += (char)('a' + j);
                    }
                }
                dp[i + 1] = Min(dp[i + 1], dp[i]);
                if (i==dict[code][0])
                {
                    for(int j = 0; j < dict[code].Count; j++)
                    {
                        int to = dict[code][j];
                        dp[to] = Min(dp[to], dp[i]);
                    }
                }
                now[s[i] - 'a'] = !now[s[i] - 'a'];
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
