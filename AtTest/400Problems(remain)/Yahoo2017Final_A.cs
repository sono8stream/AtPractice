using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class Yahoo2017Final_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            int[,] dp = new int[s.Length + 1, 5];
            string t = "yahooyahoo";
            for (int i = 1; i <= s.Length; i++)
            {
                dp[i, 0] = i;
            }
            for(int i = 1; i < 5; i++)
            {
                dp[0, i] = i;
            }
            for(int i = 1; i <= s.Length; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    dp[i, j%5] = Math.Min(dp[i - 1, j%5], dp[i, (j - 1)%5]) + 1;
                    int val = dp[i - 1, (j - 1)%5];
                    if (s[i-1] != t[j-1]) val++;
                    dp[i, j%5] = Math.Min(dp[i, j%5], val);
                }
            }
            Console.WriteLine(dp[s.Length,0]);
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
