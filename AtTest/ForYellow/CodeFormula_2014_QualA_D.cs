using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFormula_2014_QualA_D
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
            string k = Read();
            var hashset = new HashSet<char>();
            for (int i = 0; i < k.Length; i++)
            {
                hashset.Add(k[i]);
            }
            double res = 0;
            int l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (hashset.Contains(s[i]))
                {
                    res++;
                }
                else
                {
                    l++;
                    hashset.Add(s[i]);
                }
            }
            int c = 36 - k.Length;

            if (l > 0)
            {
                double[,] dp = new double[l + 1, c + 1];

                dp[1, 1] = 1;
                for (int i = 1; i <= l; i++)
                {
                    for (int j = Max(i, 2); j <= c; j++)
                    {
                        dp[i, j] += 1.0 * (j - i) / j * (dp[i, j - 1] + 2);
                        dp[i, j] += 1.0 / j * (dp[i - 1, j - 1] + 1);
                        dp[i, j] += 1.0 * (i - 1) / j * (dp[i - 1, j - 1] + 3);
                    }
                }
                res += dp[l, c];
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
