using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_day2
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nr = ReadInts();
            int n = nr[0];
            int r = nr[1];
            int[] ps = ReadInts();
            int[] groups = new int[n];
            for(int i = 0; i < n; i++)
            {
                groups[i] = -1;
            }
            int groupCnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (groups[i] >= 0) continue;

                HashSet<int> posSet = new HashSet<int>();
                int now = i;
                while (!posSet.Contains(now))
                {
                    posSet.Add(now);
                    groups[now] = groupCnt;
                    now = ps[now] - 1;
                }
                groupCnt++;
            }

            int[] cnts = new int[groupCnt];
            for(int i = 0; i < n; i++)
            {
                cnts[groups[i]]++;
            }

            List<int[]> cntParams = new List<int[]>();
            for (int i = 0; i < groupCnt; i++)
            {
                if (cntParams.Count == 0) {
                    cntParams.Add(new int[2] { cnts[i], 1 });
                }
                else
                {
                    if (cntParams[cntParams.Count - 1][0] == cnts[i])
                    {
                        cntParams[cntParams.Count - 1][1]++;
                    }
                    else
                    {
                        cntParams.Add(new int[2] { cnts[i], 1 });
                    }
                }
            }

            int[,] dp = new int[cntParams.Count, r + 1];
            for(int i = 0; i < cntParams.Count; i++)
            {
                for(int j = 0; j < r + 1; j++)
                {
                    dp[i, j] = -1;
                }
            }

            for(int i = 0; i < cntParams.Count; i++)
            {
                dp[i, 0] = cntParams[i][1];
                for(int j = 0; j < r + 1; j++)
                {
                    if (i > 0 && dp[i - 1, j] >= 0)
                    {
                        dp[i, j] = cntParams[i][1];
                    }
                    else if (j - cntParams[i][0] >= 0 
                        && dp[i, j - cntParams[i][0]] > 0)
                    {
                        dp[i, j] = dp[i, j - cntParams[i][0]] - 1;
                    }
                }
            }

            if (dp[cntParams.Count-1,r]>=0)
            {
                WriteLine("Yes");
            }
            else
            {
                WriteLine("No");
            }
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
