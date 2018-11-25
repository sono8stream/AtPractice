using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Library.LCS
{
    class AOJ_dpl1e
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s1 = Read();
            string s2 = Read();
            Console.WriteLine(GetDP(s1,s2));
        }

        static int GetDP(string s1,string s2)
        {
            var dp = new int[s1.Length + 1, s2.Length + 1];//s1 i,s2 jまでを同じにする操作数
            for (int i = 1; i <= s1.Length;i++) dp[i, 0] = i;
            for (int i = 1; i <= s2.Length;i++) dp[0, i] = i;
            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1);
                        dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                    //Console.Write(dp[i, j] + " ");
                }
                //Console.WriteLine();
            }
            return dp[s1.Length, s2.Length];
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
