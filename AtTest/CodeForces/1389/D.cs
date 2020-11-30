using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1389
{
    class D
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
            int t = ReadInt();
            for (int i = 0; i < t; i++)
            {
                int[] nk = ReadInts();
                int n = nk[0];
                long k = nk[1];
                long[] lr1 = ReadLongs();
                long l1 = lr1[0];
                long r1 = lr1[1];
                long[] lr2 = ReadLongs();
                long l2 = lr2[0];
                long r2 = lr2[1];
                if (l1>l2)
                {
                    long lTmp = l1;
                    long rTmp = r1;
                    l1 = l2;
                    r1 = r2;
                    l2 = lTmp;
                    r2 = rTmp;
                }

                long now = 0;
                long firstCost = 0;
                long sameRange = 0;
                if (l2 < r1)
                {
                    if (r2 < r1)
                    {
                        sameRange = r1 - r2 + l2 - l1;
                        now = (r2 - l2) * n;
                    }
                    else
                    {
                        sameRange = r2 - r1 + l2 - l1;
                        now = (r1 - l2) * n;
                    }
                }
                else
                {
                    firstCost = l2 - r1;
                    sameRange = r2 - l1;
                }

                k -= now;
                if (k<=0)
                {
                    WriteLine(0);
                    continue;
                }

                if (sameRange < (firstCost + sameRange) / 2)
                {
                    if (k <= sameRange)
                    {
                        WriteLine(firstCost + k);
                    }
                    else
                    {
                        WriteLine(firstCost + sameRange + (k - sameRange) * 2);
                    }
                    continue;
                }

                long maxScore = sameRange * n;
                if (k <= maxScore)
                {
                    long score = (k / sameRange) * (firstCost + sameRange);
                    if (k % sameRange > 0)
                    {
                        if (score > 0)
                        {
                            score += Min(firstCost + k % sameRange, (k % sameRange) * 2);
                        }
                        else
                        {
                            score += firstCost + k % sameRange;
                        }
                    }
                    WriteLine(score);
                }
                else
                {
                    WriteLine((firstCost + sameRange) * n + (k - maxScore) * 2);
                }
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
