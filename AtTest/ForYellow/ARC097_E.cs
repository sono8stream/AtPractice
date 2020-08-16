using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC097_E
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
            bool[] states = new bool[2 * n];
            int[] nos = new int[2 * n];
            for (int i = 0; i < 2 * n; i++)
            {
                string[] input = Read().Split();
                states[i] = input[0][0] == 'W';
                nos[i] = int.Parse(input[1]);
            }

            int[,] whites = new int[2 * n, n + 1];
            int[,] blacks = new int[2 * n, n + 1];
            for (int i = 0; i < 2 * n; i++)
            {
                if (i > 0)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        whites[i, j] = whites[i - 1, j];
                        blacks[i, j] = blacks[i - 1, j];
                    }
                }

                for (int j = 0; j < nos[i]; j++)
                {
                    if (states[i])
                    {
                        whites[i, j]++;
                    }
                    else
                    {
                        blacks[i, j]++;
                    }
                }
            }

            int[,] wCosts = new int[n+1,n+1];
            int[,] bCosts = new int[n+1,n+1];
            for(int i = 0; i < 2 * n; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    if (states[i])
                    {
                        wCosts[nos[i], j] = whites[i, nos[i]] + blacks[i, j];
                    }
                    else
                    {
                        bCosts[nos[i], j] = blacks[i, nos[i]] + whites[i, j];
                    }
                }
            }

            int[,] dp = new int[n + 1, n + 1];// w, b
            for(int i = 1; i <= n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + wCosts[i, 0];
                dp[0, i] = dp[0, i - 1] + bCosts[i, 0];
            }
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    dp[i, j] = Min(dp[i - 1, j] + wCosts[i, j],
                        dp[i, j - 1] + bCosts[j, i]);
                }
            }

            WriteLine(dp[n, n]);
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
