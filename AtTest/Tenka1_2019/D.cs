using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Tenka1_2019
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = new int[n];
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                array[i] = ReadInt();
                sum += array[i];
            }
            int max = sum / 2 + 1;
            //val, count
            long mask = 998244353;
            long[] dp = new long[max + 1];
            dp[0] = 1;
            for(int i = 0; i < n; i++)
            {
                long[] next = new long[max + 1];
                for(int j = 0; j <= max; j++)
                {
                    next[j] += dp[j] * 2;
                    next[j] %= mask;
                    int nextVal = Min(j + array[i], max);
                    next[nextVal] += dp[j];
                    next[nextVal] %= mask;
                }
                dp = next;
            }
            long res = 1;
            for(int i = 0; i < n; i++)
            {
                res *= 3;
                res %= mask;
            }
            res -= dp[max] * 3;
            if (sum % 2 == 0)
            {
                res -= dp[max - 1] * 3;
                long[] dp2 = new long[max + 1];
                dp2[0] = 1;
                for(int i = 0; i < n; i++)
                {
                    long[] next2 = new long[max + 1];
                    for(int j = 0; j <= max; j++)
                    {
                        next2[j] += dp2[j];
                        next2[j] %= mask;
                        int nextVal = Min(j + array[i], max);
                        next2[nextVal] += dp2[j];
                        next2[nextVal] %= mask;
                    }
                    dp2 = next2;
                }
                res += dp2[sum / 2] * 3;
            }
            while (res < 0) res += mask;
            res %= mask;
            WriteLine(res);
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
