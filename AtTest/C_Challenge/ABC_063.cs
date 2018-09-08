using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_063
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var ss = new int[n];
            for (int i = 0; i < n; i++)
            {
                ss[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(ss);
            //Array.Reverse(ss);
            var dp = new int[n,10];//i番目までの数を使える時の各余りでの最大値
            dp[0, ss[0] % 10] = ss[0];
            for (int i = 1; i < n; i++)
            {
                string s = "";
                int margin = ss[i] % 10;
                for (int j = 0; j < 10; j++)
                {
                    int nextIndex = (j + margin) % 10;
                    dp[i, nextIndex] = dp[i, j] + ss[i];
                    s += dp[i, nextIndex].ToString();
                }
                Console.WriteLine(s);

            }
            int max = 0;
            for(int i = 1; i < 10; i++)
            {
                if (max < dp[n - 1, i]) max = dp[n - 1, i];
            }
            Console.WriteLine(max);
        }
    }
}
