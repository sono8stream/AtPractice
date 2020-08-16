using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TokioMarine_2020
{
    class E
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
            int[] nkst = ReadInts();
            int n = nkst[0];
            int k = nkst[1];
            int s = nkst[2];
            int t = nkst[3];
            int[] array = ReadInts();

            List<int> oks = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if ((s & array[i]) == s
                    && (t | array[i]) == t)
                {
                    oks.Add(array[i]);
                }
            }

            if (oks.Count == 0)
            {
                WriteLine(0);
            }

            //key: and, or
            var dict = new Dictionary<long, long[]>();
            for(int i = 0; i < oks.Count/2; i++)
            {
                var next = new Dictionary<long, long[]>();
                foreach(long key in dict.Keys)
                {
                    if (!next.ContainsKey(key))
                    {
                        next.Add(key,new long[k]);
                    }
                    for(int j = 0; j < k; j++)
                    {
                        next[key][j] += dict[key][j];
                    }

                    long nextKey = (((int)(key / 10000000)) & oks[i]) * 10000000
                        + (((int)(key % 10000000)) | oks[i]);
                    if (!next.ContainsKey(nextKey))
                    {
                        next.Add(nextKey, new long[k]);
                    }
                    for(int j = 1; j < k; j++)
                    {
                        next[nextKey][j] += dict[key][j - 1];
                    }
                }

                int baseKey = oks[i] * 10000000 + oks[i];
                if (!next.ContainsKey(baseKey))
                {
                    next.Add(baseKey, new long[k]);
                }
                next[baseKey][0]++;

                dict = next;
            }
            var dict2 = new Dictionary<long, long[]>();
            for (int i = oks.Count/2; i < oks.Count; i++)
            {
                var next = new Dictionary<long, long[]>();
                foreach (long key in dict2.Keys)
                {
                    if (!next.ContainsKey(key))
                    {
                        next.Add(key, new long[k]);
                    }
                    for (int j = 0; j < k; j++)
                    {
                        next[key][j] += dict2[key][j];
                    }

                    long nextKey = (((int)(key / 10000000)) & oks[i]) * 10000000
                        + (((int)(key % 10000000)) | oks[i]);
                    if (!next.ContainsKey(nextKey))
                    {
                        next.Add(nextKey, new long[k]);
                    }
                    for (int j = 1; j < k; j++)
                    {
                        next[nextKey][j] += dict2[key][j - 1];
                    }
                }

                int baseKey = oks[i] * 10000000 + oks[i];
                if (!next.ContainsKey(baseKey))
                {
                    next.Add(baseKey, new long[k]);
                }
                next[baseKey][0]++;

                dict2 = next;
            }
            long res = 0;
            if (dict.ContainsKey(s * 10000000 + t))
            {
                for (int i = 0; i < k; i++)
                {
                    res += dict[s * 10000000 + t][i];
                }
            }
            /*
            long[,] dp = new long[t + 1, k+1];
            dp[oks[0], 1] = 1;
            for(int i = 1; i < oks.Count; i++)
            {
                for (int j = t; j >= 0; j--)
                {
                    for (int l = k; l > 0; l--)
                    {
                        int next = j | oks[i];
                        dp[next, l] += dp[j, l - 1];
                    }
                }
                dp[oks[i], 1]++;
            }

            long res = 0;
            for(int i = 1; i <= k; i++)
            {
                res += dp[t, i];
            }
            */
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
