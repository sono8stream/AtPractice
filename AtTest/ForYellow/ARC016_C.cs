using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC016_C
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] costs = new int[m];
            List<int[]>[] ps = new List<int[]>[m];
            for(int i = 0; i < m; i++)
            {
                int[] cs = ReadInts();
                int c = cs[0];
                costs[i] = cs[1];
                ps[i] = new List<int[]>();
                for(int j = 0; j < c; j++)
                {
                    int[] ip = ReadInts();
                    ip[0]--;
                    ps[i].Add(ip);
                }
            }

            int all = 1 << n;
            double[] dp = new double[all];
            for (int i = all - 2; i >= 0; i--)
            {
                double tmp = double.MaxValue / 10;
                for(int j = 0; j < m; j++)
                {
                    int have = 0;
                    for (int k = 0; k < ps[j].Count; k++)
                    {
                        if ((i & (1 << ps[j][k][0])) > 0)
                        {
                            have += ps[j][k][1];
                        }
                    }
                    if (have == 100)
                    {
                        continue;
                    }
                    double tmp2 = costs[j] * 100.0 / (100 - have);
                    for(int k = 0; k < ps[j].Count; k++)
                    {
                        int next = i | (1 << ps[j][k][0]);
                        if (next > i)
                        {
                            tmp2 += dp[next] * ps[j][k][1] / (100 - have);
                        }
                    }
                    tmp = Min(tmp, tmp2);
                }
                dp[i] = tmp;
            }

            WriteLine(dp[0]);
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
