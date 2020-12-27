using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1245
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
            int[,] nums = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                int[] row = ReadInts();
                for (int j = 0; j < 10; j++)
                {
                    if (i % 2 == 0)
                    {
                        nums[i, j] = row[j];
                    }
                    else
                    {
                        nums[i, 9 - j] = row[j];
                    }
                }
            }

            double[,] dp = new double[10, 10];
            double[,] best = new double[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int y = i;
                    int x = j;
                    for (int k = 1; k <= 6; k++)
                    {
                        if (x > 0)
                        {
                            x--;
                        }
                        else
                        {
                            y--;
                            x = 9;
                        }
                        if (y < 0)
                        {
                            break;
                        }
                        dp[i, j] += best[y, x] / 6;
                    }
                    dp[i, j]++;
                    if (i == 0 && j < 6)
                    {
                        dp[i, j] *= 6;
                        dp[i, j] /= j;
                    }
                    best[i, j] = dp[i, j];
                    if (nums[i, j] > 0)
                    {
                        y = i - nums[i, j];
                        x = nums[i, j] % 2 == 0 ? j : 9 - j;
                        best[i, j] = Min(best[i, j], dp[y, x]);
                    }
                }
            }
            WriteLine(best[9, 9]);
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
