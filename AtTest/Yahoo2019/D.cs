using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Yahoo2019
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
            int l = ReadInt();
            long[] array = new long[l];
            for (int i = 0; i < l; i++)
            {
                array[i] = ReadInt();
            }
            long[,] dp = new long[l, 5];
            dp[0, 0] = array[0];
            dp[0, 1] = array[0] == 0 ? 2 : array[0] % 2;
            dp[0, 2] = (array[0] + 1) % 2;
            dp[0, 3] = array[0] == 0 ? 2 : array[0] % 2;
            dp[0, 4] = array[0];
            for (int i = 1; i < l; i++)
            {
                long even = array[i] == 0 ? 2 : array[i] % 2;
                long odd = (array[i] + 1) % 2;
                long val = dp[i - 1, 0];
                dp[i, 0] = val + array[i];
                val = Math.Min(val, dp[i - 1, 1]);
                dp[i, 1] = val + even;
                val = Math.Min(val, dp[i - 1, 2]);
                dp[i, 2] =val + odd;
                val = Math.Min(val, dp[i - 1, 3]);
                dp[i, 3] = val + even;
                val = Math.Min(val, dp[i - 1, 4]);
                dp[i, 4] = val + array[i];
            }
            Console.WriteLine(
                Math.Min(dp[l - 1, 0],
                Math.Min(dp[l - 1, 1],
                Math.Min(dp[l - 1, 2],
                Math.Min(dp[l - 1, 3], dp[l - 1, 4])))));
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
