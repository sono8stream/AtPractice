using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_176
{
    class F
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
            int[] array = ReadInts();

            int[,] dp = new int[n + 1, n + 1];
            for(int i = 0; i <= n; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    dp[i, j] = int.MinValue;
                }
            }

            int res = 0;
            int greedy = 0;
            dp[array[0], array[1]] = 0;
            for (int i = 2; i < array.Length; i += 3)
            {
                if (i + 1 == array.Length)
                {
                    dp[array[i], array[i]] = dp[array[i], array[i]] + 1;
                    res = Max(res, dp[array[i], array[i]]);
                }
                else
                {
                    if (array[i] == array[i + 1] && array[i] == array[i + 2])
                    {
                        greedy++;
                    }
                    else if (array[i] == array[i + 1] && array[i] != array[i + 2])
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            int next = Max(Max(dp[array[i], j], dp[j, array[i]]) + 1,
                                Max(dp[array[i + 2], j], dp[j, array[i + 2]]));
                            dp[array[i + 2], j] = next;
                            dp[j, array[i + 2]] = next;
                            res = Max(res, next);
                        }
                    }
                    else if (array[i + 1] == array[i + 2] && array[i + 1] != array[i])
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            int next = Max(Max(dp[array[i + 1], j], dp[j, array[i + 1]]) + 1,
                                Max(dp[array[i], j], dp[j, array[i]]));
                            dp[array[i], j] = next;
                            dp[j, array[i]] = next;
                            res = Max(res, next);
                        }
                    }
                    else if (array[i + 2] == array[i] && array[i + 2] != array[i + 1])
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            int next = Max(Max(dp[array[i + 2], j], dp[j, array[i + 2]]) + 1,
                                Max(dp[array[i + 1], j], dp[j, array[i + 1]]));
                            dp[array[i + 1], j] = next;
                            dp[j, array[i + 1]] = next;
                            res = Max(res, next);
                        }
                    }
                    else
                    {
                        int next = Max(dp[array[i], array[i]] + 1,
                            Max(dp[array[i + 1], array[i + 2]], dp[array[i + 2], array[i + 1]]));
                        dp[array[i + 1], array[i + 2]] = next;
                        dp[array[i + 2], array[i + 1]] = next;
                        res = Max(res, next);

                        next = Max(dp[array[i + 1], array[i + 1]] + 1,
                            Max(dp[array[i + 2], array[i]], dp[array[i], array[i + 2]]));
                        dp[array[i + 2], array[i]] = next;
                        dp[array[i], array[i + 2]] = next;
                        res = Max(res, next);

                        next = Max(dp[array[i + 2], array[i + 2]] + 1,
                            Max(dp[array[i], array[i + 1]], dp[array[i + 1], array[i]]));
                        dp[array[i], array[i + 1]] = next;
                        dp[array[i + 1], array[i]] = next;
                        res = Max(res, next);
                    }
                }
            }

            WriteLine(res + greedy);
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
