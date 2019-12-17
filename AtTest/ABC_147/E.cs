using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_147
{
    class E
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
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            int[,] aGrid = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                int[] vals = ReadInts();
                for (int j = 0; j < w; j++)
                {
                    aGrid[i, j] = vals[j];
                }
            }
            int[,] bGrid = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                int[] vals = ReadInts();
                for (int j = 0; j < w; j++)
                {
                    bGrid[i, j] = vals[j];
                }
            }
            int maxVal = 13000;
            bool[,,] dp = new bool[h, w, 13000];
            dp[0, 0, Abs(aGrid[0, 0] - bGrid[0, 0])] = true;
            for(int i = 1; i < h; i++)
            {
                int delta = Abs(aGrid[i, 0] - bGrid[i, 0]);
                for (int j = 0; j < maxVal; j++)
                {
                    if (dp[i - 1, 0, j])
                    {
                        dp[i, 0, Abs(j - delta)] = true;
                        dp[i, 0, Abs(j + delta)] = true;
                    }
                }
            }
            for (int i = 1; i < w; i++)
            {
                int delta = Abs(aGrid[0, i] - bGrid[0, i]);
                for (int j = 0; j < maxVal; j++)
                {
                    if (dp[0, i-1, j])
                    {
                        dp[0,i, Abs(j - delta)] = true;
                        dp[0,i, Abs(j + delta)] = true;
                    }
                }
            }
            for (int i = 1; i < h; i++)
            {
                for(int j = 1; j < w; j++)
                {
                    int delta = Abs(aGrid[i, j] - bGrid[i, j]);
                    for(int k = 0; k < maxVal; k++)
                    {
                        if (dp[i-1, j, k])
                        {
                            dp[i, j, Abs(k - delta)] = true;
                            dp[i, j, Abs(k + delta)] = true;
                        }
                        if (dp[i, j-1, k])
                        {
                            dp[i, j, Abs(k - delta)] = true;
                            dp[i, j, Abs(k + delta)] = true;
                        }
                    }
                }
            }
            int res = int.MaxValue;
            for(int i = 0; i < maxVal; i++)
            {
                if (dp[h - 1, w - 1, i])
                {
                    WriteLine(i);
                    return;
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
