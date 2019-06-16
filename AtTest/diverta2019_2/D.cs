using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.diverta2019_2
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long[] valA = ReadLongs();
            long[] valB = ReadLongs();
            long[][] vals = new long[3][];
            for (int i = 0; i < 3; i++)
            {
                vals[i] = new long[2] { valA[i], valB[i] };
            }

            long tmp = n;
            long[] dp = new long[tmp + 1];
            long maxI = 0;
            for(int i = 0; i <= tmp; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (i + vals[j][0] <= tmp)
                    {
                        dp[i + vals[j][0]]
                            = Max(dp[i + vals[j][0]], dp[i] + vals[j][1]);
                        if (dp[maxI] < dp[i + vals[j][0]])
                        {
                            maxI = i + vals[j][0];
                        }
                    }
                }
            }

            tmp = Max(tmp, dp[maxI] + tmp - maxI);
            maxI = 0;
            dp = new long[tmp + 1];
            for (int i = 0; i <= tmp; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i + vals[j][1] <= tmp)
                    {
                        dp[i + vals[j][1]]
                            = Max(dp[i + vals[j][1]], dp[i] + vals[j][0]);
                        if (dp[maxI] < dp[i + vals[j][1]])
                        {
                            maxI = i + vals[j][1];
                        }
                    }
                }
            }
            tmp = Max(tmp, dp[maxI] + tmp - maxI);

            WriteLine(tmp);
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
