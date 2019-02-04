using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class Tenka2016B_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            var dp = new int[101, 101, 101];
            for (int i = 0; i <= 100; i++)
                for (int j = 0; j <= 100; j++)
                    for (int k = 0; k <= 100; k++)
                        dp[i, j, k] = int.MaxValue;
            dp[0, 0, 0] = 0;
            for(int i = 0; i < s.Length; i++)
            {
                //for(int j=0;j<)
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
