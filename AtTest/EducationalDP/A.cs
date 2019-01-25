using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] hs = ReadInts();
            long[] dp = new long[n];
            dp[0] = 0;
            dp[1] = Math.Abs(hs[0] - hs[1]);
            for(int i = 2; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + Math.Abs(hs[i] - hs[i - 1]),
                    dp[i - 2] + Math.Abs(hs[i] - hs[i - 2]));
            }
            Console.WriteLine(dp[n - 1]);
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
