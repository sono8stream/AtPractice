using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class ARC067_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nabcd = ReadInts();
            int n = nabcd[0];
            int a = nabcd[1];
            int b = nabcd[2];
            int c = nabcd[3];
            int d = nabcd[4];

            long mask = 1000000000 + 7;
            long[] perms = AllPermutations(n, mask);
            //i-th, j people
            long[,] dp = new long[n + 5, n + 5];
            dp[0, 0] = 1;
            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j <= n - a * c; j++)
                {
                    for (int k = c; k <= d; k++)
                    {

                    }
                }
            }
        }

        static long[] AllPermutations(long n, long mask)
        {
            var perms = new long[n + 1];
            perms[0] = 1;
            for (int i = 0; i <= n; i++)
            {
                perms[i] = MultiMod(perms[i - 1], i, mask);
            }
            return perms;
        }

        static long MultiMod(long a, long b, long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        static long ReverseMod(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = ReverseMod(a, pow / 2, mask);
                long nextMod = MultiMod(halfMod, halfMod, mask);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return MultiMod(nextMod, a, mask);
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
