using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_149
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[] rsp = ReadLongs();
            string s = Read();
            long[,] dp = new long[n, 3];
            var dict = new Dictionary<char, int>();
            dict.Add('r', 0);
            dict.Add('s', 1);
            dict.Add('p', 2);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    long score = 0;
                    if ((j + 1) % 3 == dict[s[i]]) score += rsp[j];
                    if (i - k >= 0)
                    {
                        score += Max(dp[i - k, (j + 1) % 3], dp[i - k, (j + 2) % 3]);
                    }
                    dp[i, j] = score;
                }
            }
            long res = 0;
            for (int i = 0; i < k; i++)
            {
                res += Max(Max(dp[n - 1 - i, 0], dp[n - 1 - i, 1]), dp[n - 1 - i, 2]);
            }
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
