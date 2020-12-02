using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1391
{
    class D
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[,] grid = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                string row = Read();
                for(int j = 0; j < m; j++)
                {
                    grid[i, j] = row[j] == '0' ? 0 : 1;
                }
            }

            if (n >= 4 && m >= 4)
            {
                WriteLine(-1);
                return;
            }

            if (n > m)
            {
                int[,] sub = new int[m, n];
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        sub[j, i] = grid[i, j];
                    }
                }
                grid = sub;
                int tmp = n;
                n = m;
                m = tmp;
            }
            if (n == 1)
            {
                WriteLine(0);
                return;
            }

            List<int> twoPats = new List<int>();
            for(int i = 0; i < 16; i++)
            {
                int cnt = CountBit(i);
                if (cnt % 2 == 1)
                {
                    twoPats.Add(i);
                }
            }
            List<int> threePats = new List<int>();
            for (int i = 0; i < 64; i++)
            {
                int upCnt = CountBit(i % 4 + (i / 8) % 4 * 4);
                int downCnt = CountBit((i / 2) % 4 + (i / 16) * 4);

                if (upCnt % 2 == 1 && downCnt % 2 == 1)
                {
                    threePats.Add(i);
                }
            }

            if (n == 2)
            {
                int[,] dp = new int[m, 4];
                for(int i = 0; i < m - 1; i++)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        dp[i, j] = int.MaxValue / 2;
                    }

                    int now = GetVal(grid, i + 1) * 4;
                    if (i == 0)
                    {
                        now += GetVal(grid, i);
                        for (int j = 0; j < twoPats.Count; j++)
                        {
                            int cnt = CountBit(now ^ twoPats[j]);
                            dp[0, twoPats[j] / 4] = Min(dp[0, twoPats[j] / 4], cnt);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < twoPats.Count; j++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (l != twoPats[j] % 4)
                                {
                                    continue;
                                }

                                now += l;
                                int cnt = CountBit(now ^ twoPats[j]);
                                dp[i, twoPats[j] / 4] = Min(dp[i, twoPats[j] / 4], dp[i - 1, l] + cnt);
                                now -= l;
                            }
                        }
                    }
                }
                int res = int.MaxValue;
                for(int i = 0; i < 4; i++)
                {
                    res = Min(res, dp[m - 2, i]);
                }
                WriteLine(res);
            }
            else
            {
                int[,] dp = new int[m, 8];
                for (int i = 0; i < m - 1; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        dp[i, j] = int.MaxValue / 2;
                    }

                    int now = GetVal(grid, i + 1) * 8;
                    if (i == 0)
                    {
                        now += GetVal(grid, i);
                        for (int j = 0; j < threePats.Count; j++)
                        {
                            int cnt = CountBit(now ^ threePats[j]);
                            dp[0, threePats[j] / 8] = Min(dp[0, threePats[j] / 8], cnt);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < threePats.Count; j++)
                        {
                            for (int l = 0; l < 8; l++)
                            {
                                if (l != threePats[j] % 8)
                                {
                                    continue;
                                }

                                now += l;
                                int cnt = CountBit(now ^ threePats[j]);
                                dp[i, threePats[j] / 8] = Min(dp[i, threePats[j] / 8], dp[i - 1, l] + cnt);
                                now -= l;
                            }
                        }
                    }
                }
                int res = int.MaxValue;
                for (int i = 0; i < 8; i++)
                {
                    res = Min(res, dp[m - 2, i]);
                }
                WriteLine(res);
            }
        }

        static int CountBit(int val)
        {
            int cnt = 0;
            int div = 1;
            while (div <= val)
            {
                if ((val & div) > 0)
                {
                    cnt++;
                }
                div *= 2;
            }
            return cnt;
        }

        static int GetVal(int[,] grid,int colI)
        {
            int val = 0;
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, colI] == 1)
                {
                    val += (1 << i);
                }
            }

            return val;
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
