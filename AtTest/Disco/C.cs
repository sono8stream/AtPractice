using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Disco
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long mask = 1000000000 + 7;
            var ptns = new long[n];//最大でi取るときのパターン数
            var sumPtns = new long[n];
            for (long i = 1; i <= n; i++)
            {
                var dp = new long[10, 2];//less[0] or not[1]
                dp[0, 0] = i - 1;
                dp[0, 1] = 1;
                for (int j = 1; j < 10; j++)
                {
                    dp[j, 0] = (dp[j - 1, 0] * (i-1)) % mask;
                    dp[j, 1] = (dp[j - 1, 1] * i) % mask;
                    dp[j, 1] += dp[j - 1, 0];
                    dp[j, 1] %= mask;
                }
                ptns[i - 1] = dp[9, 1];
                sumPtns[i - 1] = ptns[i - 1];
                if (i > 1)
                {
                    sumPtns[i - 1] += sumPtns[i - 2];
                    sumPtns[i - 1] %= mask;
                }
            }

            long res = 0;
            for (long i = 1; i <= n; i++)
            {
                long pair = n / i;
                if (i > pair) break;
                long baseVal = ptns[i - 1];
                res += baseVal
                    * (mask + sumPtns[pair - 1] - sumPtns[i - 1]) * 2;
                res += baseVal * baseVal;
                res %= mask;
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
