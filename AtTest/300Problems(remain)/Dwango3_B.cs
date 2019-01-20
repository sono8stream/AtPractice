using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Dwango3_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string t = Read();
            var dp = new int[t.Length, 2];
            dp[0, 0] = t[0] == '2' || t[0] == '?' ? 0 : -2;
            for (int i = 1; i < t.Length; i++)
            {
                if (t[i] == '2')
                {
                    dp[i, 0] = dp[i - 1, 1];
                    dp[i, 1] = 0;
                }
                else if (t[i] == '5')
                {
                    dp[i, 0] = -2;
                    dp[i, 1] = dp[i - 1, 0] + 2;
                }
                else if (t[i] == '?')
                {
                    dp[i, 0] = dp[i - 1, 1];
                    dp[i, 1] = dp[i - 1, 0] + 2;
                }
                else
                {
                    dp[i, 0] = -2;
                }
                //Console.WriteLine(dp[i, 0] + " " + dp[i, 1]);
            }
            int level = 0;
            for(int i = 0; i < t.Length; i++)
            {
                level = Math.Max(level, dp[i, 1]);
            }
            Console.WriteLine(level);
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
