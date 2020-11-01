using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_046
{
    class C
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            string[] input = Read().Split();
            string s = input[0];
            int k = int.Parse(input[1]);

            List<int> blocks = new List<int>();
            int cnt = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    blocks.Add(cnt);
                    cnt = 0;
                }
                else
                {
                    cnt++;
                }
            }
            blocks.Add(cnt);

            int[] revSums = new int[blocks.Count];
            for(int i = blocks.Count - 1; i >= 0; i--)
            {
                revSums[i] = blocks[i];
                if (i + 1 < blocks.Count)
                {
                    revSums[i] += revSums[i + 1];
                }
            }

            long mask = 998244353;
            k = Min(s.Length, k);
            // 今見ているblock位置で配置せずに残っている1の数と操作回数
            long[,] dp = new long[revSums[0] + 5, k + 1];
            dp[revSums[0], 0] = 1;
            for(int i = 0; i < blocks.Count; i++)
            {
                long[,] next = new long[revSums[0] + 5, k + 1];
                int max = revSums[i] - blocks[i];

                // 今の位置にいくつか残す（移動は無し）
                long[] sums = new long[k + 1];
                for (int j = revSums[0]+5-1; j >=0; j--)
                {
                    for (int l = 0; l <= k; l++)
                    {
                        sums[l] += dp[j, l];
                        if (j + blocks[i] + 1 < revSums[0] + 5)
                        {
                            sums[l] += mask - dp[j + blocks[i] + 1, l];
                        }
                        sums[l] %= mask;

                        if (j > max)
                        {
                            continue;
                        }

                        next[j, l] += sums[l];
                        next[j, l] %= mask;
                    }
                }

                // 今の位置に初期値以上になるようにいくつか積む（積んだ分だけ操作数増加）
                long[,] crossSums = new long[revSums[0] + 5, k + 1];
                for (int j = revSums[0] + 5 - 1; j >= 0; j--)
                {
                    for (int l = 0; l <= k; l++)
                    {
                        crossSums[j, l] = dp[j, l];
                        if (j + 1 < revSums[0] + 5 && l - 1 >= 0)
                        {
                            crossSums[j, l] += crossSums[j + 1, l - 1];
                        }
                        crossSums[j, l] %= mask;
                    }
                }
                for (int j = revSums[0] + 5 - 1; j >= 0; j--)
                {
                    for (int l = 1; l <= k; l++)
                    {
                        if (j > max)
                        {
                            continue;
                        }

                        next[j, l] += crossSums[j + blocks[i] + 1, l - 1];
                        next[j, l] %= mask;
                    }
                }

                dp = next;
            }

            long res = 0;
            for (int i = 0; i < revSums[0] + 5; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    res += dp[i, j];
                    res %= mask;
                }
            }

            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
