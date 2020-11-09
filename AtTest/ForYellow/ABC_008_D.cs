using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ABC_008_D
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
            int[] wh = ReadInts();
            int w = wh[0];
            int h = wh[1];
            int n = ReadInt();
            int[][] xys = new int[n][];
            for(int i = 0; i < n; i++)
            {
                int[] xy = ReadInts();
                xys[i] = new int[4] { xy[0], xy[1], 0, 0 };
            }

            int[] ws = new int[2 * n + 1];
            Array.Sort(xys, (a, b) => a[0] - b[0]);
            for(int i = 0; i < n; i++)
            {
                ws[i * 2] = xys[i][0] - 1;
                ws[i * 2 + 1] = 1;
                if (i > 0)
                {
                    ws[i * 2] -= xys[i - 1][0];
                }
                if (i == n - 1)
                {
                    ws[2 * n] = w - xys[i][0];
                }
                xys[i][2] = i * 2 + 1;
            }
            int[] hs = new int[2 * n + 1];
            Array.Sort(xys, (a, b) => a[1] - b[1]);
            for (int i = 0; i < n; i++)
            {
                hs[i * 2] = xys[i][1] - 1;
                hs[i * 2 + 1] = 1;
                if (i > 0)
                {
                    hs[i * 2] -= xys[i - 1][1];
                }
                if (i == n - 1)
                {
                    hs[2 * n] = h - xys[i][1];
                }
                xys[i][3] = i * 2 + 1;
            }

            int[,,,] dp = new int[2 * n + 1, 2 * n + 1, 2 * n + 1, 2 * n + 1];
            for(int i = 0; i <= 2*n; i++)
            {
                for(int j = 0; j <= 2 * n; j++)
                {
                    for(int k = 0; k <= 2 * n; k++)
                    {
                        for(int l = 0; l <= 2 * n; l++)
                        {
                            dp[i, j, k, l] = -1;
                        }
                    }
                }
            }
            DFS(dp, 0, 0, 2 * n, 2 * n, ws, hs, xys);
            WriteLine(dp[0, 0, 2 * n, 2 * n]);
        }

        static int DFS(int[,,,] dp,int x1, int y1, int x2, int y2,int[] ws,int[] hs,int[][] xys)
        {
            if (dp[x1, y1, x2, y2] >= 0)
            {
                return dp[x1, y1, x2, y2];
            }

            int max = 0;
            for (int i = 0; i < xys.Length; i++)
            {
                int x = xys[i][2];
                int y = xys[i][3];
                if (x1 < x && x < x2 && y1 < y && y < y2)
                {
                    int tmp = DFS(dp, x1, y1, x - 1, y - 1, ws, hs, xys)
                        + DFS(dp, x + 1, y1, x2, y - 1, ws, hs, xys)
                        + DFS(dp, x1, y + 1, x - 1, y2, ws, hs, xys)
                        + DFS(dp, x + 1, y + 1, x2, y2, ws, hs, xys);
                    for(int j = x1; j <= x2; j++)
                    {
                        tmp += ws[j];
                    }
                    for(int j = y1; j <= y2; j++)
                    {
                        tmp += hs[j];
                    }
                    tmp--;
                    max = Max(max, tmp);
                }
            }
            dp[x1, y1, x2, y2] = max;
            return dp[x1, y1, x2, y2];
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
