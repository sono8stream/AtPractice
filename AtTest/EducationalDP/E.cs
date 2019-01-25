using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class E
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nw = ReadInts();
            int n = nw[0];
            int w = nw[1];
            int[][] wvs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                wvs[i] = ReadInts();
            }
            var dp = new Dictionary<int, long>();
            dp.Add(0, 0);
            long max = 0;
            for(int i = 0; i < n; i++)
            {
                var nextDp = new Dictionary<int, long>();
                foreach(int key in dp.Keys)
                {
                    if (nextDp.ContainsKey(key))
                    {
                        nextDp[key] = Math.Max(dp[key], nextDp[key]);
                    }
                    else nextDp.Add(key, dp[key]);
                    int nextW = key + wvs[i][0];
                    if (nextW > w) continue;
                    if (nextDp.ContainsKey(nextW))
                    {
                        nextDp[nextW]
                            = Math.Max(nextDp[nextW], dp[key] + wvs[i][1]);
                    }
                    else
                    {
                        nextDp.Add(nextW, dp[key] + wvs[i][1]);
                        max = Math.Max(max, dp[key] + wvs[i][1]);
                    }
                }
                dp = nextDp;
            }
            Console.WriteLine(max);
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
