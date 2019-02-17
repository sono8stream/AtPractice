using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC118
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] array = ReadInts();
            Array.Sort(array);
            int[] costs = new int[9] { 2, 5, 5, 4, 5, 6, 3, 7, 6 };
            int[] dp = new int[n + 10];
            for (int i = 0; i < dp.Length; i++) dp[i] = int.MinValue;
            dp[0] = 0;
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && dp[i] == int.MinValue) continue;
                
                for (int j = 0; j < m; j++)
                {
                    dp[i + costs[array[j] - 1]] 
                        = Math.Max(dp[i] + 1, dp[i + costs[array[j] - 1]]);
                }
            }
            string res = "";
            //for (int i = 0; i <= n; i++) Console.WriteLine(dp[i]);
            for (int i = n; i > 0;)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (i - costs[array[j] - 1] < 0) continue;
                    if (dp[i - costs[array[j] - 1]] == dp[i] - 1)
                    {
                        res += (char)(array[j] + '0');
                        i -= costs[array[j] - 1];
                        break;
                    }
                }
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
