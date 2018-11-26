using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] ab = ReadInts();
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            var dp = new int[ab[0]+1, ab[1]+1];//a i,b j残っているときの点数
            int all = ab[0] + ab[1];
            for (int i = 1; i <= ab[0]; i++)
            {
                int turn = all - i;
                if (turn % 2 == 0)
                {
                    dp[i, 0] = aArray[ab[0] - i] + dp[i - 1, 0];
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 0];
                }
            }
            for(int i = 1; i <= ab[1]; i++)
            {
                int turn = all - i;
                if (turn % 2 == 0)
                {
                    dp[0,i] = bArray[ab[1] - i] + dp[0, i - 1];
                }
                else
                {
                    dp[0, i] = dp[0, i - 1];
                }
            }
            for(int i = 1; i <= ab[0]; i++)
            {
                for(int j = 1; j <= ab[1]; j++)
                {
                    int turn = all - i - j;
                    if (turn % 2 == 0)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j] + aArray[ab[0] - i],
                            dp[i, j - 1] + bArray[ab[1] - j]);
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            Console.WriteLine(dp[ab[0], ab[1]]);
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
