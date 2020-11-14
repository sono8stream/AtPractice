using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.M_Solutions_2020
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
            int n = ReadInt();
            long[][] xyps = new long[n][];
            for(int i = 0; i < n; i++)
            {
                xyps[i] = ReadLongs();
            }

            int all = 1 << n;

            long[] horizonBars=new long[all];
            for(int i = 0; i < all; i++)
            {
                List<int> xs = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        xs.Add(j);
                    }
                }
                int[] array = xs.ToArray();
                Array.Sort(array, (a, b) => (int)(xyps[a][0] - xyps[b][0]));

                long min = long.MaxValue;
                for(int j = 0; j < array.Length; j++)
                {
                    long tmp = 0;
                    for(int k = 0; k < array.Length; k++)
                    {
                        tmp += xyps[array[k]][2] * Abs(xyps[array[j]][0] - xyps[array[k]][0]);
                    }
                    min = Min(min, tmp);
                }

                horizonBars[i] = min;
            }

            long[,] horizons = new long[all, n + 1];
            for(int i = 1; i < all; i++)
            {
                List<int> xs = new List<int>();
                for(int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        xs.Add(j);
                    }
                }
                int[] array = xs.ToArray();
                Array.Sort(array, (a, b) => (int)(xyps[a][0] - xyps[b][0]));

                long[,] dp = new long[array.Length, n + 1];
                for(int j = 0; j < array.Length; j++)
                {
                    long x = xyps[array[j]][0];
                    dp[j, 0] = Abs(x) * xyps[array[j]][2];
                    if (j > 0)
                    {
                        dp[j, 0] += dp[j - 1, 0];
                    }
                }

                for(int j = 0; j < array.Length; j++)
                {
                    for(int k = 1; k <= n; k++)
                    {
                        int pat = 0;
                        long min = xyps[array[j]][2] * Abs(xyps[array[j]][0]);
                        if (j > 0)
                        {
                            min += dp[j - 1, k];
                        }
                        for(int l = j; l >= 0; l--)
                        {
                            pat += (1 << (array[l]));
                            long tmp = horizonBars[pat];
                            if (l > 0)
                            {
                                tmp += dp[l - 1, k - 1];
                            }
                            min = Min(min, tmp);
                        }

                        dp[j, k] = min;
                    }
                }

                for (int j = 0; j <= n; j++)
                {
                    horizons[i, j] = dp[array.Length - 1, j];
                }
            }

            long[] verticalBars = new long[all];
            for (int i = 0; i < all; i++)
            {
                List<int> ys = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        ys.Add(j);
                    }
                }
                int[] array = ys.ToArray();
                Array.Sort(array, (a, b) => (int)(xyps[a][1] - xyps[b][1]));

                long min = long.MaxValue;
                for (int j = 0; j < array.Length; j++)
                {
                    long tmp = 0;
                    for (int k = 0; k < array.Length; k++)
                    {
                        tmp += xyps[array[k]][2] * Abs(xyps[array[j]][1] - xyps[array[k]][1]);
                    }
                    min = Min(min, tmp);
                }

                verticalBars[i] = min;
            }

            long[,] verticals = new long[all, n + 1];
            for (int i = 1; i < all; i++)
            {
                List<int> ys = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        ys.Add(j);
                    }
                }
                int[] array = ys.ToArray();
                Array.Sort(array, (a, b) => (int)(xyps[a][1] - xyps[b][1]));

                long[,] dp = new long[array.Length, n + 1];
                for (int j = 0; j < array.Length; j++)
                {
                    long y = xyps[array[j]][1];
                    dp[j, 0] = Abs(y) * xyps[array[j]][2];
                    if (j > 0)
                    {
                        dp[j, 0] += dp[j - 1, 0];
                    }
                }

                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 1; k <= n; k++)
                    {
                        int pat = 0;
                        long min = xyps[array[j]][2] * Abs(xyps[array[j]][1]);
                        if (j > 0)
                        {
                            min += dp[j - 1, k];
                        }
                        for (int l = j; l >= 0; l--)
                        {
                            pat += (1 << (array[l]));
                            long tmp = verticalBars[pat];
                            if (l > 0)
                            {
                                tmp += dp[l - 1, k - 1];
                            }
                            min = Min(min, tmp);
                        }

                        dp[j, k] = min;
                    }
                }

                for(int j = 0; j <= n; j++)
                {
                    verticals[i, j] = dp[array.Length - 1, j];
                }
            }

            for(int i = 0; i <= n; i++)
            {
                long res = long.MaxValue;
                for(int j = 0; j < all; j++)
                {
                    for(int k = 0; k <= i; k++)
                    {
                        res = Min(res, horizons[j, k] + verticals[all - j - 1, i - k]);
                    }
                }
                WriteLine(res);
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
