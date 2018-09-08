using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_044
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int a = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            var xs = new int[n];
            for (int i = 0; i < n; i++)
            {
                xs[i] = int.Parse(input[i]) - a;
            }
            int nx = n*50;
            var dp = new long[n, 2 * nx + 1];
            for(int i = 0; i < 2 * nx + 1; i++)
            {
                dp[0, i] = 0;
            }
            dp[0, xs[0] + nx] = 1;
            for (int i = 1; i < n; i++)
            {
                //string s = "";
                for (int j = 0; j < 2 * nx + 1; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (0 <= j - xs[i] && j - xs[i] < 2 * nx + 1)
                    {
                        dp[i, j] += dp[i - 1, j - xs[i]];
                    }
                    if (j - nx == xs[i])
                    {
                        dp[i, j]++;
                    }
                    //s += dp[i, j].ToString();
                }
                //Console.WriteLine(s);
            }
            Console.WriteLine(dp[n - 1, nx]);
        }

        static long Factorial(long n)
        {
            if (n == 0) return 1;

            return n * Factorial(n - 1);
        }
    }
}
