using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_030
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] ln = ReadLongs();
            long l = ln[0];
            int n = (int)ln[1];
            var xs = new long[n];
            for(int i = 0; i < n; i++)
            {
                xs[i] = ReadLong();
            }

            //long left = Cost(xs, 0, 0, l) + xs[0];
            //long right = Cost(xs, 0, 0, l) + (l - xs[n - 1]);
            //Console.WriteLine(Math.Max(left, right));

            
            var dp = new long[n, n];
            dp[0, n - 1] = xs[0];
            for(int i = 1; i < n; i++)
            {
                dp[0, n - i - 1] = dp[0, n - 1] + (l - xs[n - i]) * 2;
                //Console.WriteLine(dp[0, n - i - 1]);
            }
            for(int i = 1; i < n; i++)
            {

            }

            var dpp = new long[n+1, n+1, 2];
            dpp[0, 0, 0] = 0;
            dpp[0, 0, 0] = 0;
            dpp[1, 0, 0] = xs[0];
            dpp[0, 1, 1] = (l - xs[n - 1]);
            dpp[1, 1, 0] = dpp[0, 1, 1] + xs[0] + (l - xs[n - 1]);
            dpp[1, 1, 1] = dpp[1, 0, 0] + xs[0] + (l - xs[n - 1]);
            for (int i = 1; i < n; i++)
            {
                dpp[i + 1, 0, 0] = dpp[i, 0, 0] + xs[i] - xs[i - 1];
                dpp[0, i + 1, 1] = dpp[0, i, 1] + xs[n - i] - xs[n - i - 1];
            }
            
            for (int i = 1; i <= n; i++)
            {
                dpp[1, i, 0] = dpp[0, i, 1] + xs[0] + (l - xs[n - i]);
                dpp[i, 1, 1] = dpp[i, 0, 0] + xs[i - 1] + (l - xs[n - 1]);
            }
            dpp[1, 1, 0] = xs[0] + (l - xs[n - 1]) * 2;
            dpp[1, 1, 0] = xs[0] * 2 + (l - xs[n - 1]);
            
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i + j > n) break;
                    
                    long val = dpp[i - 1, j, 0] + xs[i - 1];
                    if (i > 1) val -= xs[i - 2];
                    long val2 
                        = dpp[i - 1, j, 1] + xs[i - 1] + (l - xs[n - j]);
                    dpp[i, j, 0] = Math.Max(val, val2);
                    val = dpp[i, j - 1, 1];
                    if (j > 1) val += xs[n - j + 1] - xs[n - j];
                    else val += (l - xs[n - j]);
                    val2 = dpp[i, j - 1, 0] + xs[i - 1] + (l - xs[n - j]);
                    dpp[i, j, 1] = Math.Max(val, val2);
                    //Console.WriteLine(dpp[i, j, 0] + " " + dpp[i, j, 1]);

                }
            }

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    res = Math.Max(res, dpp[i, j, 0]);
                    res = Math.Max(res, dpp[i, j, 1]);
                }

            }
            Console.WriteLine(res);
        }

        static long Cost(long[] xs,int l,int r,long length)
        {
            if (l + r + 2 == xs.Length)
            {
                long val = xs[xs.Length - r - 1] - xs[l];
                val = Math.Max(val, length - val);
                return val;
            }
            else
            {
                long left = Cost(xs, l + 1, r, length) + xs[l+1]- xs[l - 1];
                long right = Cost(xs, l, r + 1, length)
                    + xs[xs.Length - r-1] - xs[xs.Length - r - 2];
                return Math.Max(left, right);
            }
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
