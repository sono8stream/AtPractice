using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class Tenka2016B_B
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int length = s.Length;
            var dp = new int[105, 105,105];
            int inf = int.MaxValue / 2;
            //iマスまで見てカーソル位置がj，(の数-)の数がkの操作数
            for (int i = 0; i < 101; i++)
            {
                for(int j = 0; j < 101; j++)
                {
                    for (int k = 0; k < 101; k++)
                    {
                        dp[i, j, k] = inf;
                    }
                }
            }
            dp[0, 0, 0] = 0;

            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    for(int k = 0; k <= length; k++)
                    {
                        if (dp[i, j, k] == int.MaxValue) continue;

                        if (s[i] == '(')
                        {
                            dp[i + 1, j,k + 1]
                                = Math.Min(dp[i + 1, j, k + 1], dp[i, j, k]);
                            if (0 < k)
                            {
                                dp[i + 1, i, k - 1]
                                    = Math.Min(dp[i + 1, i, k - 1], dp[i, j, k] + 1);
                            }
                        }
                        else
                        {
                            dp[i + 1, i, k + 1]
                                = Math.Min(dp[i + 1, i, k + 1], dp[i, j, k] + 1);
                            if (0 < k)
                            {
                                dp[i + 1, j, k - 1]
                                    = Math.Min(dp[i + 1, j, k - 1], dp[i, j, k]);
                            }
                        }
                    }
                }
            }
            int res = inf;
            for(int i = 0; i < length; i++)
            {
                res = Math.Min(res, dp[length, i, 0] + i);
            }
            Console.WriteLine(res);
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
