using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_113
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hwk = ReadInts();
            int h = hwk[0];
            int w = hwk[1];
            int k = hwk[2] - 1;
            long mask = 1000000000 + 7;
            var rowPats = new long[6] { 2, 3, 5, 8, 13, 21 };
            var dp = new long[h + 1, w];
            dp[0, 0] = 1;
            for (int i = 1; i <= h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    //まうえ
                    dp[i, j] = dp[i - 1, j];
                    dp[i, j] %= mask;
                    if (j >= 2)
                    {
                        dp[i,j]*= rowPats[j - 2];
                        dp[i, j] %= mask;
                    }
                    if (j + 3 <= w)
                    {
                        dp[i, j] *= rowPats[w - j - 3];
                        dp[i, j] %= mask;
                    }
                    dp[i, j] %= mask;

                    if (j < w - 1)//右
                    {
                        long right = dp[i - 1, j + 1];

                        if (j + 1 >= 3)
                        {
                            right *= rowPats[j - 2];
                            right %= mask;
                        }
                        if (j + 4 <= w)
                        {
                            right *= rowPats[w - j - 4];
                            right %= mask;
                        }
                        dp[i, j] += right;
                        dp[i, j] %= mask;
                    }
                    if (0 < j)//left
                    {
                        long left = dp[i - 1, j - 1];
                        if (j - 3 >= 0)
                        {
                            left *= rowPats[j - 3];
                            left %= mask;
                        }
                        if (j + 3 <= w)
                        {
                            left *= rowPats[w - j - 3];
                            left %= mask;
                        }
                        dp[i, j] += left;
                        dp[i, j] %= mask;
                    }
                    //Console.Write(dp[i, j] + " ");
                }
                //Console.WriteLine();
            }
            Console.WriteLine(dp[h, k]);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
