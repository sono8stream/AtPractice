using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFestival_Morning_Med_D
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
            long[][] pls = new long[n][];
            for(int i = 0; i < n; i++)
            {
                pls[i] = ReadLongs();
            }

            long[] dp = new long[pls[0][1] * 2 + 1];
            for(int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            long mask = 1000000000 + 7;
            for(int i = 1; i < n; i++)
            {
                long[] next = new long[pls[i][1] * 2 + 1];
                long sum = 0;
                long pos = pls[i - 1][0] - pls[i - 1][1];
                for(int j = 0; j < next.Length; j++)
                {
                    long now = pls[i][0] - pls[i][1] + j;
                    while (pos < now && pos<= pls[i - 1][0] + pls[i-1][1])
                    {
                        sum += dp[pos - pls[i - 1][0] + pls[i - 1][1]];
                        sum %= mask;
                        pos++;
                    }
                    next[j] = sum;
                }
                dp = next;
            }

            long res = 0;
            for(int i = 0; i < dp.Length; i++)
            {
                res += dp[i];
                res %= mask;
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
