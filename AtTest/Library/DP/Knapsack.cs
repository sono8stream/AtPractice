using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.DP
{
    class Knapsack
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
            int w = int.Parse(input[1]);
            var vs = new int[n];
            var ws = new int[n];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ');
                vs[i] = int.Parse(input[0]);
                ws[i] = int.Parse(input[1]);
            }

            var dp = new int[n + 1, w + 1];//要素数、重さでの最大価値
            for(int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= w; j++)
                {
                    if (j >= ws[i - 1])//選べるとき
                    {
                        if (dp[i - 1, j - ws[i - 1]] + vs[i - 1] > dp[i - 1, j])
                        {
                            dp[i, j] = dp[i - 1, j - ws[i - 1]] + vs[i - 1];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                    else//選ばないとき
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            Console.WriteLine(dp[n, w]);
        }
    }
}
