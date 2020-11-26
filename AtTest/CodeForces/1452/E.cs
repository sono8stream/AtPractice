using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1452
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];

            int[][] lrs = new int[m][];
            for (int i = 0; i < m; i++)
            {
                lrs[i] = ReadInts();
                lrs[i][0]--;
                lrs[i][1]--;
            }
            // Sort for center
            Array.Sort(lrs, (a, b) => (a[0] + a[1]) - (b[0] + b[1]));


            int[] preSums = new int[m];
            for (int i = 0; i + k - 1 < n; i++)
            {
                int now = 0;
                for (int j = 0; j < m; j++)
                {
                    if (i + k - 1 < lrs[j][0])
                    {
                        break;
                    }

                    if (i <= lrs[j][0] && i + k - 1 <= lrs[j][1])
                    {
                        now += i + k - 1 - lrs[j][0] + 1;
                    }
                    else if (i <= lrs[j][0] && i + k - 1 > lrs[j][1])
                    {
                        now += lrs[j][1] - lrs[j][0] + 1;
                    }
                    else if (i + k - 1 <= lrs[j][1])
                    {
                        now += k;
                    }
                    else if (i <= lrs[j][1])
                    {
                        now += lrs[j][1] - i + 1;
                    }
                    preSums[j] = Max(preSums[j], now);
                }
            }

            int[] sufSums = new int[m];
            for (int i = n - k; i > 0; i--)
            {
                int now = 0;
                for (int j = m - 1; j >= 0; j--)
                {
                    if (i > lrs[j][1])
                    {
                        break;
                    }

                    if (i + k - 1 >= lrs[j][1] && i >= lrs[j][0])
                    {
                        now += lrs[j][1] - i + 1;
                    }
                    else if (i + k - 1 > lrs[j][1] && i < lrs[j][0])
                    {
                        now += lrs[j][1] - lrs[j][0] + 1;
                    }
                    else if (i >= lrs[j][0])
                    {
                        now += k;
                    }
                    else if (i + k - 1 >= lrs[j][0])
                    {
                        now += i + k - 1 - lrs[j][0] + 1;
                    }
                    sufSums[j] = Max(sufSums[j], now);
                }
            }

            long res = preSums[m - 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (lrs[i][0] + lrs[i][1] == lrs[j][0] + lrs[j][1])
                    {
                        continue;
                    }
                    res = Max(res, preSums[i] + sufSums[j]);
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
