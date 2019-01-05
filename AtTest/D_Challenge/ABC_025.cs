using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_025
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = 25;
            var defDict = new Dictionary<int, int>();
            for (int i = 0; i < 5; i++)
            {
                int[] xx = ReadInts();
                for (int j = 0; j < 5; j++)
                {
                    if (xx[j] != 0) defDict.Add(xx[j], i * 5 + j);
                }
            }

            var dp = new long[1<< 25];
            dp[0] = 1;
            long mask = 1 << 9 + 7;
            for(int i = 1; i < dp.Length; i++)
            {
                int cnt = 0;
                for(int j = 0; j < 25; j++)
                {
                    if ((i >> j) % 2 == 1) cnt++;
                }

                if (defDict.ContainsKey(cnt))
                {
                    int val = 1 << defDict[cnt];
                    if ((i & val) > 0)
                    {
                        dp[i] = dp[i - val];
                    }
                    else dp[i] = 0;
                }
                else
                {
                    long pat = 0;
                    for (int j = 0; j < 25; j++)
                    {
                        int val = 1 << j;
                        if ((i & val) == 0) continue;
                        pat += dp[i - val];
                        pat %= mask;
                    }
                    dp[i] = pat;
                }
            }
            Console.WriteLine(dp[dp.Length - 1]);            
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
