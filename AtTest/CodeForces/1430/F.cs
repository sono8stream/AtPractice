using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1430
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
            int[] nk = ReadInts();
            int n = nk[0];
            long k = nk[1];

            int[][] lras = new int[n][];
            for(int i = 0; i < n; i++)
            {
                lras[i] = ReadInts();
            }

            int[] seqs = new int[n];
            for(int i = 0; i < n; i++)
            {
                int now = i;
                for(int j = i+1; j <n; j++)
                {
                    if (lras[j][0] == lras[i][1])
                    {
                        now = j;
                    }
                }
                seqs[i] = now;
            }

            // all, remain
            long[] dp = new long[2];
            for(int i = 0; i < n; i++)
            {
                long[] next = new long[2];
                long nextRemain = 0;

                if (dp[0] == -1)
                {
                    // cannot
                    long cnt = lras[i][2];
                    if (cnt > k * (lras[i][1] - lras[i][0] + 1))
                    {
                        WriteLine(-1);
                        return;
                    }
                    else
                    {
                        next[1] = dp[1] + cnt / k;
                        nextRemain = cnt % k;

                        if(cnt<= k * (lras[i][1] - lras[i][0]))
                        {
                            next[0] = dp[1] + cnt / k;
                            if (cnt % k > 0)
                            {
                                next[0]++;
                            }
                        }
                        else
                        {
                            next[0] = -1;
                        }
                    }
                }
                else
                {
                    if(lras[i][2]> k * (lras[i][1] - lras[i][0] + 1))
                    {
                        WriteLine(-1);
                        return;
                    }
                    else
                    {
                        next[1] = lras[i][2] / k;
                        nextRemain = lras[i][2] % k;

                        if (lras[i][2] <= k * (lras[i][1] - lras[i][0]))
                        {
                            next[0] = lras[i][2] / k;
                            if (lras[i][2] % k > 0)
                            {
                                next[0]++;
                            }
                        }
                    }


                }

                dp = next;
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
