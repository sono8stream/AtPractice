using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class K
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] array = ReadInts();
            bool[] dp = new bool[k + 1];
            for(int i = array[0]; i <= k; i++)
            {
                bool win = false;
                for(int j = 0; j < n; j++)
                {
                    if (i - array[j] < 0) break;
                    if (!dp[i - array[j]])
                    {
                        win = true;
                        break;
                    }
                }
                dp[i] = win;
            }
            Console.WriteLine(dp[k] ? "First" : "Second");
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
