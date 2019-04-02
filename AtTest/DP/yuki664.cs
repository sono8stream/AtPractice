using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class yuki664
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int n = nmk[0]+1;
            int m = nmk[1];
            int k = nmk[2];
            int[] array = new int[n];
            for (int i = 0; i < n; i++) array[i] = ReadInt();
            long[,][] dp = new long[m + 1, 2][];
            for(int i = 0; i < n; i++)
            {
                long[,][] next = new long[m + 1, 2][];
                for(int j = 0; j < m; j++)
                {

                }
            }
            //dp[0, 0, 0] = new long[3] { k, 0, 0 };
            //dp[0, 1, 1] = new long[3] { k % array[0], k / array[0], 1 };
            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    //int tmp=
                }
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
