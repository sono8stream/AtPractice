using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class I
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            double[] ps = ReadDoubles();
            double[,] dp = new double[n, n + 1];//i個まででj個表の確率
            dp[0, 0] = 1 - ps[0];
            dp[0, 1] = ps[0];
            for(int i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] * (1 - ps[i]);
                for (int j = 1; j <= i + 1; j++)
                {
                    dp[i, j] = dp[i - 1, j] * (1 - ps[i])
                        + dp[i - 1, j - 1] * ps[i];
                }
            }
            double res = 0;
            for (int i = n / 2 + 1; i <= n; i++) res += dp[n - 1, i];
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
