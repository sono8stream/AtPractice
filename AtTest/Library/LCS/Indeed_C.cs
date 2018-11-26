using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.LCS
{
    class Indeed_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var dp = new int[101, 101, 101];//a,b,cの値とその時の収入
            for (int i = 0; i < nm[0]; i++)
            {
                int[] abcw = ReadInts();
                dp[abcw[0], abcw[1], abcw[2]]
                    = Math.Max(dp[abcw[0], abcw[1], abcw[2]], abcw[3]);
            }
            for(int i = 0; i <= 100; i++)
            {
                for (int j = 0; j <= 100; j++)
                {
                    for (int k = 0; k <= 100; k++)
                    {
                        int prevA = i == 0 ? 0 : dp[i - 1, j, k];
                        int prevB = j == 0 ? 0 : dp[i , j-1, k];
                        int prevC = k == 0 ? 0 : dp[i , j, k-1];
                        dp[i, j, k] = Math.Max(dp[i, j, k], prevA);
                        dp[i, j, k] = Math.Max(dp[i, j, k], prevB);
                        dp[i, j, k] = Math.Max(dp[i, j, k], prevC);
                    }
                }
            }

            var res = new int[nm[1]];
            for(int i = 0; i < nm[1]; i++)
            {
                int[] abc = ReadInts();
                res[i] = dp[abc[0], abc[1], abc[2]];
            }
            for(int i = 0; i < nm[1]; i++)
            {
                Console.WriteLine(res[i]);
            }
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
