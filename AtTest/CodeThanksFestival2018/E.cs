using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeThanksFestival2018
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            int[] array = ReadInts();
            long mask = 1000000000 + 7;
            var dp = new long[600];//i個になるときのパターン数 1~
            long res = 0;
            for (int i = 0; i < array[0]; i++)
            {
                dp[i] = 1;
            }
            if (array[0] > 0) res++;
            for(int i = 1; i < t; i++)
            {
                var nextDp = new long[600];
                for(int k = 0; k < array[i]; k++)
                {
                    nextDp[k] = 1;
                }
                for (int j = 0; j < 300; j++)
                {
                    int index = j * 2 + 1;
                    if (dp[index] == 0) continue;
                    for(int k = 0; k <= array[i]; k++)
                    {
                        nextDp[k + j] += dp[index];
                        nextDp[k + j] %= mask;
                    }
                }
                res += nextDp[0];
                res %= mask;
                dp = nextDp;
                //Console.WriteLine(nextDp[0]);
            }
            while (dp[0] > 0)
            {
                for(int i = 0; i < 300; i++)
                {
                    dp[i] = dp[i * 2 + 1];
                    dp[i * 2 + 1] = 0;
                }
                res += dp[0];
                res %= mask;
                //Console.WriteLine(dp[0]);
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
