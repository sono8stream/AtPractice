using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1421
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
                long[] xy = ReadLongs();
                long y = xy[0];
                long x = xy[1];
                long[] costs = ReadLongs();

                long[] minCosts = new long[6]
                {
                    Min(costs[0],costs[1]+costs[5]),
                    Min(costs[1],costs[2]+costs[0]),
                    Min(costs[2],costs[3]+costs[1]),
                    Min(costs[3],costs[4]+costs[2]),
                    Min(costs[4],costs[5]+costs[3]),
                    Min(costs[5],costs[0]+costs[4])
                };

                long dist;
                if (x > 0 && y > 0)
                {
                    long tmp2 = x * minCosts[1] + y * minCosts[5];
                    long tmp3 = Min(x, y) * minCosts[0];
                    if (x < y)
                    {
                        tmp3 += (y - x) * minCosts[5];
                    }
                    else
                    {
                        tmp3 += (x - y) * minCosts[1];
                    }
                    dist = Min(tmp2, tmp3);
                }
                else if (x > 0)
                {
                    long tmp2 = x * minCosts[1] + Abs(y) * minCosts[2];
                    long tmp3 = x * minCosts[0] + (Abs(y) + x) * minCosts[2];
                    dist = Min(tmp2, tmp3);
                }
                else if (y > 0)
                {
                    long tmp2 = Abs(x) * minCosts[4] + y * minCosts[5];
                    long tmp3 = Abs(x) * minCosts[3] + (Abs(x) + y) * minCosts[5];
                    dist = Min(tmp2, tmp3);
                }
                else
                {
                    long tmp2 = Abs(x) * minCosts[4] + Abs(y) * minCosts[2];
                    long tmp3 = Min(Abs(x), Abs(y)) * minCosts[3];
                    if (Abs(x) < Abs(y))
                    {
                        tmp3 += (Abs(y) - Abs(x)) * minCosts[2];
                    }
                    else
                    {
                        tmp3 += (Abs(x) - Abs(y)) * minCosts[4];
                    }
                    dist = Min(tmp2, tmp3);
                }

                WriteLine(dist);
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
