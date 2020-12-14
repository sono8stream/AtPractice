using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1371
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nk = ReadInts();
                int n = nk[0];
                int k = nk[1];

                int[] lineCnt = new int[n];
                for(int j = 0; j < n; j++)
                {
                    lineCnt[j] = k / n;
                    if (j < k % n)
                    {
                        lineCnt[j]++;
                    }
                }

                int max = k / n;
                if (k % n > 0)
                {
                    max++;
                }
                int min = k / n;
                int val = 2 * (max - min) * (max - min);

                int[,] grid = new int[n, n];
                if (k % n == 0)
                {
                    for (int j = 0; j < k / n; j++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            grid[(j - l + n) % n, l] = 1;
                        }
                    }
                }
                else
                {
                    for(int j = 0; j < k % n; j++)
                    {
                        grid[k % n - 1 - j, j] = 1;
                    }

                    int cnt = k % n <= k / n ? k / n + 1 : k / n;
                    for (int j = 0; j < cnt; j++)
                    {
                        if (j == k % n - 1)
                        {
                            continue;
                        }

                        for (int l = 0; l < n; l++)
                        {
                            grid[(j - l + n) % n, l] = 1;
                        }
                    }
                }

                WriteLine(val);
                for(int j = 0; j < n; j++)
                {
                    for(int l = 0; l < n; l++)
                    {
                        Write(grid[j, l]);
                    }
                    WriteLine();
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
