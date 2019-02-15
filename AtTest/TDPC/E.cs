using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int d = ReadInt();
            string n = Read();
            var dp = new long[n.Length, d, 2];
            long mask = 1000000000 + 7;
            for (int i = 0; i < n[0] - '0'; i++)
            {
                dp[0, i % d, 0] = 1;
            }
            dp[0, (n[0] - '0') % d, 1] = 1;
            for (int i = 0; i + 1 < n.Length; i++)
            {
                int num = n[i + 1] - '0';
                for (int j = 0; j < d; j++)
                {
                    for (int k = 0; k <= 9; k++)
                    {
                        dp[i + 1, (j + k) % d, 0] += dp[i, j, 0];
                        dp[i + 1, (j + k) % d, 0] %= mask;
                        if (k < num)
                        {
                            dp[i + 1, (j + k) % d, 0] += dp[i, j, 1];
                            dp[i + 1, (j + k) % d, 0] %= mask;
                        }
                        else if (k == num)
                        {
                            dp[i + 1, (j + k) % d, 1] += dp[i, j, 1];
                            dp[i + 1, (j + k) % d, 1] %= mask;
                        }
                    }
                }
            }
            Console.WriteLine(
                dp[n.Length - 1, 0, 0] + dp[n.Length - 1, 0, 1] - 1);
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
