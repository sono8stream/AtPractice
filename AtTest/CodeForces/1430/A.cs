using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1430
{
    class A
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
            bool[] dp = new bool[1050];
            int[][] pats = new int[1050][];
            dp[0] = true;
            pats[0] = new int[3] { 0, 0, 0 };
            for(int i = 0; i < 1050; i++)
            {
                if (!dp[i])
                {
                    continue;
                }

                for(int j = 1; i + 3 * j < 1050; j++)
                {
                    dp[i + j * 3] = true;
                    pats[i + j * 3] = new int[3] { pats[i][0] + j, pats[i][1], pats[i][2] };
                }
                for (int j = 1; i + 5 * j < 1050; j++)
                {
                    dp[i + j * 5] = true;
                    pats[i + j * 5] = new int[3] { pats[i][0], pats[i][1]+j, pats[i][2] };
                }
                for (int j = 1; i + 7 * j < 1050; j++)
                {
                    dp[i + j * 7] = true;
                    pats[i + j * 7] = new int[3] { pats[i][0], pats[i][1], pats[i][2]+j };
                }
            }

            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                if (dp[n])
                {
                    WriteLine(pats[n][0]+" "+pats[n][1]+" "+pats[n][2]);
                }
                else
                {
                    WriteLine(-1);
                }
            }
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
