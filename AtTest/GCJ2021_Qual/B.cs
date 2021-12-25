using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2021_Qual
{
    class B
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
            int t = ReadInt();
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            string[] input = Read().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            string s = input[2];
            int[,] dp = new int[s.Length, 2];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] == 'C')
                {
                    if (s[i] == 'C')
                    {
                        dp[i, 0] = dp[i - 1, 0];
                    }
                    else if (s[i] == 'J')
                    {
                        dp[i, 1] = x + dp[i - 1, 0];
                    }
                    else
                    {
                        dp[i, 0] = dp[i - 1, 0];
                        dp[i, 1] = x + dp[i - 1, 0];
                    }
                }
                else if (s[i - 1] == 'J')
                {
                    if (s[i] == 'C')
                    {
                        dp[i, 0] = y + dp[i - 1, 1];
                    }
                    else if (s[i] == 'J')
                    {
                        dp[i, 1] = dp[i - 1, 1];
                    }
                    else
                    {
                        dp[i, 0] = y + dp[i - 1, 1];
                        dp[i, 1] = dp[i - 1, 1];
                    }
                }
                else
                {
                    if (s[i] == 'C')
                    {
                        dp[i, 0] = Min(dp[i - 1, 0], y + dp[i - 1, 1]);
                    }
                    else if (s[i] == 'J')
                    {
                        dp[i, 1] = Min(x + dp[i - 1, 0], dp[i - 1, 1]);
                    }
                    else
                    {
                        dp[i, 0] = Min(dp[i - 1, 0], y + dp[i - 1, 1]);
                        dp[i, 1] = Min(x + dp[i - 1, 0], dp[i - 1, 1]);
                    }
                }
            }

            return () =>
            {
                if (s[s.Length - 1] == 'C')
                {
                    WriteLine(dp[s.Length - 1, 0]);
                }else if (s[s.Length - 1] == 'J')
                {
                    WriteLine(dp[s.Length - 1, 1]);
                }
                else
                {
                    WriteLine(Min(dp[s.Length - 1, 0], dp[s.Length - 1, 1]));
                }
            };
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
