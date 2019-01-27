
using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.SoundHound2018
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
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            var array = new long[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = long.Parse(Console.ReadLine());
            }
            var dp = new long[n];
            var max = new long[n];
            for (int i = 0; i < k; i++)
            {
                if (i == 0)
                {
                    dp[i] = array[i];
                    max[i] = Math.Max(array[i], 0);
                }
                else
                {
                    dp[i] = dp[i - 1] + array[i];
                    max[i] = Math.Max(max[i - 1], dp[i]);
                }
            }
            dp[k - 1] = Math.Max(dp[k - 1], 0);
            for(int i = k; i < n; i++)
            {
                dp[i] = Math.Max(max[i - k], dp[i - 1] + array[i]);
                max[i] = Math.Max(max[i - 1], dp[i]);
            }
            /*for (int i = 0; i < n; i++)
            {
                Console.WriteLine(dp[i]);
            }*/
            Console.WriteLine(dp[n - 1]);
        }
    }
}
