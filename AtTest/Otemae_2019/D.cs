using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Otemae_2019
{
    class D
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            string[] strs = new string[m];
            for (int i = 0; i < m; i++) strs[i] = Read();

            long mask = 1000000000 + 7;
            long[,,] dp = new long[n + 5, 3, m + 5];
            dp[0, 0, 0] = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            if (i == 0 && l == 0) continue;
                            int mod = (k + l) % 3;
                            if (j == m)
                            {
                                if(mod!=0
                                    && l != 0 && l != 5)
                                {
                                    dp[i + 1, mod, j] += dp[i, k, j];
                                    dp[i + 1, mod, j] %= mask;
                                }
                                continue;
                            }

                            if (mod == 0
                                && (l == 0 || l == 5))
                            {
                                if (strs[j].Length == 8)
                                {
                                    dp[i + 1, mod, j + 1] += dp[i, k, j];
                                    dp[i + 1, mod, j + 1] %= mask;
                                }

                            }
                            else if (mod == 0)
                            {
                                if(strs[j].Length==4
                                    && strs[j][0] == 'F')
                                {
                                    dp[i + 1, mod, j + 1] += dp[i, k, j];
                                    dp[i + 1, mod, j + 1] %= mask;
                                }
                            }
                            else if (l == 0 || l == 5)
                            {
                                if(strs[j].Length==4
                                    && strs[j][0] == 'B')
                                {
                                    dp[i + 1, mod, j + 1] += dp[i, k, j];
                                    dp[i + 1, mod, j + 1] %= mask;
                                }
                            }
                            else
                            {
                                dp[i + 1, mod, j] += dp[i, k, j];
                                dp[i + 1, mod, j] %= mask;
                            }
                        }
                    }
                }
            }

            WriteLine((dp[n, 0, m] + dp[n, 1, m] + dp[n, 2, m]) % mask);
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
