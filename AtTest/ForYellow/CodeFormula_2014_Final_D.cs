using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFormula_2014_Final_D
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
            int[] hs = ReadInts();
            int[][] mse = new int[n][];
            for(int i = 0; i < n; i++)
            {
                mse[i] = ReadInts();
            }

            Array.Sort(mse, (a, b) => a[2] - b[2]);

            int[] dp = new int[n];
            for(int i = 0; i < n; i++)
            {
                int prev = 0;
                int start = mse[i][1];
                for(int j = i - 1; j >= 0; j--)
                {
                    if (mse[j][2] > start)
                    {
                        continue;
                    }

                    if (mse[i][0] != mse[j][0])
                    {
                        prev = Max(prev, dp[j]);
                    }
                }

                int cnt = 0;
                int end = mse[i][1];
                for(int j = i; j < n; j++)
                {
                    if (mse[j][1] < end)
                    {
                        continue;
                    }

                    if (mse[i][0] == mse[j][0])
                    {
                        dp[j] = Max(dp[j], prev + hs[cnt]);
                        end = mse[j][2];
                        prev += hs[cnt];
                        cnt++;
                    }
                }
            }

            int res = 0;
            res = dp.Max();
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
