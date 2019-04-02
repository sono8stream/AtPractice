using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class CodeFestival2017B_D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt() + 3;
            string str = Read();
            str += "001";
            List<List<int>> blockList = new List<List<int>>();
            int cnt = 1;
            bool nowZero = str[0] == '0';
            List<int> tmpList = new List<int>();
            for (int i = 1; i < n; i++)
            {
                if (nowZero == (str[i] == '0'))
                {
                    cnt++;
                }
                else
                {
                    if (nowZero && cnt >= 2)
                    {
                        if (tmpList.Count >= 2)
                        {
                            blockList.Add(tmpList);
                        }
                        tmpList = new List<int>();
                    }
                    if (!nowZero)
                    {
                        tmpList.Add(cnt);
                    }
                    cnt = 1;
                    nowZero = !nowZero;
                }
            }
            /*for(int i = 0; i < blockList.Count; i++)
            {
                for(int j = 0; j < blockList[i].Count; j++)
                {
                    Write(blockList[i][j]);
                }
                WriteLine();
            }*/
            int res = 0;
            for (int i = 0; i < blockList.Count; i++)
            {
                int[,] dp = new int[blockList[i].Count, 4];
                //残り0/1/x-1/x
                for (int j = 1; j < blockList[i].Count; j++)
                {
                    dp[j, 2] = Max(dp[j - 1, 1] + 1,
                        Max(dp[j - 1, 2] + blockList[i][j - 1] - 1,
                        dp[j - 1, 3] + blockList[i][j - 1]));
                    dp[j, 3] = Max(
                        Max(dp[j - 1, 0], dp[j - 1, 1]),
                        Max(dp[j - 1, 2], dp[j - 1, 3]));
                    if (blockList[i][j] == 1)
                    {
                        dp[j, 0] = dp[j, 2];
                        dp[j, 1] = dp[j, 3];
                        dp[j, 2] = dp[j, 3];
                    }
                    else
                    {
                        dp[j, 0] = Max(dp[j - 1, 1],
                            Max(dp[j - 1, 2], dp[j - 1, 3]))
                            + blockList[i][j];
                        dp[j, 1] = Max(dp[j - 1, 1],
                            Max(dp[j - 1, 2], dp[j - 1, 3]))
                            + blockList[i][j] - 1;
                    }
                }
                int last = blockList[i].Count - 1;
                int tmp = Max(
                    Max(dp[last, 0], dp[last, 1]),
                    Max(dp[last, 2], dp[last, 3]));
                //WriteLine(tmp);
                res += tmp;
            }
            WriteLine(res);
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
