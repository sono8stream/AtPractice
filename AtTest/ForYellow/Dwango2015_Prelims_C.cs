using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Dwango2015_Prelims_C
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
            int n = ReadInt();
            if (n == 1)
            {
                WriteLine(1);
                return;
            }

            double[] pats = new double[n + 1];
            pats[0] = 1;
            double[] perms = new double[n + 1];
            perms[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                pats[i] = pats[i - 1] * 3;
                perms[i] = perms[i - 1] * i;
            }

            double[] dp = new double[n + 1];
            dp[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                double denominator = 0;
                for(int j = 1; j < i; j++)
                {
                    double pat = 0;
                    for(int k = j + 1; k < i - j - k; k++)// a<b<c
                    {
                        pat += 6 * perms[i] / (perms[j] * perms[i - j])
                            * perms[i - j] / (perms[k] * perms[i - j - k]);
                    }

                    if (j * 2 < i)// a<b
                    {
                        pat += 6 * perms[i] / (perms[j] * perms[i - j]);
                    }

                    if (j * 2 == i)// a=b
                    {
                        pat += 3 * perms[i] / (perms[j] * perms[i - j]);
                    }

                    if (j * 3 < i)// a=b<c
                    {
                        pat += 3 * perms[i] / (perms[j] * perms[i - j])
                            * perms[i - j] / (perms[j] * perms[i - j * 2]);
                    }

                    if ((i - j) % 2 == 0 && j * 3 < i)// a<b=c
                    {
                        pat += 3 * perms[i] / (perms[j] * perms[i - j])
                            * perms[i - j] / (perms[(i - j) / 2] * perms[(i - j) / 2]);
                    }

                    denominator += pat / pats[i] * (dp[j] + 1);
                }

                double samePat = 3;
                if (i % 3 == 0)
                {
                    samePat += perms[i] / (perms[i / 3] * perms[i * 2 / 3])
                            * perms[i * 2 / 3] / (perms[i / 3] * perms[i / 3]);
                }
                double numerator = 1 - samePat / pats[i];
                dp[i] = (denominator + samePat / pats[i]) / numerator;
            }

            WriteLine(dp[n]);
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
