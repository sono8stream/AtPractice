using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class J
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            int[] cnt = new int[3];
            for (int i = 0; i < n; i++) cnt[array[i] - 1]++;
            double[,,] dp = new double[400, 400, 400];
            //各皿の枚数のときの期待値

            DFS(ref dp, cnt[0], cnt[1], cnt[2], n);
            Console.WriteLine(dp[cnt[0], cnt[1], cnt[2]]);
        }

        static void DFS(ref double[,,] dp, int i, int j, int k, int n)
        {
            if (i == 0 && j == 0 && k == 0) return;
            if (dp[i, j, k] != 0) return;

            double val = 0;
            int ijk = i + j + k;
            if (i > 0)
            {
                DFS(ref dp, i - 1, j, k, n);
                val += dp[i - 1, j, k] * i / ijk;
            }
            if (j > 0)
            {
                DFS(ref dp, i + 1, j - 1, k, n);
                val += dp[i + 1, j - 1, k] * j / ijk;
            }
            if (k > 0)
            {
                DFS(ref dp, i, j + 1, k - 1, n);
                val += dp[i, j + 1, k - 1] * k / ijk;
            }
            val += 1.0 * n / ijk;//状態遷移に必要な操作数の期待値
            dp[i, j, k] = val;
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
