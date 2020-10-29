using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class HHKB2020_E
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
            bool[,] grid = new bool[h, w];
            int allCans = 0;
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    if (s[j] == '.')
                    {
                        grid[i, j] = true;
                        allCans++;
                    }
                }
            }

            long mask =1000000000+7;
            long[] pows = new long[allCans + 1];
            pows[0] = 1;
            for(int i = 1; i <= allCans; i++)
            {
                pows[i] = pows[i - 1] * 2;
                pows[i] %= mask;
            }

            int[,,] lineCnts = new int[h, w, 2];
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if (grid[i, j])
                    {
                        if (i > 0)
                        {
                            lineCnts[i, j, 0] = lineCnts[i - 1, j, 0];
                        }
                        if (j > 0)
                        {
                            lineCnts[i, j, 1] = lineCnts[i, j - 1, 1];
                        }
                        lineCnts[i, j, 0]++;
                        lineCnts[i, j, 1]++;
                    }
                }
            }
            for (int i = h - 1; i >= 0; i--)
            {
                for (int j = w - 1; j >= 0; j--)
                {
                    if (grid[i, j])
                    {
                        if (i + 1 < h && grid[i + 1, j])
                        {
                            lineCnts[i, j, 0] = lineCnts[i + 1, j, 0];
                        }
                        if (j + 1 < w && grid[i, j + 1])
                        {
                            lineCnts[i, j, 1] = lineCnts[i, j + 1, 1];
                        }
                    }
                }
            }

            long res = 0;
            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if(grid[i,j])
                    {
                        int cnt = lineCnts[i, j, 0] + lineCnts[i, j, 1] - 1;
                        long lightPats = (pows[cnt] + mask - 1) % mask;
                        res += lightPats * pows[allCans - cnt] % mask;
                        res %= mask;
                    }
                }
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
