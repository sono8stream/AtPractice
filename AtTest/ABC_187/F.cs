using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_187
{
    class F
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
            HashSet<int>[] graph = new HashSet<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[b].Add(a);
            }
            if (m == n * (n - 1) / 2)
            {
                WriteLine(1);
                return;
            }

            HashSet<int>[] cans = new HashSet<int>[n];
            for(int i = 0; i < n; i++)
            {
                cans[i] = new HashSet<int>();
            }
            int all = 1 << n;
            for (int i = 1; i < all; i++)
            {
                List<int> used = new List<int>();
                int edges = 0;
                int max = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        for (int k = 0; k < used.Count; k++)
                        {
                            if (graph[j].Contains(used[k]))
                            {
                                edges++;
                            }
                        }
                        used.Add(j);
                        max = j;
                    }
                }
                if (edges == used.Count * (used.Count - 1) / 2)
                {
                    cans[max].Add(i);
                }
            }

            int[] dp = new int[all];
            for(int i = 0; i < all; i++)
            {
                    dp[i] = int.MaxValue / 2;
            }
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 1; i < n; i++)
            {
                int full = 1 << i;
                foreach (int can in cans[i])
                {
                    for (int j = 0; j < full; j++)
                    {
                        if ((j & can) == 0)
                        {
                            dp[j + can] = Min(dp[j + can], dp[j] + 1);
                        }
                    }
                }
            }
            WriteLine(dp[all - 1]);
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
