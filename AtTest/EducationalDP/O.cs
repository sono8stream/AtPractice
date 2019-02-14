using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class O
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] checks = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] ok = ReadInts();
                int val = 0;
                int unit = 1;
                for (int j = 0; j < n; j++)
                {
                    val += ok[j] == 1 ? unit : 0;
                    unit *= 2;
                }
                checks[i] = val;
            }

            int all = 1 << n;
            long[,] dp = new long[n, all];
            //男iまで見たときにペアになっている女の状態jのときの組み合わせ総数
            long mask = 1000000000 + 7;
            for(int i = 1; i < all; i++)
            {
                int now = -1;
                for(int j = 0; j < n; j++)
                {
                    int div = 1 << j;
                    if ((i & div) > 0) now++;
                }
                if (now == 0)
                {
                    if ((i & checks[now]) > 0) dp[now,i] = 1;
                }
                else
                {
                    for(int j = 0; j < n; j++)
                    {
                        int div = 1 << j;
                        if ((checks[now] & div) == 0) continue;
                        if ((i & div) > 0)
                        {
                            dp[now, i] += dp[now - 1, i - div];
                            dp[now, i] %= mask;
                        }
                    }
                }
            }
            Console.WriteLine(dp[n - 1, all - 1]);
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
