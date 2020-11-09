using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_182
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
            long[] nx = ReadLongs();
            int n = (int)nx[0];
            long x = nx[1];
            long[] array = ReadLongs();
            long[] maxs = new long[n];
            for(int i = 0; i+1 < n; i++)
            {
                maxs[i] = array[i + 1] / array[i] - 1;
            }
            long[] uses = new long[n];
            for(int i = n - 1; i >= 0; i--)
            {
                uses[i] = x / array[i];
                x %= array[i];
            }

            long[] dp = new long[n];
            dp[n - 1] = 1;
            for(int i = n - 2; i >= 0; i--)
            {
                dp[i] = dp[i + 1];
                if (uses[i] > 0)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (j + 1 == n)
                        {
                            dp[i]++;
                        }
                        else if (uses[j] < maxs[j])
                        {
                            dp[i] += dp[j + 1];
                        }

                        // これ以上は繰り上がれない
                        if (uses[i] == 0)
                        {
                            break;
                        }
                    }
                }
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
