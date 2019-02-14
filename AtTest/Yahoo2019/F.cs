using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Yahoo2019
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int[] rCnt = new int[s.Length * 2 + 1];
            int[] bCnt = new int[s.Length * 2 + 1];
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '0':
                        rCnt[i+1] = 2;
                        break;
                    case '1':
                        rCnt[i+1] = 1;
                        bCnt[i+1] = 1;
                        break;
                    case '2':
                        bCnt[i+1] = 2;
                        break;
                }
                if (i > 0)
                {
                    rCnt[i+1] += rCnt[i];
                    bCnt[i+1] += bCnt[i];
                }
            }
            for (int i = s.Length + 1; i <= s.Length * 2; i++)
            {
                rCnt[i] = rCnt[i - 1];
                bCnt[i] = bCnt[i - 1];
            }
            int[,] dp = new int[s.Length * 2 + 1, s.Length * 2 + 1];
            //i個目まで取り，赤をj個取った時のパターン数
            int mask = 998244353;
            dp[0, 0] = 1;
            for (int i = 1; i <= s.Length * 2; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int red = j;
                    int blue = i - j;
                    if (red > rCnt[i] || blue > bCnt[i]) dp[i, j] = 0;
                    else
                    {
                        if (j == 0)
                        {
                            dp[i, j] = blue > bCnt[i] ? 0 : dp[i - 1, j];
                        }
                        else
                        {
                            if (red <= rCnt[i]) dp[i, j] = dp[i - 1, j - 1];
                            if (blue <= bCnt[i]) dp[i, j] += dp[i - 1, j];
                        }
                    }
                    dp[i, j] %= mask;
                }
            }
            Console.WriteLine(dp[s.Length * 2, rCnt[s.Length * 2]]);
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
