using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC_058
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
            long[] nxyz = ReadLongs();
            long n = nxyz[0];
            long[] xyz = new long[3] { nxyz[1], nxyz[2], nxyz[3] };
            long x = nxyz[1];
            long y = nxyz[2];
            long z = nxyz[3];
            long mask = 1000000000 + 7;
            long[] twoPows = new long[21];
            twoPows[0] = 1;
            for(long i = 1; i <=20; i++)
            {
                twoPows[i] = twoPows[i - 1]*2;
                twoPows[i] %= mask;
            }
            long pats = twoPows[x + y + z];
            long[,] dp = new long[n + 1, pats];
            dp[0, 0] = 1;
            for(long i = 0; i < n; i++)
            {
                for(long j = 0; j < pats; j++)
                {
                    for(long k = 1; k <= 10; k++)
                    {
                        long next = j * twoPows[k];
                        next += twoPows[k - 1];
                        next %= pats;
                        if ((next & twoPows[z-1]) > 0
                            && (next & twoPows[y+z - 1]) > 0
                            && (next & twoPows[x + y + z - 1]) > 0)
                        {
                            continue;
                        }

                        dp[i + 1, next] += dp[i, j];
                        dp[i + 1, next] %= mask;
                    }
                }
            }
            long res = 0;
            for (long i = 0; i <pats; i++)
            {
                res += dp[n,i];
                res %= mask;
            }
            long tens = 1;
            for (long i = 0; i < n; i++)
            {
                tens *= 10;
                tens %= mask;
            }
            res = (tens - res+mask)%mask;
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
